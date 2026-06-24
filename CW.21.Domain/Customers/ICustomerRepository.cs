using CW._21.Domain.DTOs.Orders;
using CW._21.Domain.Generics;

namespace CW._21.Domain.Customers;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Task<Customer?> GetByUsernameAsync(string username);
    Task<bool> UsernameExistsAsync(string username);
    Task<bool> EmailOrPhoneNumberExistsAsync(string emailOrPhoneNumber);
    Task<Customer?> GetByEmailOrPhoneNumberAsync(string emailOrPhoneNumber);
    
}