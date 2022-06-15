using Microsoft.EntityFrameworkCore;
using Packt.Shared;

using static System.Console;

namespace Code2.Chapter10.WorkingWithEFCore;

public class Program
{
    public static void Main(string[] args)
    {
        // WriteLine($"Using {ProjectConstants.DatabaseProvider} database provider.");

        QueryingCategories();
    }

    static void QueryingCategories()
    {
        using (Northwind db = new())
        {
            WriteLine("Categories and howmany products they have");

            //A query to get all categories and their related products
            IQueryable<Category>? categories = db.Categories?
                .Include(c => c.Products);

            if (categories is null)
            {
                WriteLine("No Categories found.");
                return;
            }

            //Execute Query and Enumerate the results
            foreach (Category c in categories)
            {
                WriteLine($"{c.CategoryName} has {c.Products.Count} products");
            }
        }
    }
}