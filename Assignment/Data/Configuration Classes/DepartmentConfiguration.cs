using Assignment.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Data.Configuration_Classes
{
    class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> department)
        {
            department.HasMany<Instructor>(D => D.Instructors)
                      .WithOne(I => I.LocatedDepartment)
                      .HasForeignKey(D => D.LocatedDepartmentId)
                      .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
