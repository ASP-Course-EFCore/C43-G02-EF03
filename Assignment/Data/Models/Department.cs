using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Data.Models
{
    class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(Manager))]
        public int ManagerId { get; set; }
        public DateOnly HiringDate { get; set; }
        [InverseProperty(nameof(Instructor.ManagedDepartment))]
        public Instructor Manager { get; set; } = null!;
        [InverseProperty(nameof(Instructor.LocatedDepartment))]
        public ICollection<Instructor> Instructors { get; set; } = null!;
        [InverseProperty(nameof(Student.LocatedDepartment))]
        public ICollection<Student>? Students { get; set; }
    }
}
