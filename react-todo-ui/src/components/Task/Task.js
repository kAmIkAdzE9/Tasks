import React from "react";
import './Task.css'
import TaskAPI from "../../TaskAPI";

export function Task(props) {
    const task = props.task;

    function deleteTask() {
        TaskAPI.deleteTask(task.id);
        props.removeTask(task.id);
    }

    function updateTask(event) {
        task.done = !task.done;
        TaskAPI.partialUpdateTask(task);
    }

    return (
        <div className="task">
            <h2>{task.title}</h2>
            <label>Done: </label>
            <input type="checkbox" checked={task.done} onChange={updateTask}/>
            <p>{task.description}</p>
            <p>{task.dueDate}</p>
            <button onClick={deleteTask}>Delete</button>
        </div>
    )
}