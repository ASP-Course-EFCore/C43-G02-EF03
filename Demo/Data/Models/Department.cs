using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    ///By Convention
    //class Department
    //{
    //    public int DeptId { get; set; }
    //    public string DeptName { get; set; }
    //    public DateOnly DateOfCreation { get; set; }
    //    public int Serial { get; set; }


    //    ///To Let EF core know that this property is the "FK" ->
    //    ///"FK" must named as => [NavigationalPropertyName+Id => ManagerId ]
    //    ///Or "FK" must named as => [NavigationalPropertyName+SecondTablePkName => ManagerCode ]
    //    ///Or "FK" must named as => [SecondClassName+Id => EmployeeId ]
    //    ///Or "FK" must named as => [SecondClassName+SecondTablePkName => EmployeeCode ]
    //    ///
    //    ///In OneToOne Relationship => 
    //    /// If you make the relationship[Navigational Properties] Inside the 2 tables/Classes in relationship -> You must specify the foreign key and write it. 
    //    /// If you make the relationship[Navigational Properties] Inside only 1 tables/Class -> You Don't need specify the foreign key 
    //    /// because the EF Core will make it in the class which you specify the Navigational Property in it an will named it as [NavigationalPropertyName+SecondTablePkName (ManagerCode)]
    //    /// But it will not represented as column in the model so , you can't retrieve data based on it or make any operation on it.
    //    ///
    //    ///But we always make Navigational property inside the 2 classes of the relationship 
    //    ///To easy navigate between the 2 classes to Access all data of any class throw the other class. 
    //    public int ManagerId { get; set; }//the "FK" must be same type of the "PK" in the second Table.

    //    ///Navigational Property represent the [Manage] relationship between Employee Class/Table and Department
    //    ///EF core by default when make this will know that Department Has one employee to manage it - Without add navigational property in the another side/Table
    //    ///[Employee] not [List<Employee>] mean that the department has only one Employee to manage it [OneToOne Relationship]
    //    ///[Employee - Total participation(Mandatory)] mean that Department must has employee to manage it
    //    ///[Employee? - Partial Participation(Optional)] mean that Department may has employee to manage it [May not has manager]. 
    //    ///
    //    ///You can also Add Navigational property inside the Employee Class [if you need]
    //    ///public Department? ManagedDepartment {get;set;}
    //    public Employee Manager { get; set; } = null!;
    //}

    ///By Data Annotations
    //class Department
    //{
    //    public int DeptId { get; set; }
    //    public string DeptName { get; set; }
    //    public DateOnly DateOfCreation { get; set; }
    //    public int Serial { get; set; }

    //    [ForeignKey(nameof(Manager))]//When Specify New Name To "FK" that not one of the Convention Name, you need to use Data Annotations Way to map the "FK" column
    //                                 //This mean that take the "PK" of the type of Navigational Property "Manager" as "FK" in this class.
    //    public int DeptManagerId { get; set; }

    //    public Employee Manager { get; set; } = null!;
    //}

    ///By Fluent APIs
    class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public DateOnly DateOfCreation { get; set; }
        public int Serial { get; set; }
        public int DeptManagerId { get; set; }
        public Employee Manager { get; set; } = null!;
    }
}
