using Microsoft.EntityFrameworkCore;

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
        }
    }
}
