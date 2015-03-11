using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DepManager.Models
{
    public class ProjectIndexData
    {
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<PBrief> PBriefs { get; set; }
    }
}