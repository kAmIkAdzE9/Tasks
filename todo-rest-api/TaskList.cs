using System.Collections.Generic;

namespace todo_rest_api
{
    public class TaskList
    {
        private const string defaultTitle = "TasksListName";
        public string Title { get; set; }
        public List<Task> TasksList { get; set; }

        public TaskList()
        {
            Title = defaultTitle;
            TasksList = new List<Task>();
        }

        public TaskList(string title)
        {
            Title = title;
            TasksList = new List<Task>();
        }
    }
}