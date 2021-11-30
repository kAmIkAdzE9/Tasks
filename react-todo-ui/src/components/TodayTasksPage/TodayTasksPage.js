import React from "react";
import { useState, useEffect } from "react";
import TasksForToday from "../TasksForToday/TasksForToday";
import TaskAPI from "../../TaskAPI";
import { useDispatch } from "react-redux";
import {updateCountOfTasksAfterDeleteTask, updateCountOfTaskAfterUpdateTask } from '../../store/dashboard/actions'

export default function TodayTasksPage() {
    const [tasks, setTasks] = useState([]);
    useEffect(() => { TaskAPI.getTasksFoToday().then(res => setTasks(res)) }, [])

    const dispatch = useDispatch();
    
    function removeTask(task) {
        TaskAPI.deleteTask(task.id)
            .then(res => res.ok ? dispatch(updateCountOfTasksAfterDeleteTask(task.taskList.id, task.done)): console.log(res))
            
        setTasks(tasks.filter(t => t.id !== task.id));
    }

    function updateTask(task) {
        TaskAPI.partialUpdateTask(task)
            .then(dispatch(updateCountOfTaskAfterUpdateTask(task.taskList.id, task.done)))
    }

    return (
        <div>
            <TasksForToday tasks={tasks} removeTask={removeTask} updateTask={updateTask}/>
        </div>
    )
}