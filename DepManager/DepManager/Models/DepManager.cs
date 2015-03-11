using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DepManager.Models
{

    public class Manager
    {
        public int ManagerID { get; set; }
        public string FullName { get; set; }
    }

    public class Project
    {
        [Key]
        public int ProjectID { get; set; }

        public string ProjectName { get; set; }
        public int ManagerID { get; set; }

        public virtual Manager ProjectManager { get; set; }

        public virtual ICollection<PBrief> PBriefs { get; set; }
       
    }

    public class TaskJob
    {
        [Key]
        public int TaskID { get; set; }

        public string TaskName { get; set; }

        public int ManagerID { get; set; }

        public virtual Manager ProjectManager { get; set; }

        public virtual ICollection<TBrief> TBriefs { get; set; }


    }

    public class PBrief
    {
        [Key]
        public int BriefID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }

        public string Plan { get; set; }
        public string Action { get; set; }

        public bool Finished { get; set; }

        public int? ProjectID { get; set; }
        public virtual Project Project { get; set; }

    }
    public class TBrief
    {
        [Key]
        public int BriefID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }

        public string Plan { get; set; }
        public string Action { get; set; }

        public bool Finished { get; set; }
        public int? TaskID { get; set; }
        public virtual TaskJob TaskJob { get; set; }

    }
}