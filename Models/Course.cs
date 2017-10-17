using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HopperTech.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreditHours { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }


        public virtual ICollection<Course_Student> Courses_Students { get; set; }
        

    }
}