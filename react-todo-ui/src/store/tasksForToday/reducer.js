import { TASKS_FOR_TODAY_LOADED, TASK_STATUS_UPDATED } from '../types'

const defaultState = {
    tasksForToday: []
}

export default function tasksReducer(state = defaultState, action) {
    switch (action.type) {
        case TASKS_FOR_TODAY_LOADED:
            return { tasksForToday: action.payload }
        case TASK_STATUS_UPDATED:
            return {
                tasksForToday: state.tasksForToday.filter(task => task.id !== action.payload.id)
            }
        default:
            return state
    }
}