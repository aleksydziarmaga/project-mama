import axios from 'axios';

const fetchTasks = () => {
    const URI = 'http://localhost:4000/tasks'
    return axios.get(URI)
        .then((res) => res.data)
        .catch((err) => err);
};
const addTask = (task) => {
    const URI = 'http://localhost:4000/tasks'
    return axios.post(URI, task)
        .then((res) => res.data)
        .catch((err) => err);
}

const addUser = (user) => {
    const URI = 'http://localhost:4000/register'
    return axios.post(URI, user)
        .then(res => res.data)
        .catch(err => err);
}
export default {fetchTasks, addTask, addUser};