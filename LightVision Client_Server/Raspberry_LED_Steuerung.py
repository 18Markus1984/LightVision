import socket
import json
from threading import Thread
import time
import random
from rpi_ws281x import *
import argparse

HOST = '135.181.35.212'  # The server's hostname or IP address
PORT = 65432        # The port used by the server

recvPanels = []
recvTimes = []

numbers = [[0,1,2,26,50,74,98,122,146,170,169,168,144,120,96,72,48,24],[1,24,25,49,73,97,121,145,168,169,170],[0,1,2,26,50,74,73,72,96,120,144,168,169,170],[0,1,2,26,50,74,98,122,146,170,169,168,73,72],[0,24,48,72,73,74,50,26,2,98,122,146,170],[2,1,0,24,48,72,73,74,98,122,146,170,169,168],[2,1,0,24,48,72,96,120,144,168,169,170,146,122,98,74,73],[0,1,2,26,50,74,98,122,146,170],[0,1,2,26,50,74,98,122,146,170,169,168,144,120,96,72,48,24,73],[73,72,48,24,0,1,2,26,50,74,98,122,146,170,169,168]]


# LED strip configuration:
LED_COUNT      = 192      # Number of LED pixels.
LED_PIN        = 18      # GPIO pin connected to the pixels (18 uses PWM!).
#LED_PIN        = 10      # GPIO pin connected to the pixels (10 uses SPI /dev/spidev0.0).
LED_FREQ_HZ    = 800000  # LED signal frequency in hertz (usually 800khz)
LED_DMA        = 10      # DMA channel to use for generating signal (try 10)
LED_BRIGHTNESS = 255     # Set to 0 for darkest and 255 for brightest
LED_INVERT     = False   # True to invert the signal (when using NPN transistor level shift)
LED_CHANNEL    = 0       # set to '1' for GPIOs 13, 19, 41, 45 or 53
Array = [None] *192

def RGBAfromInt(argb_int):
    blue =  argb_int & 255
    green = (argb_int >> 8) & 255
    red =   (argb_int >> 16) & 255
    alpha = (argb_int >> 24) & 255
    return (red, green, blue, alpha)

def setPixel(strip,color,i):
    strip.setPixelColor(Array[i], color)

def showPanel(strip, wait):
    #Methode liest ARGB Werte aus recvPanels aus und leitet diese jeweils einzeln an setPixel weiter
    for i in range(0, len(recvPanels)):
        count = 0
        for k in range(0, len(recvPanels[i])):
            colors = RGBAfromInt(recvPanels[i][k])
            setPixel(strip, Color(colors[0], colors[1], colors[2]), count)
            count += 1
        strip.show()
        time.sleep(recvTimes[i])       
    
def showNumber(zahl, position, strip):
    for x in range(len(numbers[zahl])):
        setPixel(strip, Color(255,255,255),numbers[zahl][x] + position)
    strip.show()
    

def ArrayErzeugen():
    for x in range(24):
        for y in range(8):
            pos = y * 24 + x
            if (x < 8):
                Array[pos] = getPositionOuterMatrix(x, y)
            elif (x < 16):
                Array[pos] = getPositionInnerMatrix(x - 8, y) + 64
            else:
                Array[pos] = getPositionOuterMatrix(x - 16, y) + 128
    
    print(Array)

def getPositionOuterMatrix(x, y):
    return 7 - y + x * 8

def getPositionInnerMatrix(x, y):
    return x + y * 8 

def downloadPanels(strip):
    #Methode zieht Panels vom Root-Server, speichert die Color Werte in recvPanels, startet die showPanel Methode in einem extra Thread und startet nach 30s erneut
    global recvPanels
    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
        s.connect((HOST, PORT))
        while True:
            s.sendall(bytes("getPanel\n",encoding="utf-8"))
            buffer = ""
            while not buffer.endswith("\n"):
                rcv = s.recv(1024)
                buffer += str(rcv, encoding="utf-8")
            buffer = json.loads(buffer)
            recvPanels.clear()
            recvTimes.clear()
            print("Panels updated")
            for i in range(0,len(buffer)):
                recvPanels.append(buffer[i]['colors'])
                recvTimes.append(buffer[i]['showtime'])
            t = Thread(target=showPanel, args=(strip, 5), daemon=True)
            t.start()
            threadTime = 0
            for i in range(0,len(recvTimes)):
                threadTime += recvTimes[i]
            time.sleep(threadTime)
 
# Main program logic follows:
if __name__ == '__main__':
    # Process arguments
    parser = argparse.ArgumentParser()
    parser.add_argument('-c', '--clear', action='store_true', help='clear the display on exit')
    args = parser.parse_args()

    # Create NeoPixel object with appropriate configuration.
    strip = Adafruit_NeoPixel(LED_COUNT, LED_PIN, LED_FREQ_HZ, LED_DMA, LED_INVERT, LED_BRIGHTNESS, LED_CHANNEL)
    # Intialize the library (must be called once before other functions).
    strip.begin()

    print ('Press Ctrl-C to quit.')
    if not args.clear:
        print('Use "-c" argument to clear LEDs on exit')
    ArrayErzeugen()
    
    try:
        downloadPanels(strip)
    except KeyboardInterrupt:
        if args.clear:
            colorWipe(strip, Color(0,0,0), 10)

