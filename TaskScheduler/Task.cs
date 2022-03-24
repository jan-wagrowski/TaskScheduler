namespace TaskScheduler
{
    using System.Globalization;
    using CsvHelper;
    using CsvHelper.Configuration;

    public class Task : IComparable<Task>
    {

        public List<Task> list { get; set; }

        public string? ID { get; set; }

        public int? Priority { get; set; }

        public string? Description { get; set; }

        public List<Task> Predecessors { get; set; }

        public int? Work { get; set; }

        public string? Responsible { get; set; }

        public DateTime MinStartDate { get; set; }

        public DateTime MaxEndDate { get; set; }

        public DateTime StartDate { get { return FindFirstEmptySlot(DateTimeMethode.Max(MinStartDate, Predecessors), list); } }

        public DateTime? EndDate { get { return StartDate.AddDays((double)Work.GetValueOrDefault(0)); } }

        public int CompareTo(Task other)
        {
            return this.StartDate.CompareTo(other.StartDate);
        }

        public DateTime FindFirstEmptySlot(DateTime startDate, List<Task> taskList)
        {
            taskList.Sort();
            for (int i = 0; i < taskList.Count - 1; i++)
            {
                if (taskList[i].EndDate.Value.AddDays(this.Work.GetValueOrDefault(0)) < taskList[i + 1].StartDate)
                {
                    return taskList[i].EndDate.GetValueOrDefault(DateTime.MinValue);
                }
            }

            if (taskList.Count == 0 || startDate > EndDate)
            {
                return startDate;
            }
            else
            {
                return taskList[taskList.Count - 1].EndDate.Value;
            }
        }
    }
}
