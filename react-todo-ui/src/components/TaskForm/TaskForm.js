import React from "react";
import './TaskForm.css'
import TaskAPI from "../../TaskAPI";

export default function TaskForm(props) {
    function onSubmitHandler(event) {
        event.preventDefault();
        let formData = new FormData(event.target);
        let task = Object.fromEntries(formData.entries());
        task.title = task.title.trim();
        task.dueDate = new Date(task.dueDate);
        task.id = '0';
        task.taskListId = props.activeList.id;
        props.activeList.countOfNonDoneTasks++;
        props.setActiveList(props.activeList);
        if (task.title !== '') {
            TaskAPI.createTask(task)
                .then(res => props.addTask(res))
                .then(_ => event.target.reset())
        }
    }

    return (
        <form id="task-form" name="task" onSubmit={onSubmitHandler}>
            <input required type="text" name="title" placeholder="Title" />
            <input type="text" name="description" placeholder="Description" />
            <input type="date" name="dueDate" placeholder="Date" />
            <button type="submit">Add</button>
        </form>
    );
}