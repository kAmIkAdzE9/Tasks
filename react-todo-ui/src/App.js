import './App.css';
import TaskAPI from './TaskAPI';
import Lists from './components/Lists/Lists';
import TodayTasksPage from './components/TodayTasksPage/TodayTasksPage';
import ToDoListPage from './components/ToDoListPage/ToDoListPage';
import { useEffect, useState } from 'react';
import { Routes, Route, Link} from "react-router-dom";

export default function App() {
  const [lists, setLists] = useState([]);
  const [activeListId, setActiveListId] = useState(1);

  useEffect(() => { TaskAPI.getAllLists().then(res => setLists(res[0].listAndCountOfNonDoneTasks)) }, [])

  function listOnClickHandler(id) {
    setActiveListId(id);
    //window.location.href = `${id}`;
  }

  return (
    <div className="App">
      <div id="app-sidebar">
        <Lists lists={lists} listOnClickHandler={listOnClickHandler} />
      </div>
      <div id="app-content">
        <nav>
          <Link className="link" to={`${activeListId}`}>Tasks</Link> |{" "}
          <Link className="link" to="/todayTasksPage">Tasks For Today</Link>
        </nav>
        <Routes>
          <Route path="/:id" element={<ToDoListPage />} />
          <Route path="/todayTasksPage" element={<TodayTasksPage />} />
        </Routes>
      </div>
    </div >
  );
}