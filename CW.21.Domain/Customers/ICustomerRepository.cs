namespace CW._21.Domain.Customers;

public interface ICustomerRepository 
{
    Task<Customer?> GetByUsernameAsync(string username);
    Task<bool> UsernameExistsAsync(string username);
    Task<bool> EmailOrPhoneNumberExistsAsync(string emailOrPhoneNumber);
    Task<Customer?> GetByEmailOrPhoneNumberAsync(string emailOrPhoneNumber);
    
}