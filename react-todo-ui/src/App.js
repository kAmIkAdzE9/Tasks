import './App.css';
import Lists from './components/Lists/Lists';
import TodayTasksPage from './components/TodayTasksPage/TodayTasksPage';
import ToDoListPage from './components/ToDoListPage/ToDoListPage';
import { useEffect } from 'react';
import { Routes, Route, Link } from "react-router-dom";
import { useDispatch } from 'react-redux';
import { loadDashboard } from './store/dashboard/actions'

export default function App() {
  // const [lists, setLists] = useState([]);
  // useEffect(() => { TaskAPI.getAllLists().then(res => setLists(res[0].listAndCountOfNonDoneTasks)) }, []); 

  const dispatch = useDispatch();
  useEffect(() => {
    loadDashboard(dispatch);
  }, [])

  return (
    <div className="App">
      <div id="app-sidebar">
        <Lists/>
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