using System;
using System.Collections.Generic;

namespace todo_rest_api
{
    public class TaskListDTO {
        public string Title {get; set;}
        public List<Task> Tasks {get; set;}

        public TaskListDTO(string title, List<Task> tasks) {
            this.Title = title;
            this.Tasks = tasks;
        }
    }
}