import {createStore, combineReducers, applyMiddleware} from 'redux';
import {composeWithDevTools} from 'redux-devtools-extension';
import thunk from "redux-thunk";
import dashboardReducer from './dashboard/reducer'
import tasksReducer from './tasks/reducer'

export const rootReducer = combineReducers({
    dashboard: dashboardReducer
})

export const store = createStore(rootReducer, composeWithDevTools(applyMiddleware(thunk)));