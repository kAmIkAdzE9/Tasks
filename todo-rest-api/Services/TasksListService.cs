using System.Collections.Generic;
using System;
using System.Linq;

namespace todo_rest_api
{
    public class TasksListService
    {
        private ToDoListContext _context;

        public TasksListService(ToDoListContext context)
        {
            this._context = context;
        }

        public List<TaskList> GetAll()
        {
            return _context.TaskLists.ToList();
        }

        public List<TaskWithoutTaskListDTO> GetTasksList(int listId) {
            List<Task> tasks = _context.Tasks.Where(t => t.TaskListId == listId).ToList();
            return tasks.ConvertAll(tasks=>new TaskWithoutTaskListDTO(tasks.Id, tasks.Title, tasks.Description, tasks.DueDate, tasks.Done, tasks.TaskListId));
        }

        public TaskWithoutTaskListDTO GetItemFromList(int taskId)
        {
            foreach (Task task in _context.Tasks)
            {
                if (task.Id == taskId)
                { return new TaskWithoutTaskListDTO(task.Id, task.Title, task.Description, task.DueDate, task.Done, task.TaskListId); }
            }
            return null;
        }

        public void CreateTasksList(string title)
        {
            _context.TaskLists.Add(new TaskList(title));
            _context.SaveChanges();
        }

        public Task CreateTaskInList(TaskWithoutTaskListDTO task)
        {
            if(_context.TaskLists.Where(l => l.Id == task.TaskListId).Count() == 1) {
                Task entity = new Task
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    Done = task.Done,
                    TaskListId = task.TaskListId
                };
                _context.Tasks.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            return null;
        }

        public void DeleteList(int listId)
        {
            foreach (TaskList taskList in _context.TaskLists)
            {
                if (taskList.Id == listId)
                {
                    _context.TaskLists.Remove(taskList);
                    break;
                }
            }
            _context.SaveChanges();
        }

        public void DeleteItemFromList(int taskId)
        {
            foreach (Task task in _context.Tasks)
            {
                if (task.Id == taskId)
                {
                    _context.Tasks.Remove(task);
                    break;
                }
            }
            _context.SaveChanges();
        }

        public TaskWithoutTaskListDTO ReplaceItem(int taskId, TaskWithoutTaskListDTO task)
        {
            TaskWithoutTaskListDTO outputTask = null;
            foreach (Task item in _context.Tasks)
            {
                if (item.Id == taskId)
                {
                    item.Title = task.Title;
                    item.Description = task.Description;
                    item.DueDate = task.DueDate;
                    item.Done = task.Done;
                    outputTask = new TaskWithoutTaskListDTO(item.Id, item.Title, item.Description, item.DueDate, item.Done, item.TaskListId);
                    break;
                }
            }
            _context.SaveChanges();
            return outputTask;
        }

        public TaskWithoutTaskListDTO PartialUpdate(int taskId, TaskWithoutTaskListDTO task)
        {
            TaskWithoutTaskListDTO outputTask = null;
            foreach (Task item in _context.Tasks)
            {
                if (item.Id == taskId)
                {
                    if (task.Title != null || task.Title != "")
                    {
                        item.Title = task.Title;
                    }
                    if (task.Description != null || task.Description != "")
                    {
                        item.Description = task.Description;
                    }
                    if (task.DueDate != null)
                    {
                        item.DueDate = task.DueDate;
                    }
                    if (task.Done != item.Done)
                    {
                        item.Done = task.Done;
                    }
                    outputTask = new TaskWithoutTaskListDTO(item.Id, item.Title, item.Description, item.DueDate, item.Done, item.TaskListId);
                    break;
                }
            }
            _context.SaveChanges();
            return outputTask;
        } 
    }
}