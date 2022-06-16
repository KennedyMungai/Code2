using Microsoft.AspNetCore.Mvc;                         //[Route], [ApiController], ControllerBase
using Packt.Shared;                                     //Customer
using Northwind.WebApi.Repositories;                    //ICustomerRepository

namespace Northwind.WebApi.Controllers;

//base address: api/customers
[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerRepository repo;

    //The contructor injects the repository registered as StartUp
    public CustomersController(ICustomerRepository repo)
    {
        this.repo = repo;
    }

    //GET: api/customers
    //GET: api/customers/?country=[country]
    //This will always return a list of customers (but it might be empty)
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
    public async Task<IEnumerable<Customer>> GetCustomers(string? country)
    {
        if (string.IsNullOrWhiteSpace(country))
        {
            return await repo.RetrieveAllAsync(); 
        }
        else
        {
            return (await repo.RetrieveAllAsync())
                .Where(customer => customer.Country == country);
        }
    }

    //GET: api/customers/[id]
    [HttpGet("{id}", Name = nameof(GetCustomer))]           //Named route
    [ProducesResponseType(200, Type = typeof(Customer))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetCustomer(string id)
    {
        Customer? c = await repo.RetrieveAsync(id);

        if (c is null)
        {
            return NotFound();                                          //404 Resource not found
        }

        return Ok(c);
    }

    //POST: api/customers
    //BODY: Customer(JSON, XML)
    [HttpPost]
    [ProducesResponseType(201, Type=typeof(Customer))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] Customer c)
    {
        if (c is null)
        {
            return BadRequest();                                        //400 Bad request
        }
        
        Customer? addedCustomer = await repo.CreateAsync(c);

        if (addedCustomer == null)
        {
            return BadRequest("Repository failed to create a Customer");
        }
        else
        {
            return CreatedAtRoute(//201 Created
                routeName: nameof(GetCustomer),
                routeValues: new {id = addedCustomer.CustomerId.ToLower()},
                value: addedCustomer
            );
        }
    }

    //PUT: api/customers/[id]
    //BODY: Customer (JSON, XML)
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(string id, [FromBody] Customer c)
    {
        id = id.ToUpper();
        c.CustomerId = c.CustomerId.ToUpper();

        if (c == null | c.CustomerId != id)
        {
            return BadRequest();                                                //400 Bad Request
        }

        Customer? existing = await repo.RetrieveAsync(id);

        if (existing is null)
        {
            return NotFound();                                                  //404 Resource not found
        }

        await repo.UpdateAsync(id, c);

        return new NoContentResult();                                           //204 No content
    }

    //DELETE: api/customers/[id]
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(string id)
    {
        Customer? existing = await repo.RetrieveAsync(id);

        if (existing is null)
        {
            return NotFound();                                                  //404 Resource not found
        }

        bool? deleted = await repo.DeleteAsync(id);

        if(deleted.HasValue && deleted.Value)                                   //Short circuit AND
        {
            return new NoContentResult();                                       //204 No content
        }
        else
        {
            return BadRequest(//400 Bad Request
                $"Customer {id} was found but failed to delete."
            );
        }
    }
}