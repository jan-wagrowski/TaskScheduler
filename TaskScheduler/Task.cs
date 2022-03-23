namespace TaskScheduler
{
    using System.Globalization;
    using CsvHelper;
    using CsvHelper.Configuration;

    public class Task : IComparable<Task>
    {
        public string? ID { get; set; }

        public int? Priority { get; set; }

        public string? Description { get; set; }

        public List<Task> Predecessors { get; set; }

        public int? Work { get; set; }

        public string? Responsible { get; set; }

        public DateTime MinStartDate { get; set; }

        public DateTime MaxEndDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int CompareTo(Task other)
        {
            return this.ID.CompareTo(other.ID);
        }
    }
}
