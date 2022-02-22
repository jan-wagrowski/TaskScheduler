using System;
using System.Linq;
using CsvHelper;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration;

namespace TaskScheduler
{
    internal class Class1
    {
        public static void Main(string [] args)
        {
            using (var steamReader = new StreamReader(@"C:\Users\Maciek\Desktop\Zeszyt1.csv"))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";"
                };

                using (var csvReader = new CsvReader(steamReader, csvConfig))
                {
                    var records = csvReader.GetRecords<Task>();
                }
            }
            
        }


    }
}

public class Task
{
    public int Id { get; set; }
    public string Name { get; set; }
}