const listId = 1;

class Task {
    constructor(title, description, dueDate, done) {
        if (typeof title === 'object') {
            if (title.id != null && title.id != undefined && title.id != 0 && typeof (title.id) == 'number') {
                this.id = this.id;
            }
            else {
                this.id = 0;
            }
            this.title = title.title;
            this.description = title.description;
            this.dueDate = title.dueDate;
            if (title.done == true || title.done == 'true') {
                this.done = true;
            }
            else {
                this.done = false;
            }
        }
        else {
            this.id = 0;
            this.title = title;
            this.description = description;
            this.dueDate = dueDate;
            this.done = done;
        }
        this.taskListId = listId;
    }

    toString() {
        return `${this.title} ${this.description} ${this.dueDate} ${this.done}`;
    }
}

// let tasks = [
//     new Task('task1', 'this is task 1', '2021-11-15', true),
//     new Task('task2', 'this is task 2', '2021-11-18', false),
//     new Task('task3', '', '2021-11-17', false),
//     new Task('task4', 'this is task 4', '', false),
//     new Task('task5', '', '2021-11-17', false),
//     new Task('task6', 'this is task 6', '2021-11-17', false),
//     new Task('task7', 'this is task 7', new Date('2021-11-15'), true),
//     new Task('task8', 'this is task 8', '2021-11-14', true),
//     new Task('task9', 'this is task 9', '', false)
// ]

const tasksElement = document.getElementById('tasks');

function appendTask(task) {
    const { title, description, dueDate, done } = task;

    let container = document.createElement('div');
    container.classList.add('task');

    let task_title = document.createElement('h2');
    task_title.innerText = title;

    container.appendChild(task_title);

    let task_date = document.createElement('p');

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
            task.done = false;
            if (new Date() > new Date(dueDate).setHours(23, 59, 59)) {
                task_date.classList.add('expired-date');
            }
        }
        partialUpdateTask(tasksEndpoint, task);
    }

    container.appendChild(label);
    container.appendChild(task_done);

    if (description != undefined && description != null && description != '') {
        let task_description = document.createElement('p');
        task_description.innerText = description;
        container.appendChild(task_description);
    }

    if (dueDate != undefined && dueDate != null && dueDate != '') {
        task_date.innerText = getStringOfDate(new Date(dueDate));
        container.appendChild(task_date);
    }

    let deleteButton = document.createElement('button');
    deleteButton.innerText = 'Delete';
    deleteButton.onclick = (event) => {
        deleteTask(tasksEndpoint, event, task);
    }
    container.appendChild(deleteButton);

    tasksElement.appendChild(container);
}

// tasks.forEach(appendTask);

// function deleteTask(event, task) {
//     const target = event.target;
//     let index = tasks.indexOf(task);
//     tasks.splice(index, 1);
//     target.parentNode.remove();
// }

function getStringOfDate(date) {
    return `${date.getDate()}.${1 + date.getMonth()}.${date.getFullYear()}`;
}

function updateTaskVisionMode() {
    document.getElementById('tasks').classList.toggle('hide-done-task');
}

let taskForm = document.forms['task'];

//endpoints
const tasksEndpoint = 'http://localhost:5000/tasks';
const tasksGetEndpoint = 'http://localhost:5000/lists/1';


taskForm.addEventListener('submit', (event) => {
    event.preventDefault();
    let formData = new FormData(taskForm);

    let taskObj = Object.fromEntries(formData.entries());
    taskObj.title = taskObj.title.trim();
    if (taskObj.title != '') {
        let task = new Task(taskObj);
        // tasks.push(task);
        // appendTask(task);
        // taskForm.reset();

        createTask(tasksEndpoint, task)
            .then(appendTask)
            .then(_ => taskForm.reset())
    }
})


function createTask(tasksPostEndpoint, task) {
    return fetch(tasksPostEndpoint, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(task)
    })
    .then(response => response.json())
}

function readTask(tasksGetEndpoint) {
    return fetch(tasksGetEndpoint)
        .then(response => response.json())
        .then(tasks => tasks.forEach(appendTask))
}
readTask(tasksGetEndpoint);


function deleteTask(tasksEndpoint, event, task) {
    const target = event.target;
    target.parentNode.remove();
    let taskDeleteEndpoint = `${tasksEndpoint}?taskId=${task.id}`;

    fetch(taskDeleteEndpoint, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(response => console.log(response.statusText))
}

function partialUpdateTask(tasksEndpoint, task) {
    let taskPatchEndpoint = `${tasksEndpoint}?taskId=${task.id}`;
    fetch(taskPatchEndpoint, {
        method: 'PATCH',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(task)
    })
    .then(response => console.log(response.statusText));
}
