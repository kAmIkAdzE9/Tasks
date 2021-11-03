using System;
using System.Collections.Generic;

namespace todo_rest_api
{
    public class TaskListForTodayDTO {
        public string Title {get; set;}
        public Task Task {get; set;}

        public TaskListForTodayDTO(string title, Task task) {
            this.Title = title;
            this.Task = task;
        }
    }
}