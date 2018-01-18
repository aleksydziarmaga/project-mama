const http = require('http');
const express = require('express');
const axios = require('axios');

const port = process.env.PORT || 4000;
const app = express();

app.use(express.json());

app.get('/tasks', async (req, res) => {
    try {
        const response = await axios.get('http://localhost:4001/tasks');
        const { status, data } = response;
        res.status(status);
        res.send(data);
    }
    catch (err) {
        const { status, statusText } = err.response;
        res.status(status);
        res.send(statusText)
    }    
});
app.post('/tasks', async (req, res) => {
    const body = req.body;
    try {
        const response = await axios.post('http://localhost:4001/tasks', body);
        const { status, statusText, data} = response;
        io.emit('taskAdded', data);                
        res.status(status);
        res.send(statusText);
    }
    catch (err) {
        const { status, statusText } = err.response;
        res.status(status);
        res.send(statusText)
    }
});

const server = http.createServer(app);
const io = require('socket.io')(server);

server.listen(port, () => {
    console.log(`Server listening on http://localhost:${port}`)
});