import TaskAPI from '../../TaskAPI'
import { TASKS_LOADED, TASK_CREATED, TASK_DELETED, TASK_STATUS_UPDATED } from '../types'

export const loadTasks = (id) => (dispatch) => {
    TaskAPI.getTasksFromList(id)
        .then(res => dispatch({
            type: TASKS_LOADED,
            payload: res
        }))
}

export const createTask = task => (dispatch) => {
    TaskAPI.createTask(task)
        .then(res => dispatch({
            type: TASK_CREATED,
            payload: res
        }))
}

export const deleteTask = task => (dispatch) => {
    TaskAPI.deleteTask(task.id)
        .then(() => dispatch({
            type: TASK_DELETED,
            payload: task
        }))
}

export const updateTask = task => (dispatch) => {
    TaskAPI.partialUpdateTask(task)
        .then(res => dispatch({
            type: TASK_STATUS_UPDATED,
            payload: res
        }))
}