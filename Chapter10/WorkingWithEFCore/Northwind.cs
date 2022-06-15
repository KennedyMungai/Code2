using System.Reflection.Emit;
using Microsoft.EntityFraneworkCore;

using static System.Console;

namespace Packt.Shared;

//This manages the connection to the database
public class Northwind : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (ProjectConstants.DatabaseProvider == "SqlServer")
        {
            string connection = "Data Source = KENNEDYMUNGAI; Initial Catalog=Northwind; Trusted_Connection=true; MultipleActiveResultSets=true;";
            optionsBuilder.UseSqlServer(connection);
        }
    }

    protected override void OnModelCreating(ModuleBuilder modelBuilder)
    {
        //An example of using Fluent API instead of attributes to limit the length of a category name to 15
        modelBuilder.Entity<Category>()
            .Property(category => category.CategoryName)
            .IsRequired()               // Is not null
            .HasMaxLength(15);
    }
}