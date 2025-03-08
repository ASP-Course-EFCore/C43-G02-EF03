using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        //Navigation Property [Many] => Course Has Many Students
        //public ICollection<Student> Students { get; set; } = new HashSet<Student>();

        public ICollection<StudentCourses> CourseStudents { get; set; } = new HashSet<StudentCourses>();

    }
}
