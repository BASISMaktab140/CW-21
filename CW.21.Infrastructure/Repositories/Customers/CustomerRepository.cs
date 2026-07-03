using CW._21.Domain.Customers;
using CW._21.Infrastructures.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CW._21.Infrastructures.Repositories.Customers;

public class CustomerRepository : UserManager<Customer>, ICustomerRepository
{
    public CustomerRepository(AppDbContext appDbContext,IUserStore<Customer> store,
        IOptions<IdentityOptions> optionsAccessor, 
        IPasswordHasher<Customer> passwordHasher, IEnumerable<IUserValidator<Customer>> userValidators,
        IEnumerable<IPasswordValidator<Customer>> passwordValidators,
        ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors,
        IServiceProvider services, 
        ILogger<UserManager<Customer>> logger) :
        base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
        
    }

    public Task<Customer?> GetByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UsernameExistsAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<bool> EmailOrPhoneNumberExistsAsync(string emailOrPhoneNumber)
    {
        throw new NotImplementedException();
    }

    public Task<Customer?> GetByEmailOrPhoneNumberAsync(string emailOrPhoneNumber)
    {
        throw new NotImplementedException();
    }
}
