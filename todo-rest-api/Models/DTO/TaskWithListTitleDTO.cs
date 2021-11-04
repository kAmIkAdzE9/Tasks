using System;

namespace todo_rest_api
{
    public class TaskWithListTitleDTO {
        public int TaskListId {get; set;}
        public string ListTitle{get; set;}
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Done { get; set; }
    }
}