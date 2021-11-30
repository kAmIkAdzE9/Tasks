import React, { useState, useEffect } from "react";
import './ToDoListPage.css'
import Tasks from '../Tasks/Tasks'
import TaskForm from '../TaskForm/TaskForm';
import TaskAPI from "../../TaskAPI";
import { useParams } from "react-router";
import { useDispatch} from "react-redux";
import { updateCountOfTasksAfterAddTask, updateCountOfTasksAfterDeleteTask, updateCountOfTaskAfterUpdateTask} from '../../store/dashboard/actions'

export default function ToDoListPage() {
    const { id } = useParams();
    const [tasks, setTasks] = useState([]);
    useEffect(() => { TaskAPI.getTasksFromList(id).then(res => setTasks(res)) }, [id]);

    const [isVisibleDoneTasks, setIsVisibleDoneTasks] = useState(false);

    const dispatch = useDispatch();
    const filteredTasks = isVisibleDoneTasks ? tasks : tasks.filter(t => t.done === false);

    function removeTask(task) {
        TaskAPI.deleteTask(task.id)
            .then(res => res.ok ? dispatch(updateCountOfTasksAfterDeleteTask(task.taskListId, task.done)): console.log(res))
            
        setTasks(tasks.filter(t => t.id !== task.id));
    }

    function updateTask(task) {
        TaskAPI.partialUpdateTask(task)
            .then(dispatch(updateCountOfTaskAfterUpdateTask(task.taskListId, task.done)))
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
                .then(dispatch(updateCountOfTasksAfterAddTask(id)))
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