import { DASHBOARD_LOADED, TASK_ADDED, TASK_DELETED } from '../types'

const defaultState = {
    lists: []
}

export default function loadDashboardReducer(state = defaultState, action) {
    switch (action.type) {
        case DASHBOARD_LOADED:
            return { lists: action.payload }
        case TASK_ADDED:
            return {lists: state.lists
                .map(list => (list.id == action.payload) ? {id: list.id, title: list.title, countOfNonDoneTasks: list.countOfNonDoneTasks + 1}: list)}
        case TASK_DELETED:
            return {lists: state.lists
                .map(list => (list.id == action.payload) ? {id: list.id, title: list.title, countOfNonDoneTasks: list.countOfNonDoneTasks - 1}: list)}
        default:
            return state
    }
}