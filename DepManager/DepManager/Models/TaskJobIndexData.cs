using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DepManager.Models
{
    public class TaskJobIndexData
    {
        public IEnumerable<TaskJob> TaskJobs { get; set; }
        public IEnumerable<TBrief> TBriefs { get; set; }
    }
}