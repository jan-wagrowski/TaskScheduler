namespace TaskScheduler
{
    public class Task
    {
        public int ID { get; set; }

        public int? Priority { get; set; }

        public string Description { get; set; }

        public int? Predecessors { get; set; }

        public int? Work { get; set; }

        public string? Responsible { get; set; }

        public DateTime MinStartDate { get; set; }

        public DateTime MaxEndDate { get; set; }


    }
}
