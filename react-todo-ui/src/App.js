import './App.css';
import Tasks from './components/Tasks/Tasks'
import TaskForm from './components/TaskForm/TaskForm'
import Lists from './components/Lists/Lists'

function App() {
  const tasks = [
    {
      id: '1',
      title: 'task 1',
      description: 'this is task 1',
      dueDate: '24.11.2021',
      done: false,
      taskListId: '1'
    },
    {
      id: '2',
      title: 'task 2',
      description: 'this is task 2',
      dueDate: '24.11.2021',
      done: true,
      taskListId: '1'
    },
    {
      id: '3',
      title: 'task 3',
      description: 'this is task 3',
      dueDate: '24.11.2021',
      done: false,
      taskListId: '1'
    },
    {
      id: '4',
      title: 'task 4',
      description: 'this is task 4',
      dueDate: '24.11.2021',
      done: true,
      taskListId: '2'
    },
    {
      id: '5',
      title: 'task 5',
      description: 'this is task 5',
      dueDate: '24.11.2021',
      done: false,
      taskListId: '2'
    }
  ]

  const lists = [
    {
      id: '1',
      title: 'Global task 1',
      count: '3'
    },
    {
      id: '2',
      title: 'Global task 2',
      count: '2'
    }
  ]
  return (
    <div className="App">
      <div id="app-lists">
        <Lists lists={lists}/>
      </div>
      <div>
        <Tasks tasks={tasks}/>
        <TaskForm/>
      </div>
    </div>
  );
}

export default App;
