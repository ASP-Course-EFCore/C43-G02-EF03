using Demo.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.ModelsConfiguration
{
    class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> department)
        {

            department.ToTable("Departments", "Sales");

            department.HasKey(D => D.DeptId);
            department.Property(D => D.DeptId)
                      .UseIdentityColumn(10, 10);

            department.Property(D => D.DeptName)
                      .HasColumnName("DepartmentName")
                      .HasColumnType("varchar")
                      .HasMaxLength(20)
                      .IsRequired(false)
                      .HasDefaultValue("HR");

            department.Property(D => D.DateOfCreation)
                      .HasAnnotation("DataType", "Date")
                      .HasDefaultValueSql("GetDate()");

            department.Ignore(D => D.Serial);

            ///RelationShip [Manage - OneToOne - Optional Mandatory] Configuration between Employee-Department Classes.
            ///
            //department.HasOne<Employee>(D => D.Manager)
            //          .WithOne(E => E.ManagedDepartment)
            //          .HasForeignKey<Department>(D => D.DeptManagerId)
            //          .OnDelete(DeleteBehavior.NoAction)
            //          .IsRequired(true);

            //department.OwnsOne<Address>(D => D.DeptAddress, Address => Address.WithOwner());

            ///Map The [Works] relationship between Employee - Department
            ///
            //department.HasMany<Employee>(D => D.Employees)
            //          .WithOne(E => E.EmployeeDepartment)
            //          .HasForeignKey(E => E.DepartmentId)
            //          .IsRequired()//Not has meaning because there is no thing in DB say that Department Must has Employees, So it will not mapped.
            //                      //This mean At least one Employee Per Department
            //          .OnDelete(DeleteBehavior.NoAction);
        
        }
    }
}
