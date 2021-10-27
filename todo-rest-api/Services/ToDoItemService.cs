using System.Collections.Generic;
using System;

namespace todo_rest_api
{
    public class ToDoItemService
    {
        private List<ToDoItem> todoItems = new List<ToDoItem>();
        private int lastId = 0;
        public List<ToDoItem> GetALL()
        {
            return todoItems;
        }

        public ToDoItem Create(ToDoItem item)
        {
            item.Id = ++lastId;
            todoItems.Add(item);
            return item;
        }

        public void Delete(int itemID)
        {
            foreach (ToDoItem item in todoItems)
            {
                if (item.Id == itemID)
                {
                    todoItems.Remove(item);
                    break;
                }
            }
        }

        public ToDoItem ChangeFullItem(int itemID, ToDoItem toDoItem)
        {
            toDoItem.Id = itemID;
            foreach (ToDoItem item in todoItems)
            {
                if (item.Id == itemID)
                {
                    item.Title = toDoItem.Title;
                    item.Description = toDoItem.Description;
                    item.DueDate = toDoItem.DueDate;
                    item.Done = toDoItem.Done;
                    break;
                }
            }
            return toDoItem;
        }

        public ToDoItem ChangeTitle(int itemID, string title)
        {
            ToDoItem toDoItem = new ToDoItem();
            foreach (ToDoItem item in todoItems)
            {
                if (item.Id == itemID)
                {
                    item.Title = title;
                    toDoItem = item;
                    break;
                }
            }
            return toDoItem;
        }

        public ToDoItem ChangeDescription(int itemID, string description)
        {
            ToDoItem toDoItem = new ToDoItem();
            foreach (ToDoItem item in todoItems)
            {
                if (item.Id == itemID)
                {
                    item.Description = description;
                    toDoItem = item;
                    break;
                }
            }
            return toDoItem;
        }

        public ToDoItem ChangeDate(int itemID, DateTime date)
        {
            ToDoItem toDoItem = new ToDoItem();
            foreach (ToDoItem item in todoItems)
            {
                if (item.Id == itemID)
                {
                    item.DueDate = date;
                    toDoItem = item;
                    break;
                }
            }
            return toDoItem;
        }

        public ToDoItem ChangeDone(int itemID, bool done)
        {
            ToDoItem toDoItem = new ToDoItem();
            foreach (ToDoItem item in todoItems)
            {
                if (item.Id == itemID)
                {
                    item.Done = done;
                    toDoItem = item;
                    break;
                }
            }
            return toDoItem;
        }
    }
}