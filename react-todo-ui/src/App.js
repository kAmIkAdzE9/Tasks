import './App.css';
import Lists from './components/Lists/Lists';
import ToDoListPage from './components/ToDoListPage/ToDoListPage';
import TaskAPI from './TaskAPI';
import { useEffect, useState } from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Routes,
  Route,
  Link,
  useParams,
  Outlet
} from "react-router-dom";

export default function App() {
  const [lists, setLists] = useState([]);
  const [activeListId, setActiveListId] = useState(1);

  useEffect(() => {TaskAPI.getAllLists().then(res => setLists(res[0].listAndCountOfNonDoneTasks))}, [])

  function listOnClickHandler(id) {
    setActiveListId(id);
    //update tasks in toDoListPage
  }

  return (
    <div className="App">
      <div id="app-sidebar">
        <Lists lists={lists} listOnClickHandler={listOnClickHandler} />
      </div>
      <div id="app-content">
        <nav>
          <Link to="/toDoListPage">Tasks</Link> |{" "}
          <Link to="/todayTasksPage">Tasks For Today</Link>
        </nav>
        <Outlet/>
      </div>
    </div>
  );
}