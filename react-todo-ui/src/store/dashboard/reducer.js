import { DASHBOARD_LOADED, TASK_DELETED, TASK_STATUS_UPDATED, TASK_CREATED } from '../types'

const defaultState = {
    lists: []
}

function changeCount({ countOfNonDoneTasks, ...list }, diff) {
    countOfNonDoneTasks = countOfNonDoneTasks + diff;
    return {
        ...list, countOfNonDoneTasks
    }
}

export default function dashboardReducer(state = defaultState, action) {
    switch (action.type) {
        case DASHBOARD_LOADED:
            return { lists: action.payload }
        case TASK_CREATED:
            return {
                lists: state.lists
                    .map(list => (list.id == action.payload.taskListId)
                        ? changeCount(list, 1)
                        : list)
            }
        case TASK_DELETED:
            if (!action.payload.done) {
                return {
                    lists: state.lists
                        .map(list => (list.id == action.payload.taskListId)
                            ? changeCount(list, -1)
                            : list)
                }
            }
            else {
                return { lists: state.lists }
            }
        case TASK_STATUS_UPDATED:
            return {
                lists: state.lists
                    .map(list => (list.id == action.payload.taskListId)
                        ? changeCount(list, action.payload.done ? -1 : 1)
                        : list)
            }
        default:
            return state
    }
}