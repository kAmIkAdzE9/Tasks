import React from "react";
import './TaskForm.css'

export default function TaskForm(props) {
    return (
        <form id="task-form" name="task" onSubmit={props.createTask}>
            <input required type="text" name="title" placeholder="Title" />
            <input type="text" name="description" placeholder="Description" />
            <input type="date" name="dueDate" placeholder="Date" />
            <button type="submit">Add</button>
        </form>
    );
}