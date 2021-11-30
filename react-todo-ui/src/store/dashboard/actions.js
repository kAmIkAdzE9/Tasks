import TaskAPI from '../../TaskAPI'
import {DASHBOARD_LOADED, TASK_ADDED, TASK_DELETED, TASK_STATUS_UPDATED} from '../types'

export const loadDashboard = dispatch => {
    TaskAPI.getAllLists().then(res => dispatch({
        type: DASHBOARD_LOADED,
        payload: res[0].listAndCountOfNonDoneTasks
    }))
}

export const updateCountOfTasksAfterAddTask = (payload) => ({type: TASK_ADDED, payload});
export const updateCountOfTasksAfterDeleteTask = (payload) => ({type: TASK_DELETED, payload});
export const updateCountOfTaskAfterUpdateTask = (taskListId, done) => ({type: TASK_STATUS_UPDATED, payload: {id: taskListId, done: done}});