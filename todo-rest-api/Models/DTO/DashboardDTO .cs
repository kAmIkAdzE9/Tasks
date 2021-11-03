using System;
using System.Collections.Generic;

namespace todo_rest_api
{
    public class DashboardDTO {
        public int TasksCountForToday {get; set;}
        public List<ListAndCountOfNonDoneTasks> ListAndCountOfNonDoneTasks {get; set;}

        public DashboardDTO(int tasksCountForToday, List<ListAndCountOfNonDoneTasks> listAndCountOfNonDoneTasks) {
            this.TasksCountForToday = tasksCountForToday;
            this.ListAndCountOfNonDoneTasks = listAndCountOfNonDoneTasks;
        }
    }
}