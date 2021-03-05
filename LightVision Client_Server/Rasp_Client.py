import socket
import json
from threading import Thread
from time import sleep

HOST = '135.181.35.212'  # The server's hostname or IP address
PORT = 65432        # The port used by the server
recvPanels = []

def downloadPanels():
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
            for i in range(0,len(buffer)):
                recvPanels.append(buffer[i]['colors'])
            print(recvPanels)
            sleep(30)
            
t = Thread(target=downloadPanels)
t.start()