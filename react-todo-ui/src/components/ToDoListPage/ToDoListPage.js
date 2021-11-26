import React, { useState, useEffect } from "react";
import './ToDoListPage.css' 
import Tasks from '../Tasks/Tasks'
import TaskForm from '../TaskForm/TaskForm';
import TaskAPI from "../../TaskAPI";
import { useParams } from "react-router";

export default function ToDoListPage() {
    const { id } = useParams();
    const [tasks, setTasks] = useState([]);
    const[taskVisionMode, setTaskVisionMode] = useState(true);

    useEffect(() => { TaskAPI.getTasksFromList(id).then(res => setTasks(res)) }, [id]);

    function removeTask(listId) {
        setTasks(tasks.filter(task => task.id !== listId));
    }

    function addTask(res) {
        setTasks(
            [
                ...tasks,
                res
            ])
    }

    function updateTaskVisionMode() {
        setTaskVisionMode(!taskVisionMode);
    }

    return (
        <div>
            <div id="mode">
                <label>Show all tasks: </label>
                <input type="checkbox" onClick={updateTaskVisionMode} />
            </div>
            <Tasks tasks={tasks} removeTask={removeTask} taskVisionMode={taskVisionMode}/>
            <TaskForm addTask={addTask} id={id} />
        </div>
    )
}