import TaskAPI from '../../TaskAPI'
import {DASHBOARD_LOADED} from '../types'

export const loadDashboard = dispatch => {
    TaskAPI.getAllLists().then(res => dispatch({
        type: DASHBOARD_LOADED,
        payload: res[0].listAndCountOfNonDoneTasks
    }))
}