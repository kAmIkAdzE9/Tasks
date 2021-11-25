import React, {useState, useEffect} from "react";
import Tasks from '../Tasks/Tasks'
import TaskForm from '../TaskForm/TaskForm';
import TaskAPI from "../../TaskAPI";
import {useParams} from "react-router";

export default function ToDoListPage(props) {
    const [tasks, setTasks] = useState([]);
    const [activeListId, setActiveListId] = useState(1);

    useEffect(() => {renderTasks(activeListId)}, []);

    function renderTasks(listId) {
        TaskAPI.getTasksFromList(listId).then(res => setTasks(res));
    }

    function removeTask(id) {
        setTasks(tasks.filter(task => task.id !== id));
    }

    function addTask(res) {
        setTasks(
            [
                ...tasks,
                res
            ])
    }
    return (
        <div>
            <Tasks tasks={tasks} removeTask={removeTask} />
            <TaskForm addTask={addTask} activeListId={activeListId} setActiveListId={setActiveListId} />
        </div>
    )
}