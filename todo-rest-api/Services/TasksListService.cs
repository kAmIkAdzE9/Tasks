using System.Collections.Generic;
using System;

namespace todo_rest_api
{
    public class TasksListService
    {
        private Dictionary<int, TaskList> dictionary = new Dictionary<int, TaskList>();
        int lastId = 0;

        public Dictionary<int, TaskList> GetAll()
        {
            return dictionary;
        }
        public TaskList GetAllFromList(int listId)
        {
            TaskList taskList = new TaskList();
            if (dictionary.ContainsKey(listId))
            {
                taskList = dictionary[listId];
            }
            return taskList;
        }

        public Task GetItemFromList(int listId, int taskId)
        {
            Task task = new Task();
            if (dictionary.ContainsKey(listId))
            {
                foreach (Task item in dictionary[listId].TasksList)
                {
                    if (item.Id == taskId)
                    {
                        task = item;
                        break;
                    }
                }
            }
            return task;
        }

        public void CreateTasksList(string title)
        {
            TaskList taskList = new TaskList(title);
            dictionary.Add(++lastId, taskList);
        }

        public void CreateTaskInList(int listId, Task task)
        {
            if (dictionary.ContainsKey(listId))
            {
                int count = dictionary[listId].TasksList.Count;
                if (count > 0)
                {
                    task.Id = dictionary[listId].TasksList[count - 1].Id + 1;
                }
                else
                {
                    task.Id = 1;
                }
                dictionary[listId].TasksList.Add(task);

            }
        }

        public void DeleteList(int listId)
        {
            if (dictionary.ContainsKey(listId))
            {
                dictionary.Remove(listId);
            }

        }
        
        public void DeleteItemFromList(int listId, int taskId)
        {
            if (dictionary.ContainsKey(listId))
            {
                foreach (Task item in dictionary[listId].TasksList)
                {
                    if (item.Id == taskId)
                    {
                        dictionary[listId].TasksList.Remove(item);
                        break;
                    }
                }
            }
        }

        public void ReplaceItem(int listId, int taskId, Task task)
        {
            task.Id = taskId;
            if (dictionary.ContainsKey(listId))
            {
                foreach (Task item in dictionary[listId].TasksList)
                {
                    if (item.Id == taskId)
                    {
                        item.Title = task.Title;
                        item.Description = task.Description;
                        item.DueDate = task.DueDate;
                        item.Done = task.Done;
                        break;
                    }
                }
            }
        }

        public void PartialUpdate(int listId, int taskId, Task task)
        {
            task.Id = taskId;
            if (dictionary.ContainsKey(listId))
            {
                foreach (Task item in dictionary[listId].TasksList)
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
                        break;
                    }
                }
            }
        }
    }
}