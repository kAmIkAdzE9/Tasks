using System;
using System.Collections.Generic;

namespace todo_rest_api
{
    public class ListInfoDTO {
        public int TasksCountForToday {get; set;}
        public List<ListAndCountOfNonDoneTasksDTO> ListAndCountOfNonDoneTasks {get; set;}

        public ListInfoDTO(int tasksCountForToday, List<ListAndCountOfNonDoneTasksDTO> listAndCountOfNonDoneTasks) {
            this.TasksCountForToday = tasksCountForToday;
            this.ListAndCountOfNonDoneTasks = listAndCountOfNonDoneTasks;
        }
    }
}