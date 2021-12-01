import React, { useState, useEffect } from "react";
import './ToDoListPage.css'
import Tasks from '../Tasks/Tasks'
import TaskForm from '../TaskForm/TaskForm';
import { useParams } from "react-router";
import { useDispatch, useSelector} from "react-redux";
import { loadTasks, createTask, deleteTask, updateTask } from "../../store/tasks/actions";
import { useActionCreator } from "../../store/actionCreator";

export default function ToDoListPage() {
    const { id } = useParams();
    const [isVisibleDoneTasks, setIsVisibleDoneTasks] = useState(false);

    const dispatch = useDispatch();
    useEffect(() => {
        dispatch(loadTasks(id));
    }, [id])

    const tasks = useSelector(state => state.tasks.tasks);
    const filteredTasks = isVisibleDoneTasks ? tasks : tasks.filter(t => t.done === false);
    const handleSubmit = useActionCreator(createTask);
    const removeTask = useActionCreator(deleteTask);
    const toggleTask = useActionCreator(updateTask);
    
    return (
        <div>
            <div id='show-all-tasks'>
                <label>Show All Tasks</label>
                <input type='checkbox' onClick={() => setIsVisibleDoneTasks(!isVisibleDoneTasks)} />
            </div>

            <Tasks tasks={filteredTasks} removeTask={removeTask} updateTask={toggleTask} />
            <TaskForm onSubmit={handleSubmit} listId={id} />
        </div>
    )
}