using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace todo_rest_api
{
    public class ListInfoService
    {
        private ToDoListContext _context;

        public ListInfoService(ToDoListContext context)
        {
            this._context = context;
        }

        //Dashboard 1
        private int GetTasksCountForToday()
        {
            return _context.Tasks.Where(t => (t.DueDate >= DateTime.Today) && (t.DueDate < DateTime.Today.AddDays(1))).Count();
        }

        //Dashboard 2
        private int GetCountOfNonDoneTasks(TaskList taskList)
        {
            return _context.Tasks.Where(t => t.Done == false && t.TaskListId == taskList.Id).Count();
        }

        //Dashboard 2
        private List<ListAndCountOfNonDoneTasksDTO> GetAllListWithCountOfNonDoneTasks()
        {
            List<ListAndCountOfNonDoneTasksDTO> list = new List<ListAndCountOfNonDoneTasksDTO>();

            foreach (TaskList taskList in _context.TaskLists.ToList())
            {
                list.Add(new ListAndCountOfNonDoneTasksDTO(taskList.Id, taskList.Title, GetCountOfNonDoneTasks(taskList)));
            }
            return list;
        }

        //Dashboard 2 alternarive
        private List<ListAndCountOfNonDoneTasksDTO> GetAllListWithCountOfNonDoneTasks2()
        {
            List<ListAndCountOfNonDoneTasksDTO> list = new List<ListAndCountOfNonDoneTasksDTO>();
            var query = _context.TaskLists
            .Include(p => p.Tasks)
            .Select(l => new ListAndCountOfNonDoneTasksDTO(l.Id, l.Title, l.Tasks.Count())).ToList();
            return query;
        }

        //Dashboard All
        public List<DashboardDTO> GetListInfo()
        {
            List<DashboardDTO> list = new List<DashboardDTO>();
            list.Add(new DashboardDTO(GetTasksCountForToday(), GetAllListWithCountOfNonDoneTasks2()));
            return list;
        }

        private List<TaskWithListTitleDTO> ConvertTaskToTaskWithListTitleDTO(List<Task> tasks)
        {
            List<TaskWithListTitleDTO> list = new List<TaskWithListTitleDTO>();
            foreach (Task task in tasks)
            {
                foreach (TaskList taskList in _context.TaskLists)
                {
                    if (taskList.Id == task.TaskListId)
                    {
                        list.Add(new TaskWithListTitleDTO
                        {
                            ListTitle = taskList.Title,
                            TaskListId = taskList.Id,
                            Id = task.Id,
                            Title = task.Title,
                            Description = task.Description,
                            DueDate = task.DueDate,
                            Done = task.Done
                        });
                        break;
                    }
                }
            }
            return list;
        }

        //collection/today
        public List<TaskWithListTitleDTO> GetTaskListWithNonDoneTasksForToday()
        {
            return ConvertTaskToTaskWithListTitleDTO(_context.Tasks.Where(t => t.DueDate >= DateTime.Today && t.DueDate < DateTime.Today.AddDays(1)).ToList());
        }

        //lists/{listId}/tasks
        public List<TaskWithListTitleDTO> GetTaskList(int listId, bool all)
        {
            List<Task> tasks = new List<Task>();
            foreach (Task task in _context.Tasks)
            {
                if (task.TaskListId == listId)
                {
                    if (all)
                    {
                        tasks.Add(task);
                    }
                    else
                    {
                        if (task.Done == false)
                        {
                            tasks.Add(task);
                        }
                    }
                }
            }
            return ConvertTaskToTaskWithListTitleDTO(tasks);
        }
    }
}