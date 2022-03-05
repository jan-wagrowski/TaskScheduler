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

        public string? Predecessors { get; set; }

        public int? Work { get; set; }

        public string? Responsible {get; set; }

        public DateTime MinStartDate { get; set; }

        public DateTime MaxEndDate { get; set; }

        public DateTime StartDate { get; set; }

        //public DateTime? EndDate { get; set; }


        public static List<Task> Reader()
        {
            using (var steamReader = new StreamReader("./FirstEmptyDateSlot.csv", System.Text.Encoding.UTF8))
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

        public static void Writer(List<Task> recordlist)
        {
            using (var writer = new StreamWriter(@"C:\Users\Maciek\Desktop\Zadania.csv", false, System.Text.Encoding.UTF8))
            {
                using (var csvWritter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvWritter.WriteRecords(recordlist);
                }
            }
        }

        public int CompareTo(Task? other)
        {
            return ID.CompareTo(other.ID);
        }
    }
}
