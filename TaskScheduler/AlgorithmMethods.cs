namespace TaskScheduler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class AlgorithmMethods
    {
        public static List<Task> CountStartDate(List<Task> list)
        {
            var responssibles = list.Select(x => x.Responsible).Distinct();

            var projectStartDate = list[0].MinStartDate;
            var newList = new List<Task>();
            foreach (var responssible in responssibles)
            {
                var recordList = list.Where(x => x.Responsible == responssible).OrderByDescending(x => x.Priority).ToList();

                for (int i = 0; i < recordList.Count; i++)
                {
                    if (recordList[i].Responsible == responssible)
                    {
                        if (i == 0)
                        {
                            recordList[i].StartDate = projectStartDate;
                            recordList[i].EndDate = projectStartDate.AddDays((double)recordList[i].Work.GetValueOrDefault(0)).Date;
                        }
                        else
                        {
                            recordList[i].StartDate = recordList[i - 1].StartDate.AddDays((double)recordList[i - 1].Work.GetValueOrDefault(0)).Date;
                            recordList[i].EndDate = recordList[i].StartDate.AddDays((double)recordList[i].Work.GetValueOrDefault(0)).Date;
                        }
                    }
                }

                newList.AddRange(recordList);
            }

            return newList;
        }
    }
}
