const express = require('express');
const cors = require('cors');

const db = require('../src/models/db');
const config = require('./config');

const app = express();
const port = process.env.PORT || 4001;

app.use(express.json());
app.use(cors());
//Database conection
db
    .authenticate()
    .then(() => {
        console.log('Connection has been established successfully.');
    })
    .catch(err => {
        console.error('Unable to connect to the database:', err);
    });

app.get('/', (req, res) => res.send('Hello'));

app.use('/tasks', require('../src/routes/tasks'));

// Server start
app.listen(port, () => {
    console.log(`Server listening on http://localhost:${port}`)
})