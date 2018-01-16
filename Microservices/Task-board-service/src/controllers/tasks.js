const Task = require('../models/task');
const tasks = {};

tasks.addTask = (req, res) => {
    Task.create({
        author_id: req.body.author_id,
        name: req.body.name,
        description: req.body.description,
        state: 'inactive'
    })
        .then(task => {
            res.status(201);
            res.send('ok');
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

tasks.getUserTasks = (req, res) => {
    const userId = req.params.id;
    Task.findAll({
        where: {
            author_id: userId
        }    
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