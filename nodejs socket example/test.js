const WebSocket = require('ws');

const ws = new WebSocket('ws://localhost:1234/Test');

ws.on('open', function open() {
    ws.send('something');

    ws.send('something 2');
});

ws.on('message', function incoming(data) {
    console.log(data);
});