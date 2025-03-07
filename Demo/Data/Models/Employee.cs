using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    class Employee
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity/*Enum*/)]
        public int Code { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50, MinimumLength = 10)]
        [Length(10, 50)]
        public string? Name { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        [DataType(DataType.Currency)]
        public double Salary { get; set; }

        [Range(15, 35)]
        [AllowedValues(20, 30, 40, 50)]
        [DeniedValues(25, 35)]
        public int? Age { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression("")]
        public string? password { get; set; }

        [Phone(ErrorMessage = "Must be 11 digits!")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [NotMapped]
        public double NetSalary { get { return Salary - (Salary * .2); } }
        //OR
        public double GetNetSalary => Salary - (Salary * .2);
        
        ///Navigational Property [One]
        ///EF Core By default will know that there is OneToOne Relationship between "Employee-Department"
        ///Employee [May] manage one department [Partial Participation]
        public Department? ManagedDepartment { get; set; }

        ///Navigational Property [One Address] - Employee must has one Address
        ///EF Core By default will know that there is OneToOne Relationship between "Employee-Address"
        ///Employee [Must] Has one Address [Total Participation]
        public Address EmpAddress { get; set; }
    }
}
