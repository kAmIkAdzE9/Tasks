using System.Collections.Generic;
using System;
using System.Linq;

namespace todo_rest_api
{
    public class TasksListService
    {
        private Dictionary<int, TaskList> dictionary = new Dictionary<int, TaskList>();
        int lastId = 0;

        public List<TaskList> GetAll()
        {
            return dictionary.Values.ToList();
        }

        
        public List<Task> GetList(int listId)
        {
            List<Task> taskList = new List<Task>();
            if (dictionary.ContainsKey(listId))
            {
                taskList = dictionary[listId].Tasks;
                return taskList;
            }
            return null;
        }

        public Task GetItemFromList(int listId, int taskId)
        {
            if (dictionary.ContainsKey(listId))
            {
                foreach (Task item in dictionary[listId].Tasks)
                {
                    if (item.Id == taskId)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public void CreateTasksList(string title)
        {
            TaskList taskList = new TaskList(title);
            dictionary.Add(++lastId, taskList);
        }

        public bool CreateTaskInList(int listId, Task task)
        {
            if (dictionary.ContainsKey(listId))
            {
                int count = dictionary[listId].Tasks.Count;
                if (count > 0)
                {
                    task.Id = dictionary[listId].Tasks[count - 1].Id + 1;
                }
                else
                {
                    task.Id = 1;
                }
                dictionary[listId].Tasks.Add(task);
                return true;
            }
            return false;
        }

        public bool DeleteList(int listId)
        {
            if (dictionary.ContainsKey(listId))
            {
                dictionary.Remove(listId);
                return true;
            }
            return false;
        }
        
        public bool DeleteItemFromList(int listId, int taskId)
        {
            if (dictionary.ContainsKey(listId))
            {
                foreach (Task item in dictionary[listId].Tasks)
                {
                    if (item.Id == taskId)
                    {
                        dictionary[listId].Tasks.Remove(item);
                        return true;
                    }
                }         
            }
            return false;
        }

        public bool ReplaceItem(int listId, int taskId, Task task)
        {
            task.Id = taskId;
            if (dictionary.ContainsKey(listId))
            {
                foreach (Task item in dictionary[listId].Tasks)
                {
                    if (item.Id == taskId)
                    {
                        item.Title = task.Title;
                        item.Description = task.Description;
                        item.DueDate = task.DueDate;
                        item.Done = task.Done;
                        return true;
                    }
                }         
            }
            return false;
        }

        public bool PartialUpdate(int listId, int taskId, Task task)
        {
            task.Id = taskId;
            if (dictionary.ContainsKey(listId))
            {
                foreach (Task item in dictionary[listId].Tasks)
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
                        return true;;
                    }
                }
            }
            return false;
        }
    }
}