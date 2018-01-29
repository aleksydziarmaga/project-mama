import axios from 'axios';

const fetchTasks = () => {
    const URI = 'http://localhost:4000/tasks'
    return axios.get(URI)
        .then((res) => res.data)
        .catch((err) => err);
};
const addTask = (data) => {
    const URI = 'http://localhost:4000/tasks'
    return axios.post(URI, data)
        .then((res) => res.data)
        .catch((err) => err);
}
export default {fetchTasks, addTask};