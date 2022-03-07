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
            var list = CsvMethodes.Reader();

            var startDateList = AlgorithmMethods.CountStartDate(list);

            startDateList.Sort();

            CsvMethodes.Writer(startDateList);
        }
    }
}