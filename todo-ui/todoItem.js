const listId = 1;
const tasksEndpoint = 'http://localhost:5000/tasks';
const tasksGetEndpoint = 'http://localhost:5000/lists/1';

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

const taskApi = {
    getAllTasks() {
        return fetch(tasksGetEndpoint)
            .then(response => response.json())
    },

    createTask(task) {
        return fetch(tasksEndpoint, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(task)
        })
            .then(response => response.json())
    },

    deleteTask(event, task) {
        let taskDeleteEndpoint = `${tasksEndpoint}?taskId=${task.id}`;
        return fetch(taskDeleteEndpoint, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then (response => response.ok ? deleteTaskFromDOM(event) : console.log(response))
    },

    partialUpdateTask(task) {
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
}

const tasksElement = document.getElementById('tasks');

function getStringOfDate(date) {
    return `${date.getDate()}.${1 + date.getMonth()}.${date.getFullYear()}`;
}

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
        taskApi.partialUpdateTask(task);
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
        taskApi.deleteTask(event, task);
    }
    container.appendChild(deleteButton);

    tasksElement.appendChild(container);
}

taskApi.getAllTasks()
    .then(tasks => tasks.forEach(appendTask));

function updateTaskVisionMode() {
    document.getElementById('tasks').classList.toggle('hide-done-task');
}

let taskForm = document.forms['task'];

taskForm.addEventListener('submit', (event) => {
    event.preventDefault();
    let formData = new FormData(taskForm);

    let taskObj = Object.fromEntries(formData.entries());
    taskObj.title = taskObj.title.trim();
    taskObj.dueDate = new Date(taskObj.dueDate);
    if (taskObj.title != '') {
        let task = new Task(taskObj);
        taskApi.createTask(task)
            .then(appendTask)
            .then(_ => taskForm.reset())
    }
})

function deleteTaskFromDOM(event) {
    const target = event.target;
    target.parentNode.remove();
    console.log('OK');
}