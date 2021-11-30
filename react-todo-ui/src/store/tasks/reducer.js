import { TASKS_LOADED } from '../types'

const defaultState = {
    tasks: []
}

export default function tasksReducer(state = defaultState, action) {
    switch (action.type) {
        case TASKS_LOADED:
            return { tasks: action.payload }
        default:
            return state
    }
}