using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HopperTech.Models
{
    public class HopperTechContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public HopperTechContext() : base("name=HopperTechContext")
        {
        }

        public System.Data.Entity.DbSet<HopperTech.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<HopperTech.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<HopperTech.Models.Course_Student> Course_Student { get; set; }
    }
}
