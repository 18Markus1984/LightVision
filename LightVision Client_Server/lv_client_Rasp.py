import socket
import json
from threading import Thread
from time import sleep

HOST = '135.181.35.212'  # The server's hostname or IP address
PORT = 65432        # The port used by the server
recvPanels = None

def getPanels():
    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
        s.connect((HOST, PORT))
        while True:
            s.sendall(bytes("getPanel",encoding="utf-8"))
            data = s.recv(1024)
            recvPanels = json.loads(data)
            sleep(10)
            
Thread t = Thread(target=getPanels)
t.start()
