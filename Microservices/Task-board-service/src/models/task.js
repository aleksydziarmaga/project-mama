const Sequilize = require('sequelize');
const db = require('./db');

const Task = db.define('task', {
    author_id: Sequilize.INTEGER,
    name: Sequilize.STRING,
    description: Sequilize.TEXT,
    state: Sequilize.STRING
},
{
    timestamps: false,
})

module.exports = Task;