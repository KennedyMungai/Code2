using Microsoft.EntityFraneworkCore;

using static System.Console;

namespace Packt.Shared;

//This manages the connection to the database
public class Northwind : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (ProjectConstants.DatabaseProvider == "SqlServer")
        {
            string connection = "Data Source = KENNEDYMUNGAI; Initial Catalog=Northwind; Trusted_Connection=true; MultipleActiveResultSets=true;";
            optionsBuilder.UseSqlServer(connection);
        }
    }
}