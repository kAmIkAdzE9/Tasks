const tasksEndpoint = 'http://localhost:5000/tasks';
const dashboardEndpoint = 'http://localhost:5000/dashboard';
const collectionTodayEndpoint = 'http://localhost:5000/collection/today';
const tasksGetEndpoint = 'http://localhost:5000/lists';

const TaskAPI = {
    getAllLists() {
        return fetch(dashboardEndpoint)
            .then (response => response.ok ? response.json() : console.log(response))
    },

    getTasksFromList(listId) {
        return fetch(`${tasksGetEndpoint}/${listId}`)
            .then (response => response.ok ? response.json() : console.log(response))
    },

    getTasksFoToday() {
        return fetch(collectionTodayEndpoint)
            .then (response => response.ok ? response.json() : console.log(response))
    },

    createTask(task) {
        return fetch(tasksEndpoint, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(task)
        })
        .then (response => response.ok ? response.json() : console.log(response))
    },

    deleteTask(id) {
        return fetch(`${tasksEndpoint}?taskId=${id}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        })
    },

    partialUpdateTask(task) {
        return fetch(`${tasksEndpoint}?taskId=${task.id}`, {
            method: 'PATCH',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(task)
        })
            .then(response => response.ok ? response.json() : console.log(response))
    }
}

export default TaskAPI