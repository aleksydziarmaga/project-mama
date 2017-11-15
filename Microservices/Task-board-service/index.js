const http = require('http');
const express = require('express');
const bodyParser = require('body-parser');


const port = process.env.PORT || 4000;
const app = express();

app.use(bodyParser.json());

app.post('/task', (req, res) => {
    const task = req.body;
    res.send(task);
    io.emit('taskAdded', task);

})

const server = http.createServer(app);
const io = require('socket.io')(server);

server.listen(port, () => {
    console.log(`Server listening on http://localhost:${port}`)
})