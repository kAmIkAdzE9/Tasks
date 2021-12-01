import React from "react";
import './TaskForm.css'

export default function TaskForm(props) {

    function handleSubmit(event) {
        event.preventDefault();
        let formData = new FormData(event.target);
        let task = Object.fromEntries(formData.entries());
        task.title = task.title.trim();
        task.dueDate = new Date(task.dueDate);
        task.id = '0';
        task.taskListId = props.listId;
        if (task.title !== '') {
            props.onSubmit(task);
        }
    }

    return (
        <form id="task-form" name="task" onSubmit={handleSubmit}>
            <input required type="text" name="title" placeholder="Title" />
            <input type="text" name="description" placeholder="Description" />
            <input type="date" name="dueDate" placeholder="Date" />
            <button type="submit">Add</button>
        </form>
    );
}