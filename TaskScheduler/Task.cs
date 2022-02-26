namespace TaskScheduler
{
    using CsvHelper;
    using CsvHelper.Configuration;
    using System.Globalization;

    public class Task
    {

        public string ID { get; set; }

        public int? Priority { get; set; }

        public string Description { get; set; }

        public string? Predecessors { get; set; }

        public int? Work { get; set; }

        public string? Responsible {get; set;}

        public DateOnly MinStartDate { get; set; }

        public DateOnly MaxEndDate { get; set; }

        public static List<Task> Reader()
        {
            using (var steamReader = new StreamReader("./FirstEmptyDateSlot.csv"))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";"
                };

                using (var csvReader = new CsvReader(steamReader, csvConfig))
                {
                    var records = csvReader.GetRecords<Task>();
                    var rekord = new List<Task>(records);
                    return rekord;
                }
            }
        }

        public static void writer(List<Task> recordlist)
        {
            using (var writer = new StreamWriter(@"C:\Users\Maciek\Desktop\Zadania.csv"))
            {
                using (var csvWritter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvWritter.Context.RegisterClassMap<TaskMap>();
                    csvWritter.WriteRecords(recordlist);
                }
            }
        }
    }
}
