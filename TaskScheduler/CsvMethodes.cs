namespace TaskScheduler
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CsvHelper;
    using CsvHelper.Configuration;

    public class CsvMethodes
    {
        public static List<Task> Reader()
        {
            using var steamReader = new StreamReader("./FirstEmptyDateSlot.csv", System.Text.Encoding.UTF8);
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                MissingFieldFound = null,
            };

            using var csvReader = new CsvReader(steamReader, csvConfig);
            var records = csvReader.GetRecords<Task>();
            var rekord = new List<Task>(records);
            return rekord;
        }

        public static void Writer(List<Task> recordlist)
        {
            using var writer = new StreamWriter(@"C:\Users\Maciek\Desktop\Zadania.csv", false, System.Text.Encoding.UTF8);
            using var csvWritter = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csvWritter.Context.RegisterClassMap<TaskMap>();
            csvWritter.WriteRecords(recordlist);
        }
    }
}
