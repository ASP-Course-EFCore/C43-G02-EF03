using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Data.Models
{
    [PrimaryKey(nameof(Stud_Id),nameof(Course_Id))]
    class Stud_Course
    {
        [ForeignKey(nameof(Student))]
        public int Stud_Id { get; set; }
        [ForeignKey(nameof(Course))]
        public int Course_Id { get; set; }
        public int Grade { get; set; }
        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}
