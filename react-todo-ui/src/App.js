import './App.css';
import TaskAPI from './TaskAPI';
import Lists from './components/Lists/Lists';
import TodayTasksPage from './components/TodayTasksPage/TodayTasksPage';
import ToDoListPage from './components/ToDoListPage/ToDoListPage';
import { useEffect, useState } from 'react';
import { Routes, Route, Link} from "react-router-dom";

export default function App() {
  const [lists, setLists] = useState([]);

  useEffect(() => { TaskAPI.getAllLists().then(res => setLists(res[0].listAndCountOfNonDoneTasks)) }, [])

  return (
    <div className="App">
      <div id="app-sidebar">
        <Lists lists={lists}/>
      </div>
      <div id="app-content">
        <nav>
          <Link to={`/todo-list/1`}>Tasks</Link> |{" "}
          <Link to="/today">Tasks For Today</Link>
        </nav>
        <Routes>
          <Route path="/todo-list/:id" element={<ToDoListPage />} />
          <Route path="/today" element={<TodayTasksPage />} />
        </Routes>
      </div>
    </div >
  );
}