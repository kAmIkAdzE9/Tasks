using System.Collections.Generic;
using System;
using System.Linq;

namespace todo_rest_api
{
    public class ListInfoService
    {
        private ToDoListContext _context;

        public ListInfoService(ToDoListContext context)
        {
            this._context = context;
        }

        public List<ListInfoDTO> GetListInfo() {
            List<ListInfoDTO> list = new List<ListInfoDTO>();
            list.Add(new ListInfoDTO(GetTasksCountForToday(), GetAllListWithCountOfNonDoneTasks()));
            return list;
        }

        private int GetTasksCountForToday()
        {
            return _context.Tasks.Where(t => (t.DueDate >= DateTime.Today) && (t.DueDate < DateTime.Today.AddDays(1))).Count();
        }

        private int GetCountOfNonDoneTasks(TaskList taskList)
        {
            int counter = 0;
            foreach (Task task in _context.Tasks)
            {
                if ((task.Done == false) && (task.TaskListId == taskList.Id))
                {
                    counter++;
                }
            }
            return counter;
        }

        private List<ListAndCountOfNonDoneTasksDTO> GetAllListWithCountOfNonDoneTasks()
        {
            List<ListAndCountOfNonDoneTasksDTO> list = new List<ListAndCountOfNonDoneTasksDTO>();
            List<TaskList> taskLists = _context.TaskLists.ToList();
            foreach (TaskList taskList in taskLists)
            {
                list.Add(new ListAndCountOfNonDoneTasksDTO(taskList.Id, taskList.Title, GetCountOfNonDoneTasks(taskList)));
            }
            return list;
        }
    }
}