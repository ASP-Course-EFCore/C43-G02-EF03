using Assignment.Data.Configuration_Classes;
using Assignment.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Data.DbContexts
{
    class ITIDbContext : DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = ITI; Trusted_Connection = true; Encrypt = True; TrustServerCertificate = True");//Trust App To connect on sql server service throw Windows authentication.
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Department>(new DepartmentConfiguration());

            modelBuilder.Entity<Course_Inst>()
                        .HasKey(CS => new { CS.Inst_Id, CS.Course_Id });

            modelBuilder.Entity<Instructor>()
                        .HasMany<Course_Inst>(I => I.Courses)
                        .WithOne(CI => CI.Instructor)
                        .HasForeignKey(CI => CI.Inst_Id)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Course>()
                      .HasMany<Course_Inst>(C => C.Instructors)
                      .WithOne(CI => CI.Course)
                      .HasForeignKey(CI => CI.Course_Id)
                      .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
