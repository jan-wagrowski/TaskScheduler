namespace TaskScheduler
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using CsvHelper;
    using CsvHelper.Configuration;

    internal class TaskScheduler
    {
        public static void Main(string[] args)
        {
            using (var reader = new StreamReader("./FirstEmptyDateSlot.csv", System.Text.Encoding.UTF8))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";",
                };

                using (var csvReader = new CsvReader(reader, csvConfig))
                {
                    var records = csvReader.GetRecords<Task>();

                    var rekord = new List<Task>(records);
                }
            }
        }
    }
}