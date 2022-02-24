namespace TaskScheduler
{
    public class Task
    {
        public int ID { get; set; }
        public string Priority { get; set; }
        public string Description { get; set; }
        public string Predecessors { get; set; }
        public int Work { get; set; }
        public string Responsible {get; set;}
        public DateOnly MinStartDate { get; set; }
        public DateOnly MaxEndDate { get; set; }


    }
}
