#!/usr/bin/env python3
# rpi_ws281x library strandtest example
# Author: Tony DiCola (tony@tonydicola.com)
#
# Direct port of the Arduino NeoPixel library strandtest example.  Showcases
# various animations on a strip of NeoPixels.

import time
import random
from rpi_ws281x import *
import argparse

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



# Define functions which animate LEDs in various ways.
def setPixel(strip,color,i):
    strip.setPixelColor(Array[i], color)

def showPanel(strip, panel, wait):
    count = 0
    for i in range(0, len(panel)):
        for k in range(0, len(panel[i])):
            setPixel(strip, panel[i][k])
            count += 1
        time.sleep(wait)

def colorWipe(strip, color, wait_ms=50):
    """Wipe color across display a pixel at a time."""
    for i in range(strip.numPixels()):
        #strip.setPixelColor(i, color)
        setPixel(strip, color, i)
        strip.show()
        time.sleep(wait_ms/1000.0)

def colorRandom(strip, color,wait_ms=10,iterations=1):
    for j in range(256*iterations):
        for i in range(10):
            #strip.setPixelColor(i, color)
            setPixel(strip, wheel((int(i * 256 / strip.numPixels()) + j) & 255), random.randint(0,191))
            strip.show()
            time.sleep(wait_ms/1000.0)

def theaterChase(strip, color, wait_ms=50, iterations=10):
    """Movie theater light style chaser animation."""
    for j in range(iterations):
        for q in range(3):
            for i in range(0, strip.numPixels(), 3):
                #strip.setPixelColor(i+q, color)
                setPixel(strip, color, i+q)
            strip.show()
            time.sleep(wait_ms/1000.0)
            for i in range(0, strip.numPixels(), 3):
                #strip.setPixelColor(i+q, 0)
                setPixel(strip, 0, i+q)

def wheel(pos):
    """Generate rainbow colors across 0-255 positions."""
    if pos < 85:
        return Color(pos * 3, 255 - pos * 3, 0)
    elif pos < 170:
        pos -= 85
        return Color(255 - pos * 3, 0, pos * 3)
    else:
        pos -= 170
        return Color(0, pos * 3, 255 - pos * 3)

def rainbow(strip, wait_ms=20, iterations=1):
    """Draw rainbow that fades across all pixels at once."""
    for j in range(256*iterations):
        for i in range(strip.numPixels()):
            #strip.setPixelColor(i, wheel((i+j) & 255))
            setPixel(strip, wheel((i+j) & 255), i)
        strip.show()
        time.sleep(wait_ms/1000.0)

def rainbowCycle(strip, wait_ms=20, iterations=5):
    """Draw rainbow that uniformly distributes itself across all pixels."""
    for j in range(256*iterations):
        for i in range(strip.numPixels()):
            #strip.setPixelColor(i, wheel((int(i * 256 / strip.numPixels()) + j) & 255))
            setPixel(strip, wheel((int(i * 256 / strip.numPixels()) + j) & 255), i)
        strip.show()
        time.sleep(wait_ms/1000.0)

def theaterChaseRainbow(strip, wait_ms=50):
    """Rainbow movie theater light style chaser animation."""
    for j in range(256):
        for q in range(3):
            for i in range(0, strip.numPixels(), 3):
                #strip.setPixelColor(i+q, wheel((i+j) % 255))
                setPixel(strip, wheel((i+j) % 255), i+q)
            strip.show()
            time.sleep(wait_ms/1000.0)
            for i in range(0, strip.numPixels(), 3):
                #strip.setPixelColor(i+q, 0)
                setPixel(strip, 0, i+q)
                
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

        while True:
            print ('Color wipe animations.')
            colorWipe(strip, Color(255, 0, 0))  # Red wipe
            colorWipe(strip, Color(0, 255, 0))  # Blue wipe
            colorWipe(strip, Color(0, 0, 255))  # Green wipe
            print ('Theater chase animations.')
            theaterChase(strip, Color(127, 127, 127))  # White theater chase
            theaterChase(strip, Color(127,   0,   0))  # Red theater chase
            theaterChase(strip, Color(  0,   0, 127))  # Blue theater chase
            print ('Rainbow animations.')
            rainbow(strip)
            rainbowCycle(strip)
            #theaterChaseRainbow(strip)
            colorWipe(strip, Color(0,0,0), 10)
            colorRandom(strip, Color(255, 0,217))
            #colorRandom(strip, Color(20, 224, 0))
            #colorRandom(strip, Color(225, 255,0))

    except KeyboardInterrupt:
        if args.clear:
            colorWipe(strip, Color(0,0,0), 10)