import TaskAPI from '../../TaskAPI'
import {TASK_LOADED} from '../types'

export const loadTasks = dispatch => id => {
    TaskAPI.getTasksFromList(id).then(res => dispatch({
        type: TASK_LOADED,
        payload: res
    }))
}