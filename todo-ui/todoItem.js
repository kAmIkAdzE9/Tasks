"use strict";

class Task {
    constructor(title, description, date, done) {
        if (typeof title === 'object') {
            Object.assign(this, title);
        } else {
            this.title = title;
            this.description = description;
            this.date = date;
            this.done = done;
        }
    }

    toString() {
        return `${this.title} ${this.description} ${this.date} ${this.done}`;
    }
}

let tasks = [
    new Task('task1', 'this is task 1', '2021-11-15', true),
    new Task('task2', 'this is task 2', '2021-11-18', false),
    new Task('task3', '', '2021-11-17', false),
    new Task('task4', 'this is task 4', '', false),
    new Task('task5', '', '2021-11-17', false),
    new Task('task6', 'this is task 6', '2021-11-17', false),
    new Task('task7', 'this is task 7', new Date('2021-11-15'), true),
    new Task('task8', 'this is task 8', '2021-11-14', true),
    new Task('task9', 'this is task 9', '', false)
]

const tasksElement = document.getElementById('tasks');

function appendTask(task) {
    const { title, description, date, done } = task;

    let container = document.createElement('div');
    container.classList.add('task');

    let task_title = document.createElement('h2');
    task_title.innerText = title;

    container.appendChild(task_title);

    let task_date = document.createElement('p');
    if (done != undefined && done != null) {
        let label = document.createElement('label');
        label.innerText = 'Done: ';
        let task_done = document.createElement('input');
        task_done.type = "checkbox";

        if (done) {
            task_done.checked = true;
            container.classList.add('task-done')
        }

        task_done.onclick = function () {
            container.classList.toggle('task-done');
            if (task_done.checked) {
                task.done = true;
                task_date.classList.remove('expired-date');
            }
            else {
                tasks.find(t => t == task).done = false;
                if (new Date() > new Date(date).setHours(23, 59, 59)) {
                    task_date.classList.add('expired-date');
                }
            }
        }

        container.appendChild(label);
        container.appendChild(task_done);
    }

    if (description != undefined && description != null && description != '') {
        let task_description = document.createElement('p');
        task_description.innerText = description;
        container.appendChild(task_description);
    }

    if (date != undefined && date != null && date != '') {
        task_date.innerText = getStringOfDate(new Date(date));
        container.appendChild(task_date);
    }

    let deleteButton = document.createElement('button');
    deleteButton.innerText = 'Delete';
    deleteButton.onclick = (event) => {
        deleteTask(event, task);
    }
    container.appendChild(deleteButton);

    tasksElement.appendChild(container);
}

function deleteTask(event, task) {
    const target = event.target;
    let index = tasks.indexOf(task);
    tasks.splice(index, 1);
    target.parentNode.remove();
}

function getStringOfDate(date) {
    return `${date.getDate()}.${1 + date.getMonth()}.${date.getFullYear()}`;
}

tasks.forEach(appendTask);

function updateTaskVisionMode() {
    document.getElementById('tasks').classList.toggle('hide-done-task');
}

let taskForm = document.forms['task'];

taskForm.addEventListener('submit', (event) => {
    event.preventDefault();
    let formData = new FormData(taskForm);

    let taskObj = Object.fromEntries(formData.entries());
    taskObj.title = taskObj.title.trim();
    if(taskObj.title != '') {
        let task = new Task(taskObj);
        tasks.push(task);
        appendTask(task);
        taskForm.reset();
    }
})