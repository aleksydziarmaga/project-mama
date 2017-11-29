require('dotenv').config({path: __dirname + '/.env'});

const config = {}

config.database = {
    host: process.env.DB_HOST,
    username: process.env.DB_USER,
    password: process.env.DB_PASS,
    dialect: 'mysql'
}

module.exports = config;