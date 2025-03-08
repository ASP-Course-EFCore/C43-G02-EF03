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
    class CourseConfigurations : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> course)
        {
            course.HasOne<Topic>(C => C.Topic)
                  .WithMany(T => T.Courses)
                  .HasForeignKey(C => C.TopicId);

        }
    }
}
