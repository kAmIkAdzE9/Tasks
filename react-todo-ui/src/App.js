import './App.css';
import Tasks from './components/Tasks/Tasks'
import TaskForm from './components/TaskForm/TaskForm'
import Lists from './components/Lists/Lists'
import TaskAPI from './TaskAPI';
import { useEffect, useState } from 'react';

function App() {

  const [tasks, setTasks] = useState([]);
  const [lists, setLists] = useState([]);
  const [activeList, setActiveList] = useState({id:'1'});

  useEffect(() => { updateList() }, [])

  function updateList() {
    TaskAPI.getAllLists().then(res => setLists(res[0].listAndCountOfNonDoneTasks));
  }

  function renderTasks(listId) {
    TaskAPI.getTasksFromList(listId).then(res => setTasks(res));
  }

  function listOnClickHandler(id) {
    setActiveList(lists.filter(l => l.id === id)[0]);
    renderTasks(id);
  }

  function removeTask(id) {
    setTasks(tasks.filter(task => task.id !== id));
  }

  function addTask(res) {
    setTasks(
      [
        ...tasks,
        res
      ])
  }

  return (
    <div className="App">
      <div id="app-sidebar">
        <Lists lists={lists} listOnClickHandler={listOnClickHandler} />
      </div>
      <div id="app-content">
        <Tasks tasks={tasks} removeTask={removeTask} />
        <TaskForm addTask={addTask} activeList={activeList} setActiveList={setActiveList}/>
      </div>
    </div>
  );
}

export default App;
