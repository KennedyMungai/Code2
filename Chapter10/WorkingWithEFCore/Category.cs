using System.ComponentModel.DataAnnotations.Schema;             //[Column]

namespace Packt.Shared;

public class Category
{
    //These properties map to columns in the database
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
    
    [Column(TypeName = "ntext")]
    public string? Description { get; set; }
    
    //Defines a navigation property for related rows
    public virtual ICollection<Product> Products { get; set; }
    
    public Category()
    {
        //To enable developers to add products to a Category, we must 
        //initialize the navigation property to an empty collection
        Products = new HashSet<Products>();
    }
}