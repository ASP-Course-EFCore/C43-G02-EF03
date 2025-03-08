using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Data.Models
{
    class Student
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string? LName { get; set; }
        public string? Address { get; set; }
        public string? Age { get; set; }
        [ForeignKey(nameof(LocatedDepartment))]
        public int LocatedDepartmentId { get; set; }
        [InverseProperty(nameof(Department.Students))]
        public Department LocatedDepartment { get; set; } = null!;

        public ICollection<Stud_Course> Courses { get; set; } = null!;
    }
}
