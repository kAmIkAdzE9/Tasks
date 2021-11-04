using System;

namespace todo_rest_api
{
    public class ListAndCountOfNonDoneTasksDTO {
            public int Id {get; set;}
            public string Title {get; set;}
            public int CountOfNonDoneTasks {get; set;}

            public ListAndCountOfNonDoneTasksDTO () {

            }

            public ListAndCountOfNonDoneTasksDTO (int id, string title, int countOfNonDoneTasks) {
                this.Id = id;
                this.Title = title;
                this.CountOfNonDoneTasks = countOfNonDoneTasks;
            }
        }
}