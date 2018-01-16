const express = require('express');
const router = express.Router();
const {addTask, getTasks} = require('../controllers/tasks');

router.get('/', getTasks);
router.post('/', addTask);

module.exports = router;