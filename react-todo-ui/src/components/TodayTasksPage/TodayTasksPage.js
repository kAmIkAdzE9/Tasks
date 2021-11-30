import React from "react";
import { useState, useEffect } from "react";
import TasksForToday from "../TasksForToday/TasksForToday";
import TaskAPI from "../../TaskAPI";
import { useDispatch } from "react-redux";
import {updateCountOfTaskAfterDeleteTask } from '../../store/dashboard/actions'

export default function TodayTasksPage() {
    const [tasks, setTasks] = useState([]);
    useEffect(() => { TaskAPI.getTasksFoToday().then(res => setTasks(res)) }, [])

    const dispatch = useDispatch();
    
    function removeTask(id) {
        TaskAPI.deleteTask(id)
            .then(res => res.ok ? dispatch(updateCountOfTaskAfterDeleteTask(tasks.filter(task => task.id == id)[0].taskList.id)): console.log(res))
        setTasks(tasks.filter(task => task.id !== id));
    }

    function updateTask(task) {
        TaskAPI.partialUpdateTask(task);
    }

    return (
        <div>
            <TasksForToday tasks={tasks} removeTask={removeTask} updateTask={updateTask}/>
        </div>
    )
}