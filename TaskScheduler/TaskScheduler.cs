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
        public static void Main(string[] args)
        {
            var recordList = Task.Reader();

            Task.writer(recordList);
        }
    }
}