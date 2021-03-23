try:
    # For Python 3.0 and later
    from urllib.request import urlopen
except ImportError:
    # Fall back to Python 2's urllib2
    from urllib2 import urlopen

import socket
import json
from threading import Thread
import time
import random
from rpi_ws281x import *
import argparse
import datetime

HOST = '135.181.35.212'  # The server's hostname or IP address
PORT = 65432        # The port used by the server

recvPanels = []
recvTimes = []
recvName = []
recvRep = []
threadTimes = []

numbers = [[0,1,2,26,50,74,98,122,146,170,169,168,144,120,96,72,48,24],[1,24,25,49,73,97,121,145,168,169,170],[0,1,2,26,50,74,73,72,96,120,144,168,169,170],[0,1,2,26,50,74,98,122,146,170,169,168,73,72],[0,24,48,72,73,74,50,26,2,98,122,146,170],[2,1,0,24,48,72,73,74,98,122,146,170,169,168],[2,1,0,24,48,72,96,120,144,168,169,170,146,122,98,74,73],[0,1,2,26,50,74,98,122,146,170],[0,1,2,26,50,74,98,122,146,170,169,168,144,120,96,72,48,24,73],[73,72,48,24,0,1,2,26,50,74,98,122,146,170,169,168],[25,50,49,48,72,96,97,98,122,146,145,144,169]]
#[1,26,25,24,48,72,73,74,98,122,121,120,145] Dollar oben

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

def get_jsonparsed_data(url):
    response = urlopen(url)
    data = response.read().decode("utf-8")
    return json.loads(data)

def createOrder():
    order = []
    puffer = []
    timePuffer = []
    global threadTimes
    #threadTimes.clear()
    for i in range(0, len(recvPanels)):
        if(any(char.isdigit() for char in recvName[i])):
            puffer.append(recvPanels[i])
            nameWODigits = ''.join([i for i in recvName[i] if not i.isdigit()])
            if(i == len(recvPanels) - 1 or not recvName[i + 1].startswith(nameWODigits)):
                for j in range(0,recvRep[i]):
                    for k in range(0,len(puffer)):
                        order.append(puffer[k])
                        timePuffer.append(recvTimes[i])
                puffer.clear()
        else:
            order.append(recvPanels[i])
            timePuffer.append(recvTimes[i])
    threadTimes.clear()
    threadTimes = timePuffer
    return order

def showPanel(strip, wait, order):
    #Methode liest ARGB Werte aus recvPanels aus und leitet diese jeweils einzeln an setPixel weiter
    for i in range(0, len(order)):
        count = 0
        for k in range(0, len(order[i])):
            colors = RGBAfromInt(order[i][k])
            setPixel(strip, Color(colors[0], colors[1], colors[2]), count)
            count += 1
            
        if i < len(recvName) and recvName[i] == "clock":
            hour = [int(d) for d in str(datetime.datetime.now().hour)]
            minute = [int(d) for d in str(datetime.datetime.now().minute)]
            
            if len(hour) == 1:
                pufferHour = hour[0]
                hour = [0,0]
                hour[1] = pufferHour

            if len(minute) == 1:
                pufferMinute = minute[0]
                minute = [0,0]
                minute[1] = pufferMinute

            showNumber(hour[0],7,strip)
            showNumber(hour[1],11,strip)
            showNumber(minute[0],17,strip)
            showNumber(minute[1],21,strip)
            
        if i < len(recvName) and recvName[i] == "stonks1":
            url = ("https://financialmodelingprep.com/api/v3/quote/GME?apikey=e2b332f85953e46cffa4f8b5c8e00255")
            data = get_jsonparsed_data(url)
            price = [int(d) for d in str(round(data[0]['price']))]
            showNumber(price[0],9,strip)
            showNumber(price[1],13,strip)
            showNumber(price[2],17,strip)
            showNumber(10,21,strip)
            
        strip.show()
        time.sleep(threadTimes[i])       
    
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
    
    #print(Array)

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
            recvName.clear()
            recvRep.clear()
            #print("Panels updated")
            for i in range(0,len(buffer)):
                recvPanels.append(buffer[i]['colors'])
                recvTimes.append(buffer[i]['showtime'])
                recvName.append(buffer[i]['name'])
                recvRep.append(buffer[i]['wiederholungen'])
            toShow = createOrder()            
            t = Thread(target=showPanel, args=(strip, 5, toShow), daemon=True)
            t.start()
            toWait = 0
            for i in range(0, len(threadTimes)):
                toWait += threadTimes[i]
            toWait = round(toWait)                
            time.sleep(toWait + 0.3)
            
def colorWipe(strip, color, wait_ms=50):
    """Wipe color across display a pixel at a time."""
    for i in range(strip.numPixels()):
        #strip.setPixelColor(i, color)
        setPixel(strip, color, i)
        strip.show()
        time.sleep(wait_ms/1000.0)
 
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
        colorWipe(strip, Color(0,0,0), 10)

