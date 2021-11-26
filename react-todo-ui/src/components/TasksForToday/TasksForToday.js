import React from "react";
import './TasksForToday.css'
import { TaskForToday } from "../TaskForToday/TaskForToday";

export default function TasksForToday(props) {
    
    return (
        <div className="tasks">
            {props.tasks.map(task =><TaskForToday key={task.id} task={task} removeTask={props.removeTask} updateTask={props.updateTask}/>) }
        </div>
    )
}