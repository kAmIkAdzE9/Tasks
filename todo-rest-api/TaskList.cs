using System.Collections.Generic;

namespace todo_rest_api
{
    public class TaskList
    {
        private const string defaultTitle = "TasksListName";
        public int Id {get;set;}
        public string Title { get; set; }

        public List<Task> Tasks {get; set;}

        public TaskList()
        {
            Title = defaultTitle;
            Tasks = new List<Task>();
        }

        public TaskList(string title)
        {
            Title = title;
            Tasks = new List<Task>();
        }
    }
}