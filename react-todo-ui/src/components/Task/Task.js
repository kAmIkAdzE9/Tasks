import React, { useState } from "react";
import './Task.css'
import TaskAPI from "../../TaskAPI";

export function Task(props) {
    const task = props.task;
    const [done, setDone] = useState(task.done);
    let classes = ['task'];

    if(task.done) {
        classes.push('task-done');
    }

    function deleteTask() {
        TaskAPI.deleteTask(task.id);
        props.removeTask(task.id);
    }

    function updateTask(event) {
        task.done = !task.done;
        setDone(task.done);

        TaskAPI.partialUpdateTask(task);

        if(task.done) {
            classes.push('task-done');
        }
        else {
            classes.pop();
        }
        event.target.parentElement.className = classes.join(" ");
    }

    return (
        <div className={classes.join(" ")}>
            <h2>{task.title}</h2>
            <label>Done: </label>
            <input type="checkbox" checked={done} onChange={updateTask}/>
            <p>{task.description}</p>
            <p id="dueDate">{task.dueDate}</p>
            <button onClick={deleteTask}>Delete</button>
        </div>
    )
}