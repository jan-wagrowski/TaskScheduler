using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler
{
    internal class ResultTask : Task
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
