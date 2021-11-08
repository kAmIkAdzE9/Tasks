using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using Npgsql;

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
        private List<ListAndCountOfNonDoneTasksDTO> GetAllListWithCountOfNonDoneTasks()
        {
            return _context.TaskLists
            .Include(p => p.Tasks)
            .Select(l => new ListAndCountOfNonDoneTasksDTO(l.Id, l.Title, l.Tasks.Where(t => t.Done == false || t == null).Count())).ToList();
        }

        //Dashboard 2 SQL
        public List<ListAndCountOfNonDoneTasksDTO> GetAllListWithCountOfNonDoneTasksUsingSql()
        {
            string request = "select task_lists.id, task_lists.title, (select count(*) from tasks where tasks.done = false and tasks.task_list_id = task_lists.id) from task_lists";
            string connection = _context.Database.GetConnectionString();

            NpgsqlConnection conn;

            try
            {
                conn = new NpgsqlConnection(connection);
            }

            catch
            {
                return null;
            }


            conn.Open();

            List<ListAndCountOfNonDoneTasksDTO> list = new List<ListAndCountOfNonDoneTasksDTO>();

            using (var cmd = new NpgsqlCommand(request, conn))
            {
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var title = reader.GetString(1);
                        var count = reader.GetInt32(2);
                        list.Add(new ListAndCountOfNonDoneTasksDTO(id, title, count));
                    }
            }

            conn.Close();
            return list;
        }

        //Dashboard All
        public List<DashboardDTO> GetListInfo()
        {
            List<DashboardDTO> list = new List<DashboardDTO>();
            list.Add(new DashboardDTO(GetTasksCountForToday(), GetAllListWithCountOfNonDoneTasksUsingSql()));
            return list;
        }

        private List<TaskWithTaskListDTO> ConvertTaskToTaskWithListTitleDTO(List<Task> tasks)
        {
            List<TaskWithTaskListDTO> list = new List<TaskWithTaskListDTO>();
            foreach (Task task in tasks)
            {
                list.Add(new TaskWithTaskListDTO
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    Done = task.Done,
                    TaskList = new ListWithoutTasksDTO(task.TaskList.Id, task.TaskList.Title)
                });
            }
            return list;
        }

        //collection/today
        public List<TaskWithTaskListDTO> GetTaskListWithNonDoneTasksForToday()
        {
            return ConvertTaskToTaskWithListTitleDTO(_context.Tasks.Include(l => l.TaskList).Where(t => t.DueDate >= DateTime.Today && t.DueDate < DateTime.Today.AddDays(1)).ToList());
        }

        //lists/{listId}/tasks
        public List<TaskWithTaskListDTO> GetTaskList(int listId, bool all)
        {
            List<Task> tasks = new List<Task>();
            foreach (Task task in _context.Tasks.Include(l => l.TaskList))
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