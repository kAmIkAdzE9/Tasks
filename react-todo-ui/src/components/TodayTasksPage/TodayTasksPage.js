import React from "react";
import { useEffect } from "react";
import TasksForToday from "../TasksForToday/TasksForToday";
import { useDispatch, useSelector } from "react-redux";
import { deleteTask, updateTask } from "../../store/tasks/actions";
import { loadTasks } from "../../store/tasksForToday/actions";
import { useActionCreator } from "../../store/actionCreator";

export default function TodayTasksPage() {
    const dispatch = useDispatch();
    useEffect(() => {
        dispatch(loadTasks);
    }, [])

    const tasksForToday = useSelector(state => state.tasksForToday.tasksForToday);
    const removeTask = useActionCreator(deleteTask);
    const toggleTask = useActionCreator(updateTask);

    return (
        <div>
            <TasksForToday tasks={tasksForToday} removeTask={removeTask} updateTask={toggleTask} />
        </div>
    )
}