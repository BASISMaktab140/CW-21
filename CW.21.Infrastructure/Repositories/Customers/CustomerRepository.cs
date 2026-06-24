using System.Security.Cryptography;
using System.Text;
using CW._21.Domain.Customers;
using CW._21.Domain.DTOs.Orders;
using CW._21.Domain.Exceptions;
using CW._21.Infrastructures.Data;
using CW._21.Infrastructures.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace CW._21.Infrastructures.Repositories.Customers;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(AppDbContext context) : base(context)
    {
    }

    public Task<Customer?> GetByUsernameAsync(string username)
    {
        return DbSet.FirstOrDefaultAsync(c => c.Username == username);
    }

    public Task<bool> UsernameExistsAsync(string username)
    {
        return DbSet.AnyAsync(c => c.Username == username);
    }

    public Task<bool> EmailOrPhoneNumberExistsAsync(string emailOrPhoneNumber)
    {
        return DbSet.AnyAsync(c => c.PhoneNumber == emailOrPhoneNumber || c.Email == emailOrPhoneNumber);
    }

    public Task<Customer?> GetByEmailOrPhoneNumberAsync(string emailOrPhoneNumber)
    {
        return DbSet.FirstOrDefaultAsync(c => c.Email == emailOrPhoneNumber || c.PhoneNumber == emailOrPhoneNumber);
    }
}