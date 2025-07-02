// 1. What is ORM?
// ORM (Object-Relational Mapping) is a technique that allows developers to interact with a database using objects instead of SQL queries.
// In C#, ORM maps classes to database tables, properties to columns, and class instances to rows in the table.
// Benefits of ORM include:
// - Increased productivity: reduces the need to write complex SQL.
// - Better maintainability: database interactions are managed via strongly typed C# classes.
// - Abstraction from SQL: developers can focus on business logic without worrying about SQL syntax.

// 2. EF Core vs EF Framework:
// EF Core:
// - Cross-platform (Windows, Linux, macOS).
// - Lightweight and extensible.
// - Supports modern features like LINQ, async/await queries, and compiled queries.
// - Actively developed with new features (latest: EF Core 8.0).
// EF Framework (EF6):
// - Windows-only and tightly coupled with the .NET Framework.
// - More mature and stable for legacy applications.
// - Less flexible compared to EF Core.

// 3. EF Core 8.0 Features:
// - Supports JSON column mapping for easier storage and querying of JSON data in the database.
// - Improved performance with compiled models that reduce startup time.
// - Introduced interceptors and enhanced bulk operations for better performance and extensibility.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailInventory
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
