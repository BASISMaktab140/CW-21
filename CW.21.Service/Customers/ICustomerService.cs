using CW._21.Domain.Customers;
using CW._21.Domain.DTOs.Customers;
using CW._21.Domain.DTOs.Orders;

namespace CW._21.Services.Customers;

public interface ICustomerService
{
    Task RegisterAsync(RegisterCustomerDto customer);
    Task<string> LoginAsync(LoginCustomerDto customer);
    Task<CustomerDto?> GetCustomerByIdAsync(int id);
    Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
    Task ForgetPasswordAsync(ForgotPasswordDto forgotPasswordDto);
    Task ResetPasswordAsync(ResetPasswordDto resetPasswordDto);

}

