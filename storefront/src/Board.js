import React, { Component } from 'react';
import openSocket from 'socket.io-client';
import api from './utils/api'
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';

const socket = openSocket('http://localhost:4000');

function addTask(cb) {
    socket.on('taskAdded', task => cb(task))
}

class Board extends Component {
    constructor(props) {
        super(props);
        this.state = {
            tasks: ['cos, cosik']
        }
        this.getTasks = this.getTasks.bind(this);

        addTask(task => {
            let newTasks = this.state.tasks;
            !newTasks ? newTasks =[task] : newTasks.push(task)
            this.setState({tasks: newTasks})
        })


    }
    componentDidMount() {
        this.getTasks();
    }
    getTasks() {
        api.fetchTasks()
            .then(tasks => this.setState(() => {
                return {
                    tasks
                }
            }))
            .catch(err => console.error(err));
    }
    render() {
        return (
            <div className='col-sm-5'>
                {!this.state.tasks ? <p>Loading...</p> : <Tasks tasks={this.state.tasks} />}
            </div>
        )
    }
}

const Tasks = ({tasks}) => 
    <div className='tasks-list'>
        {
            tasks.map(task => (
                <div key={task.id} className='card task'>
                    <div className='card-body'>
                        <h4 className='card-title'>{task.name}</h4>
                        <p className='card-text'>description: {task.description}</p>
                    </div>
                </div> 
            ))
        }
    </div>


export default Board