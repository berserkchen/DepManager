using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DepManager.Models
{
    public class DepManagerContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DepManagerContext() : base("name=DepManagerContext")
        {
        }

        public System.Data.Entity.DbSet<DepManager.Models.Manager> Managers { get; set; }

        public System.Data.Entity.DbSet<DepManager.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<DepManager.Models.PBrief> PBriefs { get; set; }

        public System.Data.Entity.DbSet<DepManager.Models.TBrief> TBriefs { get; set; }

        public System.Data.Entity.DbSet<DepManager.Models.TaskJob> TaskJobs { get; set; }
    
    }
}
