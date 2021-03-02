import socket
import json
from threading import Thread

HOST = '135.181.35.212'  # Standard loopback interface address (localhost)
PORT = 65432        # Port to listen on (non-privileged ports are > 1023)

panel = None

def handleConn(conn, addr):
    global panel
    print(addr)
    while True:
        data = conn.recv(1024)
        print("Recv: " + str(data))
        if data == bytes("closeConn",encoding="utf-8"):
            conn.close()
            break
        elif data == bytes("getPanel",encoding="utf-8"):
            conn.sendall(panel)
        else:
            conn.sendall(bytes("set", encoding="utf-8"))
            panel = data

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    s.bind((HOST, PORT))
    s.listen()
    while True:
        conn, addr = s.accept()
        t = Thread(target=handleConn, args=(conn, addr,), daemon=True)
        t.start()