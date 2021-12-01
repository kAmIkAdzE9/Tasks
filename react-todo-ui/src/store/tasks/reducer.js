import { TASKS_LOADED, TASK_DELETED, TASK_STATUS_UPDATED, TASK_CREATED } from '../types'

const defaultState = {
    tasks: []
}

export default function tasksReducer(state = defaultState, action) {
    switch (action.type) {
        case TASKS_LOADED:
            return { tasks: action.payload }
        case TASK_CREATED:
            return {
                tasks: [...state.tasks, action.payload]
            }
        case TASK_DELETED:
            return {
                tasks: state.tasks.filter(task => task.id !== action.payload.id)
            }
        case TASK_STATUS_UPDATED:
            return {
                tasks: state.tasks
                    .map(task => (task.id == action.payload.id)
                        ? action.payload
                        : task)
            }
        default:
            return state
    }
}