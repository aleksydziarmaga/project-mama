const express = require('express');
const Sequilize = require('sequelize');
const config = require('./config');

const app = express();
const port = process.env.PORT || 4000;

app.use(express.json());

//Database conection
const sequelize = new Sequilize({...config.database})
sequelize
    .authenticate()
    .then(() => {
        console.log('Connection has been established successfully.');
    })
    .catch(err => {
        console.error('Unable to connect to the database:', err);
    });
    
// Server start
app.listen(port, () => {
    console.log(`Server listening on http://localhost:${port}`)
})