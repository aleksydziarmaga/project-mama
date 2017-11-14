const http = require('http');

const server = http.createServer();
const io = require('socket.io')(server);

const port = process.env.PORT || 4000;

server.listen(port, () => {
    console.log(`Server listening on http://localhost:${port}`)
})