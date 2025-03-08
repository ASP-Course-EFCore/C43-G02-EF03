using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }=null!;
        public int Age { get; set; }
        //Navigation Property [Many] => Student Take Many Courses
        //public ICollection<Course> Courses { get; set; } = new HashSet<Course>();

        public ICollection<StudentCourses> StudentCourses { get; set; } = new HashSet<StudentCourses>();

    }
}
