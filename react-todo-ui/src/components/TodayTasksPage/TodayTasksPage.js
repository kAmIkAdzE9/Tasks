import React from "react";
import { useState, useEffect } from "react";
import TasksForToday from "../TasksForToday/TasksForToday";
import TaskAPI from "../../TaskAPI";

export default function TodayTasksPage() {
    const [tasks, setTasks] = useState([]);
    useEffect(() => { TaskAPI.getTasksFoToday().then(res => setTasks(res)) }, [])
    
    function removeTask(id) {
        TaskAPI.deleteTask(id);
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