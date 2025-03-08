using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Data.Models
{
    class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public decimal Bonus { get; set; }
        public decimal Salary { get; set; }
        public decimal Address { get; set; }
        public string HourRate { get; set; }
        [ForeignKey(nameof(LocatedDepartment))]
        public int LocatedDepartmentId { get; set; }
        [InverseProperty(nameof(Department.Manager))]
        public Department? ManagedDepartment { get; set; }
        [InverseProperty(nameof(Department.Instructors))]
        public Department LocatedDepartment { get; set; } = null!;
        public ICollection<Course_Inst> Courses { get; set; } = null!;
    }
}
