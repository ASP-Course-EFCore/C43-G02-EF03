using Demo.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 05 Relationships Between Classes

            //How tho map relationship among tables (Entity Framework Core)?
            // EF Core supports different types of relationships between tables, which are represented using =>
            // (Navigation Properties - Foreign Key - Fluent APIs Configurations). 

            //What is Navigational Property?
            //Mean that you can navigate from one entity to another entity properties.
            //It store the data.
            //Navigational Property represent the relationship
            //Navigational property in the class is of type the second class in relationship.

            #endregion

            #region Part 06 Mapping OneToOne Relationship [Optional - Mandatory]
            //Mean that one instance from first table in relationship must be with one instance from another table. 
            //Means that each record in first table is associated with exactly one record in second table.

            //Mapping => Take PK of the optional table as FK in Mandatory table.
            //Ex=> An "Employee" may be [manage] a "Department" - and a "Department" must be managed by an "Employee" (OneToOne [Optional-Mandatory])

            //You can map this relationship using the 3 ways:-
            //1- By Convention.
            //2- By Data Annotations.
            //3- By Fluent APIs.

            //1- By Convention
            //   - All of you need to map relationship between two classes by convention is to set the navigational property.
            //   - In OneToOne Relationship you can represent the navigational property in one side of the 2 model or in the two sides because it OneToOneRelationship. 
            //   - After make the Navigational Properties
            //   - You need to specify the dependent side [The foreign key will be in which side/Table]
            //   - So take the "PK" of Optional side as "FK" in Mandatory side

            //In OneToOne Relationship => 
            // If you make the relationship[Navigational Properties] Inside the 2 tables/Classes in relationship -> You must specify the foreign key and write it. 
            // If you make the relationship[Navigational Properties] Inside only 1 tables/Class -> You Don't need specify the foreign key 
            // because the EF Core will make it in the class which you specify the Navigational Property in it an will named it as [NavigationalPropertyName+SecondTablePkName (ManagerCode)]
            // But it will not represented as column in the model so , you can

            //But we always make Navigational property inside the 2 classes of the relationship 
            //To easy navigate between the 2 classes to Access all data of any class throw the other class. 

            //2- By Data Annotations
            //What if you named the "FK" column specific name that not the one of the conventions name that E Core understand them by convention like "DeptManagerId" ?
            //will give error when you try to add migration [if you specify the navigational property in 2 sides in OneToOne Relationship]
            //The EF Core will deal with it as new column not the "FK" column and make new "FK" column named with "NavigationalPropertyName+PKColumnName" [if you specify the Navigational property in one side in OneToOne Relationship]
            //Because it need you to specify the dependent side [FK column will be in which model]?

            //So You need to use "DataAnnotations" or "Fluent APIs" 
            //If you need to specify different name to the "FK" column.

            //3- By Fluent APIs
            //Use This Way if you need to name the foreign key "FK" column with custom name not like names of the conventions that EF Core understand it
            //Or if you need custom constraint on the Relationship [FK] 
            //Like if you need to change the default behavior of deleting from [Cascade] to another value. 
            //-So use Fluent APIs way to make more configuration on the relationship.

            #endregion

            #region Part 07 Mapping OneToOne Relationship [Mandatory- Mandatory]

            ///Ex => An "Employee" [Has] One "Address" and each "address" must assigned to One "Employee" 
            ///
            ///Mapping of [One-One] Relationship [Mandatory-Mandatory] =>
            ///Is Mapped inside one table mean that the "Address" is not Entity/Table.
            ///
            ///Note => By default if you define Navigational Property inside the Employee Class of type "Address"
            ///The EF Core will deal with this Address as table that must has "PK" column when mapping even if you not add it as DbSet<Address> property inside the "CompanyDbContext".
            ///
            ///So We Not need now to map "Address" class as table
            ///And at the same time we need to define the "HAS" relationship between "Address" - "Employee"
            ///To Map it in one table "Employee" which contain the properties/columns of the class "Address" 
            ///
            ///This Relationship "One-One && Mandatory-Mandatory" called => 
            ///Owned && Owner
            ///Owned -> Address Class
            ///Owner -> Employee Class
            ///
            ///We Can't Configure this relationship "One-One && Mandatory-Mandatory" With Convention wWay
            ///We must use => Data Annotations || Fluent APIs
            ///
            ///01 - Data Annotations
            ///      - Put Attribute [Owned] as annotation on the owned class of the relationship
            ///      - Mean that it not mapped as self entity
            ///      - The Properties of this owned class will be mapped into the Owner class which has Navigational property of type "Address" owned class with name => "NavigationalPropertyName+PropertyName"
            ///
            ///02 - Fluent APIs
            ///     - By make the configuration of relationship inside "OnModelCreating()" or in the configure class of the owner entity "Employee".
            ///
            ///      
            ///      class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
            ///      {
            ///      public void Configure(EntityTypeBuilder<Employee> employee)
            ///          {
            ///              employee.OwnsOne<Address>(E => E.EmpAddress, Address => Address.WithOwner());
            ///          }
            ///      }
            ///
            ///   Or =>
            ///
            ///      class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
            ///      {
            ///      public void Configure(EntityTypeBuilder<Employee> employee)
            ///          {
            ///              employee.OwnsOne<Address>(E => E.EmpAddress)
            ///                      .WithOwner();
            ///          }
            ///      }
            ///
            ///
            ///Note => When Map this relationship using "Data Annotations" Way :
            ///          -This Owned Entity "Address" Will be always owned mean that you can't make it entity and define "DbSet<Address> Addresses" inside the DbContext
            ///          -Because You don't define Primary key column inside the Address Class
            ///          -If you define "PK" column inside the Owned [Owned] Class "Address" or Mark it as [KeyLess] and make DbSet<Address> Addresses And try to add migration
            ///          -The migration will successfully done and made a new table "Addresses" contain it's properties as Columns
            ///          -And Add new column inside the Owner class "Employee" which is "NavigationalPropertyName + PKColumnNameOfOwnedClass" => "EmpAddressId" As A "FK" column.
            ///          -And this not what i need in relationship [One-One && Mandatory-Mandatory]
            ///
            ///    //Note => When Map this relationship using "Fluent APIs" Way :
            ///                 -When not mark the owned class as [owned]
            ///                 -And Make this configuration With Fluent APIs configuration of the owner class
            ///                 -And also make "DbSet<Address> Addresses" inside the "DbContext" class
            ///                 -And Try To Add-Migration
            ///                 -The Migration will added successfully
            ///                 -And new Table will made "Addresses"
            ///                 -Which has "PK"&"FK" which is the "PK" column of the owner table "EmployeeCode"
            ///                 -And also has columns that are the properties made inside the class.
            ///                 -Mean that this "Address" has one owner "Employee".
            ///
            ///If you try to Add Navigational property of type Address inside another class like Department and also in Employee
            ///And Make configuration inside the two classes that the Employee OwnsOne Address & Department OwnsOne Address
            ///And Also have DbSet<Address> Addresses inside the DbContext
            ///And try to add migration
            ///The EF Core Will Add the properties of the class Address as columns inside each table and not make new table
            ///Because Address is owned by only one instance of entity.
            ///
            ///Summary => Don't Make DbSet for Owned Entity [Not Right Approach]

            #endregion

            #region Part 08 Mapping OneToMany Relationship [Many Mandatory]
            
            ///Means That each record in first table is associated with many records in second table
            ///Ex => An "Employee" Must [Works] in a "Department", And a "Department" Must has many Employees
            ///Many Side is Mandatory => 
            ///So Take "PK" column of the One Entity And Put it As "FK" column in the Many Entity.
            ///Take "PK" column of "Department" table as "FK" column in "Employee" table.
            ///
            ///How to make this ? [By Convention(Navigational Properties) - Data Annotations - Fluent APIs]
            ///
            ///01 - By Convention
            ///      -By Make Navigational property inside the Employee Class represent the [One] side.
            ///                  public Department EmployeeDepartment { get; set; } = null!;
            ///      -And Make Navigational property inside the Department class represent the [Many] side.
            ///                  public ICollection<Employee> Employees { get; set; } = null!;
            ///
            ///      -We use ICollection<T> interface because it has some methods and properties which i need like Add-Remove-Count-...
            ///      -We Add-Remove-.. from the Navigational property but it by default not loaded 
            ///      -So when i load it => like if i hold Department with Id=10,
            ///      -The "Employees" Navigational property which of type ICollection<Employee> will contain All Employees that in the department with id = 10
            ///      -So Throw/from This Collection which contain Employees in the department with id =10 , i can Add new Employee in this department throw this Navigational property.
            ///      -So i make this property of type ICollection<T> to let me use those methods [Add-Remove-Count] which is not in another interface or class.
            ///
            ///After This => You "optionally" need To Specify the Relationship "FK" to tell us the "FK" column will be in which side?
            ///It will be in the Side [Many] because in "One-Many && Many is mandatory"
            ///We take "PK" of one as "FK" in Many.
            ///So we will take "PK" column of "Department" as "FK" column in "Employee"
            ///And Name it as => "NavigationalPropertyName + PKColumnName" => "EmployeeDepartmentDeptId".
            ///
            ///If you don't specify the "FK" column, The EF Core Will understand the relationship
            ///But You can't access this "FK" column from the APP.
            ///Because you don't has the "FK" column inside the Employee table mean that you can't know the department which this employee attach to
            ///You must first load the all department throw the navigational property "EmployeeDepartment" inside the "Employee" class.
            ///
            ///Recommendation => Specify the "FK" column to have Access on it and can control the data of another table.
            ///
            ///If you need to name the "FK" column with specific name not like the Conventions Names
            ///Use [Data Annotations] Or [Fluent APIs] to do this.
            ///
            ///Note => If there are more than one relationship between two classes
            ///Use Data Annotations [ForeignKey()] to specify the "FK" of each relationship [Navigational Property]. 
            ///And Also You need to use Annotation [InverseProperty()] to specify the inverse Navigational property of this Navigational property [Make This in two sides/classes]
            ///
            ///If you need to make Additional configuration on the relationship use the Fluent APIs Way.
            ///
            ///Note=> If You make the relationship -> IsRequired() in one of the Entities of the relationship.
            ///Mean that the "FK" can't be null
            ///And OnDelete() behavior will be cascade.

            #endregion

        }
    }

}