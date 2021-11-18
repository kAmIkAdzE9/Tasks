using System;

namespace todo_rest_api
{
    public class TaskWithoutTaskListDTO
    {
        public int Id {get; set;}
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Done { get; set; }
        public int TaskListId {get; set;}

        public TaskWithoutTaskListDTO(int id, string title, string description, DateTime? dueDate, bool done, int taskListId) {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.DueDate = dueDate;
            this.Done = done;
            this.TaskListId = taskListId;
        }
    }
}