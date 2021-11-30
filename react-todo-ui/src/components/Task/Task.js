import React, { useState } from "react";
import './Task.css'

export function Task(props) {
    const task = props.task;
    const [done, setDone] = useState(task.done);

    return (
        <div className={'task' + (task.done ? ' task-done' : (new Date() > new Date(task.dueDate).setHours(23, 59, 59) ? ' task-with-expired-date' : ''))}>
            <h2>{task.title}</h2>
            <label>Done: </label>
            <input type="checkbox" checked={done} onChange={() => { task.done = !task.done; setDone(task.done); props.updateTask(task) }} />
            <p>{task.description}</p>
            <p id="dueDate">{task.dueDate}</p>
            <button onClick={() => props.removeTask(task)}>Delete</button>
        </div>
    )
}