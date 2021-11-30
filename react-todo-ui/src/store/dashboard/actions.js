import TaskAPI from '../../TaskAPI'
import {DASHBOARD_LOADED, TASK_ADDED, TASK_DELETED} from '../types'

export const loadDashboard = dispatch => {
    TaskAPI.getAllLists().then(res => dispatch({
        type: DASHBOARD_LOADED,
        payload: res[0].listAndCountOfNonDoneTasks
    }))
}

export const updateCountOfTaskAfterAddTask = (payload) => ({type: TASK_ADDED, payload});
export const updateCountOfTaskAfterDeleteTask = (payload) => ({type: TASK_DELETED, payload});