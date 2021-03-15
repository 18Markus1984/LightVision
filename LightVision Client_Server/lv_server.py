import socket
import json
from threading import Thread
from time import sleep

HOST = '135.181.35.212'  # Standard loopback interface address (localhost)
PORT = 65432        # Port to listen on (non-privileged ports are > 1023)

panel = None

def handleConn(conn, addr):
    global panel
    print(addr)
    while True:
        continue_read = True
        buffer = ""
        while not buffer.endswith("\n"):
            rcv = conn.recv(1024)
            buffer += str(rcv, encoding="utf-8")
#        print("Recv: " + buffer)
        if buffer == "closeConn\n":
            conn.close()
            break
        elif buffer == "getPanel\n":
            conn.send(bytes(panel + "\n", encoding="utf-8"))
        else:
            conn.send(bytes("set\n", encoding="utf-8"))
            panel = buffer
            t = Thread(target=savePanelsMan, daemon=True)
            t.start()

def openServer():
    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
        s.bind((HOST, PORT))
        s.listen()
        while True:
            conn, addr = s.accept()
            t = Thread(target=handleConn, args=(conn, addr), daemon=True)
            t.start()

def savePanelsAuto():
    while True:
        if panel != None and panel != "":
            file = open("savedPanels.txt", "w")
            file.write(panel)
            file.close()
            sleep(30)
            
def savePanelsMan():
    if panel != None and panel != "":
        file = open("savedPanels.txt", "w")
        file.write(panel)
        file.close()
        
def loadPanelsOnStart():
    global panel
    file = open("savedPanels.txt", "r")
    file.seek(0)
    panel = file.read()
    file.close()

loadPanelsOnStart()
t = Thread(target=savePanelsAuto, daemon=True)
t.start()
openServer()
