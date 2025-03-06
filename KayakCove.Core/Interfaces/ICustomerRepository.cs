using KayakCove.Core.Entities;

namespace KayakCove.Core.Interfaces;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<IEnumerable<Customer>> GetByEmailAsync(string email);
}