using System;

namespace todo_rest_api
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Done { get; set; }
        public int TaskListId {get; set;}
    }
}