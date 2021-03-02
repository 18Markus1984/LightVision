import asyncio
import websockets

async def getStonks():
    uri = "wss://api.lemon.markets/streams/v1/marketdata"
    async with websockets.connect(uri) as websocket:
        request = "hello"
        await websocket.send(request)
        response = await websocket.recv()
        print(response)
