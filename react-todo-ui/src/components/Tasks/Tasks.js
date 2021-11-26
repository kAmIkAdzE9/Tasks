import React from "react";
import './Tasks.css'
import { Task } from "../Task/Task";
import { useEffect } from "react";

export default function Tasks(props) {
    return (
        <div className="tasks">
            {props.tasks.map(task =><Task key={task.id} task={task} removeTask={props.removeTask} updateTask={props.updateTask}/>) }
        </div>
    )
}