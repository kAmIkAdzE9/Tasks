import React from "react";
import './Task.css'

export function Task(props) {
    return (
        <div className="task">
            <h2>{props.title}</h2>
            <label>Done: </label>
            <input type="checkbox">{props.done}</input>
            <p>{props.description}</p>
            <p>{props.dueDate}</p>
        </div>
    )
}

// let container = document.createElement('div');
//     container.classList.add('task');

//     let task_title = document.createElement('h2');
//     task_title.innerText = title;

//     container.appendChild(task_title);

//     let task_date = document.createElement('p');

//     let label = document.createElement('label');
//     label.innerText = 'Done: ';

//     let task_done = document.createElement('input');
//     task_done.type = "checkbox";

//     if (done) {
//         task_done.checked = true;
//         container.classList.add('task-done')
//     }

//     task_done.onclick = function () {
//         container.classList.toggle('task-done');
//         if (task_done.checked) {
//             task.done = true;
//             task_date.classList.remove('expired-date');
//         }
//         else {
//             task.done = false;
//             if (new Date() > new Date(dueDate).setHours(23, 59, 59)) {
//                 task_date.classList.add('expired-date');
//             }
//         }
//         taskApi.partialUpdateTask(task);
//     }

//     container.appendChild(label);
//     container.appendChild(task_done);