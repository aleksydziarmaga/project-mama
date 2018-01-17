const Sequilize = require('sequelize');
const config = require('../../config/config');

const db = new Sequilize({...config.database})

module.exports = db;