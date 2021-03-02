import socket
import json
from time import sleep

HOST = '135.181.35.212'  # The server's hostname or IP address
PORT = 65432        # The port used by the server

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.connect((HOST, PORT))
    x = [0,1,2,3]
    y = json.dumps(x)
    while True:
        command = input("Enter command: ")
        if command == "sendPanel":
            s.sendall(bytes(y,encoding="utf-8"))
        elif command == "getPanel":
            s.sendall(bytes("getPanel",encoding="utf-8"))
        elif command == "":
            s.sendall(bytes("closeConn",encoding="utf-8"))
            break
        else:
            print("Command not recognized, try again")
            continue
        print(repr(s.recv(1024)))
