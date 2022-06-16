using Microsoft.EntityFrameworkCore.ChangeTracking;         // EntityEntry<T>
using Packt.Shared;                                         // Customer
using System.Collections.Concurrent;                        //ConcurrentDictionary

namespace Northwind.WebApi.Repositories;

public class CustomerRepository : ICustomerRepository
{
    public Task<Customer?> CreateAsync(Customer c)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Customer>> RetrieveAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Customer?> RetrieveAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Customer?> UpdateAsync(string id, Customer c)
    {
        throw new NotImplementedException();
    }

    public Task<bool?> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}