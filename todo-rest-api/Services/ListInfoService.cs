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

        public List<DashboardDTO> GetListInfo()
        {
            List<DashboardDTO> list = new List<DashboardDTO>();
            list.Add(new DashboardDTO(GetTasksCountForToday(), GetAllListWithCountOfNonDoneTasks()));
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


        public List<TaskListForTodayDTO> GetTaskListWithNonDoneTasksForToday()
        {
            List<TaskListForTodayDTO> list = new List<TaskListForTodayDTO>();
            List<Task> tasks = new List<Task>();
            foreach(Task task in _context.Tasks) {
                if(task.Done == false && task.DueDate >= DateTime.Today && task.DueDate < DateTime.Today.AddDays(1)){
                    tasks.Add(task);
                }
            }

            foreach(TaskList taskList in _context.TaskLists) {
                foreach(Task task in tasks) {
                    if(taskList.Id == task.TaskListId) {
                        list.Add(new TaskListForTodayDTO(taskList.Title, task));
                    }
                }
            }
            return list;
        }
    }
}