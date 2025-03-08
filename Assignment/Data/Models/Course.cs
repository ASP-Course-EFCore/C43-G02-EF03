using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Data.Models
{
    class Course
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; } = null!;
        public ICollection<Stud_Course> Students { get; set; } = null!;
        public ICollection<Course_Inst> Instructors { get; set; } = null!;
    }
}
