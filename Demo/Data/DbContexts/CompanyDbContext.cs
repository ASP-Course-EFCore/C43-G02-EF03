using Demo.Data.Models;
using Demo.Data.ModelsConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.DbContexts
{
    class CompanyDbContext : DbContext
    {

        #region Properties

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        //public DbSet<Address> Addresses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }

        #endregion

        #region Constructors

        public CompanyDbContext() : base()
        {

        }

        #endregion

        #region Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = Company02; Trusted_Connection = true; Encrypt = True; TrustServerCertificate = True");//Trust App To connect on sql server service throw Windows authentication.
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigurations());
            modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfiguration());

            ///Configure the relationship between [Employee-Department] in case you represent the navigational properties in the 2 classes
            ///RelationShip [Manage] Configuration between Employee-Department Classes.

            modelBuilder.Entity<Employee>()
                        .HasOne<Department>(E => E.ManagedDepartment)//Specify the Navigational property "ManagedDepartment" inside "Employee" Class
                        .WithOne(D => D.Manager)//Specify the Navigational property "Manager" inside "Department" Class
                        .HasForeignKey<Department>(D => D.DeptManagerId)//Specify the "FK" "DeptManagerId" inside "Department" class.
                        .OnDelete(DeleteBehavior.NoAction)//To Change the default behavior from "Cascade" to "NoAction".
                        .IsRequired(true);//Make the column of relationship required.

            ///Map "One-One && Mandatory-Mandatory" Relationship between [Employee - Address]
            ///
            //modelBuilder.Entity<Employee>()
            //            .OwnsOne<Address>(E => E.EmpAddress, Address => Address.WithOwner());

            ///Or Configure the relationship from another side.
            ///
            //modelBuilder.Entity<Department>()
            //            .HasOne<Employee>(D => D.Manager)
            //            .WithOne(E => E.ManagedDepartment)
            //            .HasForeignKey<Department>(D => D.DeptManagerId)
            //            .OnDelete(DeleteBehavior.NoAction)
            //            .IsRequired(true);


            ///Configure the relationship between [Employee-Department] in case you not represent the navigational properties in the 2 classes
            ///In this case you can't navigate between Employee-Department in the APP because you don't have the navigational properties.
            ///But always we represent the navigational properties inside the classes to let us navigate on the data of 2 classes of the relationship.
            //modelBuilder.Entity<Employee>()
            //            .HasOne<Department>()
            //            .WithOne()
            //            .HasForeignKey<Department>(D => D.DeptManagerId);

            ///Configure the relationship between [ Student-Course M-M ] in case you not represent the Third Table [Relationship Table] in App.
            ///And Need to Add This new table with specific name not like the Convention "CourseStudent".
            //modelBuilder.Entity<Student>()
            //            .HasMany<Course>(S => S.Courses)
            //            .WithMany(C => C.Students)
            //            .UsingEntity(NewTable => NewTable.ToTable("Stud_Courses"));


            ///To Specify the composite key of this entity by Fluent APIs.
            ///
            //modelBuilder.Entity<StudentCourses>()
            //            .HasKey(SC => new { SC.StdId, SC.CrsId });

            ///Configure the relationship between [ Student-Course M-M ] as one-many & one-many
            ///
            //Student - StudentCourse
            modelBuilder.Entity<Student>()
                        .HasMany<StudentCourses>(S => S.StudentCourses)
                        .WithOne(SC => SC.Student)
                        .HasForeignKey(SC => SC.StdId)
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();//FK "StdId" can't be assigned with null.
            
            //Course - StudentCourse
            modelBuilder.Entity<Course>()
                        .HasMany<StudentCourses>(C => C.CourseStudents)
                        .WithOne(SC => SC.Course)
                        .HasForeignKey(SC => SC.CrsId)
                        .IsRequired();//FK "CrsId" can't be assigned with null - Student must take course.



        }

        #endregion

    }
}
