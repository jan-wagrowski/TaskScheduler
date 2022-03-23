namespace TaskScheduler
{
    using System.Globalization;
    using CsvHelper;
    using CsvHelper.Configuration;

    public class TaskCsv
    {
        public TaskCsv()
        {
        }

        public string? ID { get; set; }

        public int? Priority { get; set; }

        public string? Description { get; set; }

        public string? Predecessors { get; set; }

        public int? Work { get; set; }

        public string? Responsible { get; set; }

        public DateTime MinStartDate { get; set; }

        public DateTime MaxEndDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public static List<Task> ToList(List<TaskCsv> listCsv)
        {
            var taskList = new Dictionary<string, Task>();

            for (int i = 0; i < listCsv.Count; i++)
            {
                taskList.Add(listCsv[i].ID, new Task
                {
                    ID = listCsv[i].ID,
                    Priority = listCsv[i].Priority,
                    Description = listCsv[i].Description,
                    Predecessors = new List<Task>(),
                    Work = listCsv[i].Work,
                    Responsible = listCsv[i].Responsible,
                    MinStartDate = listCsv[i].MinStartDate,
                    MaxEndDate = listCsv[i].MaxEndDate,
                    StartDate = listCsv[i].StartDate,
                    EndDate = listCsv[i].EndDate,
                });
            }

            for (int i = 0; i < listCsv.Count; i++)
            {
                if (listCsv[i].Predecessors != string.Empty)
                {
                    foreach (var item in listCsv[i].Predecessors.Split(","))
                    {
                        taskList[listCsv[i].ID].Predecessors.Add(taskList[item.Trim()]);
                    }
                }
            }

            var taskList2 = taskList.Select(task => task.Value).ToList();

            return taskList2;
        }
    }
}
