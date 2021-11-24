import React from "react";
import './Tasks.css'
import { Task } from "../Task/Task";

export default function Tasks(props) {
    const tasks = props.tasks;
    return (
        <div id="tasks">
            {tasks.map(task => <Task key={task.id} title={task.title} description={task.description} dueDate={task.dueDate}/>)}
        </div>
    ) 
}