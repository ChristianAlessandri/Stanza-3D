const WebSocket = require('ws')
const port = 8080
const wss = new WebSocket.Server({port: port}, () => {
  console.log('Server Started');
});

wss.on('connection', (ws) => {
  ws.on('message', (data) => {
    console.log('Data received: ' + data);
    ws.send(data);
  });
});

wss.on('listening', () => {
  console.log('Server is listening on port ' + port);
});

// Invia un msg a tutti i client collegati
wss.broadcast = function broadcast(data) {
  wss.clients.forEach(function each(client) {
    if (client.readyState === WebSocket.OPEN) {
      client.send(data);
    }
  });
};

// Manda msg ogni x secondi
const interval = 1000;
setInterval(() => {
  wss.broadcast('true');
}, interval);

