using System;
using System.Linq;
using CsvHelper;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration;

namespace TaskScheduler
{
    internal class TaskScheduler
    {
        public static void Main(string [] args)
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

                }
            }
        }


    }
}