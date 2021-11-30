import { DASHBOARD_LOADED, TASK_ADDED, TASK_DELETED, TASK_STATUS_UPDATED } from '../types'

const defaultState = {
    lists: []
}

export default function dashboardReducer(state = defaultState, action) {
    switch (action.type) {
        case DASHBOARD_LOADED:
            return { lists: action.payload }
        case TASK_ADDED:
            return {
                lists: state.lists
                    .map(list => (list.id == action.payload) ? { id: list.id, title: list.title, countOfNonDoneTasks: list.countOfNonDoneTasks + 1 } : list)
            }
        case TASK_DELETED:
            if (!action.payload.done) {
                return {
                    lists: state.lists
                        .map(list => (list.id == action.payload.id) ? { id: list.id, title: list.title, countOfNonDoneTasks: list.countOfNonDoneTasks - 1 } : list)
                }
            }
            else {
                return {lists: state.lists}
            }
        case TASK_STATUS_UPDATED:
            return {
                lists: state.lists
                    .map(list => (list.id == action.payload.id)
                        ? { id: list.id, title: list.title, countOfNonDoneTasks: list.countOfNonDoneTasks + (action.payload.done ? -1 : 1) }
                        : list)
            }
        default:
            return state
    }
}