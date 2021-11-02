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

        public Task GetItemFromList(int taskId)
        {
            foreach (Task task in _context.Tasks)
            {
                if (task.Id == taskId)
                { return task; }
            }
            return null;
        }

        public void CreateTasksList(string title)
        {
            _context.TaskLists.Add(new TaskList(title));
            _context.SaveChanges();
        }

        public Task CreateTaskInList(Task task)
        {
            bool flag = false;
            foreach (TaskList taskList in _context.TaskLists)
            {
                if (taskList.Id == task.TaskListId)
                {
                    flag = true;
                }
            }

            if (flag)
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
                return task;
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

        public Task ReplaceItem(int taskId, Task task)
        {
            Task outputTask = null;
            foreach (Task item in _context.Tasks)
            {
                if (item.Id == taskId)
                {
                    item.Title = task.Title;
                    item.Description = task.Description;
                    item.DueDate = task.DueDate;
                    item.Done = task.Done;
                    outputTask = item;
                    break;
                }
            }
            _context.SaveChanges();
            return outputTask;
        }

        public Task PartialUpdate(int taskId, Task task)
        {
            Task outputTask = null;
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
                    outputTask = item;
                    break;
                }
            }
            _context.SaveChanges();
            return outputTask;
        }
    }
}