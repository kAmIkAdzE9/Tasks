import React, { useState, useEffect } from "react";
import './ToDoListPage.css'
import Tasks from '../Tasks/Tasks'
import TaskForm from '../TaskForm/TaskForm';
import TaskAPI from "../../TaskAPI";
import { useParams } from "react-router";
import { useDispatch } from "react-redux";
import { updateCountOfTaskAfterAddTask, updateCountOfTaskAfterDeleteTask } from '../../store/dashboard/actions'

export default function ToDoListPage() {
    const { id } = useParams();
    const [tasks, setTasks] = useState([]);
    const [isVisibleDoneTasks, setIsVisibleDoneTasks] = useState(false);
    useEffect(() => { TaskAPI.getTasksFromList(id).then(res => setTasks(res)) }, [id]);

    const dispatch = useDispatch();

    const filteredTasks = isVisibleDoneTasks ? tasks : tasks.filter(t => t.done === false);

    function removeTask(id) {
        TaskAPI.deleteTask(id)
            .then(res => res.ok ? dispatch(updateCountOfTaskAfterDeleteTask(tasks.filter(task => task.id == id)[0].taskListId)): console.log(res))
        setTasks(tasks.filter(task => task.id !== id));
    }

    function updateTask(task) {
        TaskAPI.partialUpdateTask(task);
    }

    function createTask(event) {
        event.preventDefault();
        let formData = new FormData(event.target);
        let task = Object.fromEntries(formData.entries());
        task.title = task.title.trim();
        task.dueDate = new Date(task.dueDate);
        task.id = '0';
        task.taskListId = id;
        if (task.title !== '') {
            TaskAPI.createTask(task)
                .then(res => setTasks([...tasks, res]))
                .then(_ => event.target.reset())
                .then(dispatch(updateCountOfTaskAfterAddTask(id)))
        }
    }

    return (
        <div>
            <div id='show-all-tasks'>
                <label>Show All Tasks</label>
                <input type='checkbox' onClick={() => setIsVisibleDoneTasks(!isVisibleDoneTasks)} />
            </div>

            <Tasks tasks={filteredTasks} removeTask={removeTask} updateTask={updateTask} />
            <TaskForm createTask={createTask} />
        </div>
    )
}