using CW._21.Domain.Customers;
using CW._21.Domain.DTOs.Customers;
using CW._21.Domain.Exceptions;
using CW._21.Services.Customers;
using CW._21.WebAPI.Commons;
using Microsoft.AspNetCore.Mvc;

namespace CW._21.WebAPI.Controllers;

[ApiController]
[Route("Customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost("api/customers/register")]
    public async Task<IActionResult> RegisterCustomerAsync([FromBody] RegisterCustomerDto customer)
    {
        await _customerService.RegisterAsync(customer);
        return StatusCode(201, ApiResult<string>.Success("Registration successful", "Registration successful", 201));
    }

    [HttpPost("api/customers/login")]
    public async Task<IActionResult> LoginCustomerAsync([FromBody] LoginCustomerDto customer)
    {
        var token = await _customerService.LoginAsync(customer);
        return Ok(ApiResult<string>.Success(token, "Login successful"));
    }

    [HttpGet("api/customers")]
    public async Task<IActionResult> GetAllCustomersAsync()
    {
        var customers = await _customerService.GetAllCustomersAsync();
        return Ok(ApiResult<IEnumerable<CustomerDto>>.Success(customers, "Customers retrieved successfully"));

    }

    [HttpGet("api/customers/{id}")]
    public async Task<IActionResult> GetCustomerByIdAsync([FromRoute]int id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);

        if (customer == null)
            throw new NotFoundException("Customer", id);

        return Ok(ApiResult<CustomerDto>.Success(customer, "Customer retrieved successfully"));
    }
    
    [HttpPost("api/customers/forgetPassword")]
    public async Task<IActionResult> ForgetPasswordAsync([FromBody] ForgotPasswordDto forgotPasswordDto)
    {
        await _customerService.ForgetPasswordAsync(forgotPasswordDto);
        return Ok(ApiResult.Success("OTP code sent successfully."));
    }
    
    [HttpPost("api/customers/resetPassword")]
    public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordDto resetPasswordDto)
    {
        await _customerService.ResetPasswordAsync(resetPasswordDto);
        return Ok(ApiResult.Success("Password reset successfully."));
    }
}