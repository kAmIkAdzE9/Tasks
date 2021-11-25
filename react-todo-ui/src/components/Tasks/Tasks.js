import React from "react";
import './Tasks.css'
import { Task } from "../Task/Task";

export default function Tasks(props) {
    return (
        <div id="tasks">
            {props.tasks.map(task =><Task key={task.id} id={task.id} task={task} removeTask={props.removeTask}/>) }
        </div>
    )
}