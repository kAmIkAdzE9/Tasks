import React from "react";
import { useState, useEffect } from "react";
import TasksForToday from "../TasksForToday/TasksForToday";
import TaskAPI from "../../TaskAPI";

export default function TodayTasksPage() {
    const [tasksForToday, setTasksForToday] = useState([]);

    useEffect(() => { TaskAPI.getTasksFoToday().then(res => setTasksForToday(res)) }, [])

    function removeTaskForToday(id) {
        setTasksForToday(tasksForToday.filter(task => task.id !== id));
    }

    return (
        <div>
            <TasksForToday tasks={tasksForToday} removeTask={removeTaskForToday} />
        </div>
    )
}