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
            var list = Task.Reader();

            var responssibles = list.Select(x => x.Responsible).Distinct();

            var projectStartDate = list[0].MinStartDate;
            var newList = new List<Task>();
            foreach (var responssible in responssibles)
            {
                var recordList = list.Where(x => x.Responsible == responssible).ToList();

                for (int i = 0; i < recordList.Count(); i++)
                {
                    if (recordList[i].Responsible == responssible)
                    {
                        if (i == 0)
                        {
                            recordList[i].StartDate = projectStartDate;
                        }
                        else
                        {
                            recordList[i].StartDate = recordList[i - 1].StartDate.AddDays((double)recordList[i - 1].Work.GetValueOrDefault(0)).Date;
                        }
                    }
                }

                newList.AddRange(recordList);
            }

            newList.Sort();
            Task.Writer(newList);
        }
    }
}