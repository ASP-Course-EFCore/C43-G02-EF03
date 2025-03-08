using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    [PrimaryKey(nameof(StdId),nameof(CrsId))]//To specify the composite Primary Key columns.
    class StudentCourses
    {
        [ForeignKey(nameof(Student))]//FK refer to Pk Of type of this relationship/property "Student"
        public int StdId { get; set; }//FK refer to Pk Of type of this relationship/property "Course"
        [ForeignKey(nameof(Course))]
        public int CrsId { get; set; }
        public int Grade { get; set; }
        //Navigational property [One]
        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}
