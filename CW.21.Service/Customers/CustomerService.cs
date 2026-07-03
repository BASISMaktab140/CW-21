using System.Security.Cryptography;
using System.Text;
using CW._21.Domain.Customers;
using CW._21.Domain.DTOs.Customers;
using CW._21.Domain.DTOs.Orders;
using CW._21.Domain.Exceptions;
using CW._21.Domain.OtpLogs;
using Microsoft.AspNetCore.Identity;

namespace CW._21.Services.Customers;

public class CustomerService : ICustomerService
{
  //  private readonly ICustomerRepository _customerRepository;
    private readonly IOtpLogRepository _otpLogRepository;
    private readonly UserManager<Customer> _userManager;

    
    public CustomerService(ICustomerRepository customerRepository, 
        IOtpLogRepository otpLogRepository, 
        UserManager<Customer> userManager)
    {
       // _customerRepository = customerRepository;
        _otpLogRepository = otpLogRepository;
        _userManager = userManager;
    }

    public async Task RegisterAsync(RegisterCustomerDto registerCustomerDto)
    {
        var customer  = await _userManager.FindByNameAsync(registerCustomerDto.Username);
        if (customer == null)
            throw new BadRequestException("Customer already exists");

        var passwordHash = HashPassword(registerCustomerDto.Password);
        
         customer = new Customer(
            registerCustomerDto.FirstName,
            registerCustomerDto.LastName,
                
            registerCustomerDto.Username,
            passwordHash,
            registerCustomerDto.PhoneNumber,
            registerCustomerDto.Email
        );
        await _userManager.CreateAsync(customer, passwordHash);

    }

    public Task<string> LoginAsync(LoginCustomerDto customer)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerDto?> GetCustomerByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerDto?> GetCustomerByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateInfoAsync(CustomerDto role)
    {
        throw new NotImplementedException();
    }

    public Task ForgetPasswordAsync(ForgotPasswordDto forgotPasswordDto)
    {
        throw new NotImplementedException();
    }

    public Task ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
    {
        throw new NotImplementedException();
    }

    public Task CheckPasswordAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCustomerAsync(int id)
    {
        throw new NotImplementedException();
    }


    private static string HashPassword(string password)
    {
        // 1. Convert password string to byte array
        byte[] inputBytes = Encoding.UTF8.GetBytes(password);

        // 2. Compute SHA-256 hash
        byte[] hashBytes = SHA256.HashData(inputBytes);

        // 3. Convert byte array to hexadecimal string
        string hashString = Convert.ToHexString(hashBytes);

        return hashString;
        //Console.WriteLine(hashString);
        // Output: 4D4E938B86EF58F... (64 character hex string)
    }
}