import TaskAPI from '../../TaskAPI'
import {TASKS_LOADED} from '../types'

export const loadTasks = dispatch => id => {
    TaskAPI.getTasksFromList(id).then(res => dispatch({
        type: TASKS_LOADED,
        payload: res
    }))
}