namespace TaskScheduler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DateTimeMethode
    {
        public static DateTime Max(DateTime minStartDate, List<Task> list)
        {
            var endDateList = new List<DateTime>();
            for (int i = 0; i < list.Count; i++)
            {
                endDateList.Add(list[i].EndDate.GetValueOrDefault());
            }

            DateTime max = minStartDate;
            foreach (var date in endDateList)
            {
                if (DateTime.Compare(date.AddDays((double)1), max) == 1)
                    max = date.AddDays((double)1);
            }

            return max;
        }
    }
}