const express = require('express');
const db = require('../src/models/db');
const config = require('./config');

const app = express();
const port = process.env.PORT || 4000;

app.use(express.json());

//Database conection
db
    .authenticate()
    .then(() => {
        console.log('Connection has been established successfully.');
    })
    .catch(err => {
        console.error('Unable to connect to the database:', err);
    });

app.use('/tasks', require('../src/routes/tasks'));

// Server start
app.listen(port, () => {
    console.log(`Server listening on http://localhost:${port}`)
})