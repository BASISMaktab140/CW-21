using System.Security.Cryptography;
using System.Text;
using CW._21.Domain.Customers;
using CW._21.Domain.DTOs.Customers;
using CW._21.Domain.DTOs.Orders;
using CW._21.Domain.Exceptions;
using CW._21.Domain.OtpLogs;

namespace CW._21.Services.Customers;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IOtpLogRepository _otpLogRepository;

    public CustomerService(ICustomerRepository customerRepository, IOtpLogRepository otpLogRepository)
    {
        _customerRepository = customerRepository;
        _otpLogRepository = otpLogRepository;
    }

    public async Task RegisterAsync(RegisterCustomerDto customer)
    {
        if (await _customerRepository.UsernameExistsAsync(customer.Username))
            throw new BadRequestException("Username already exists");

        var passwordHash = HashPassword(customer.Password);

        await _customerRepository.AddAsync(
            new Customer(
                customer.Fullname,
                customer.Email,
                customer.PhoneNumber,
                customer.Username,
                passwordHash));
    }

    public async Task<string> LoginAsync(LoginCustomerDto loginInfo)
    {
        var customer = await _customerRepository.GetByUsernameAsync(loginInfo.Username);
        if (customer == null || customer.PasswordHash != HashPassword(loginInfo.Password))
            throw new UnauthorizedException("Invalid username or password");
        if (!customer.IsAcive)
            throw new UnauthorizedException("Your account has been deactivated");
        return $"Welcome {customer.Fullname}! Login successful.";
    }

    public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        return customers.Select(c => new CustomerDto(c.Fullname, c.Email, c.PhoneNumber));
    }


    public async Task<CustomerDto?> GetCustomerByIdAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null) return null;
        return new CustomerDto(customer.Fullname, customer.Email, customer.PhoneNumber);
    }

    public async Task ForgetPasswordAsync(ForgotPasswordDto forgotPasswordDto)
    {
        if (!await _customerRepository.EmailOrPhoneNumberExistsAsync(forgotPasswordDto.EmailOrPhoneNumber))
            throw new BadRequestException("Email does not exist");

        var code = Random.Shared.Next(1000, 9999).ToString();
        var otpLog = new OtpLog(code, forgotPasswordDto.EmailOrPhoneNumber, DateTime.UtcNow.AddMinutes(5));
        await _otpLogRepository.AddAsync(otpLog);
    }

    public async Task ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
    {
        var otpLog =
            await _otpLogRepository.GetValidCodeAsync(resetPasswordDto.EmailOrPhoneNumber, resetPasswordDto.Code);
        if (otpLog == null)
            throw new BadRequestException("Invalid or expired OTP Code");

        var customer = await _customerRepository.GetByEmailOrPhoneNumberAsync(resetPasswordDto.EmailOrPhoneNumber);
        var newPassword = HashPassword(resetPasswordDto.NewPassword);
        customer.PasswordHash = newPassword;
        await _customerRepository.UpdateAsync(customer);

        otpLog.IsUsed = true;
        await _otpLogRepository.UpdateAsync(otpLog);
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