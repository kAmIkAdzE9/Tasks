using System.Collections.Generic;

namespace todo_rest_api
{
    public class ListWithoutTasksDTO
    {
        public int Id {get;set;}
        public string Title { get; set; }

        public ListWithoutTasksDTO(int id, string title) {
            this.Id = id;
            this.Title = title;
        }
    }
}