const express = require('express');
const router = express.Router();
const {addTask, getTasks, getUserTasks} = require('../controllers/tasks');

router.get('/', getTasks);
router.get('/:id', getUserTasks);
router.post('/', addTask);

module.exports = router;