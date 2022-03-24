namespace TaskScheduler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal static class AlgorithmMethods
    {
        public static List<Task> CountStartDate(List<Task> list)
        {
            var responsibles = list.Select(x => x.Responsible).Distinct();
            var projectStartDate = list[0].MinStartDate;
            var newList = new List<Task>();

            foreach (var responsible in responsibles)
            {
                var recordList = list.Where(x => x.Responsible == responsible).OrderBy(x => x.Priority.HasValue ? x.Priority : int.MaxValue).ToList();

                for (int i = 0; i < recordList.Count; i++)
                {
                    if (recordList[i].Responsible == responsible)
                    {
                        if (i == 0)
                        {
                           //recordList[i].StartDate = projectStartDate;
                        }
                        else
                        {
                            //if (recordList[i].Predecessors.Count == 0)
                            //{
                                //recordList[i].StartDate = recordList[i - 1].StartDate.AddDays((double)recordList[i].Work.GetValueOrDefault(0));
                            //}
                           // else
                            //{
                               // recordList[i].StartDate = DateTimeMethode.Max(recordList[i].MinStartDate, recordList[i].Predecessors);
                            //}

                            
                        }
                    }
                }

                newList.AddRange(recordList);
            }

            return newList;
        }
    }
}
