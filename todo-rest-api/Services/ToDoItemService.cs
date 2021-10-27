using System.Collections.Generic;

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

        public ToDoItem ChangeDone(int itemID)
        {
            ToDoItem toDoItem = new ToDoItem();
            foreach (ToDoItem item in todoItems)
            {
                if (item.Id == itemID)
                {
                    item.Done = !item.Done;
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

        public void Delete(int itemID) {
            foreach (ToDoItem item in todoItems)
            {
                if (item.Id == itemID)
                {
                    todoItems.Remove(item);
                    break;
                }
            }
        }
    }
}