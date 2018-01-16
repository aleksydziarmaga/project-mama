const Task = require('../models/task');
const tasks = {};

tasks.addTask = (req, res) => {
    Task.create({
        author_id: 2,
        name: req.body.name,
        description: req.body.description,
        state: 'inactive'
    })
        .then(task => {
            res.status(201);
            res.send(task);
        })
        .catch(err =>{
            res.status(500);
            res.send(err)
            console.error(err);
    })
}

tasks.getTasks = (req, res) => {
    Task.findAll({
        limit: 1000,
    })
        .then(tasks => {
            res.status(200);
            res.send(tasks);
        })
        .catch(err => {
            res.status(500);
            res.send(err)
            console.error(err);
        })
}

module.exports = tasks;