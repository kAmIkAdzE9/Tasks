import TaskAPI from '../../TaskAPI'
import { TASKS_FOR_TODAY_LOADED } from '../types'

export const loadTasks = (dispatch) => {
    TaskAPI.getTasksForToday()
        .then(res => dispatch({
            type: TASKS_FOR_TODAY_LOADED,
            payload: res
        }))
}