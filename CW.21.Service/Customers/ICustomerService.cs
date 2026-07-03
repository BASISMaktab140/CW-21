using CW._21.Domain.Customers;
using CW._21.Domain.DTOs.Customers;
using CW._21.Domain.DTOs.Orders;

namespace CW._21.Services.Customers;

public interface ICustomerService
{
    /// <summary>
    /// ثبت نام کاربر
    /// </summary>
    /// <param name="customer"></param>
    /// <returns></returns>
    Task RegisterAsync(RegisterCustomerDto customer);
    
    
    Task<string> LoginAsync(LoginCustomerDto customer);
    
    /// <summary>
    /// دریافت کاربر بر اساس شناسه (id)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<CustomerDto?> GetCustomerByIdAsync(int id);
    
    /// <summary>
    /// دریافت کاربر بر اساس نام کاربری (username)
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    Task<CustomerDto?> GetCustomerByUsernameAsync(string username);
    
    /// <summary>
    /// دریافت لیست تمام کاربران
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
    
    /// <summary>
    /// ویرایش اطلاعات کاربر
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    Task<bool> UpdateInfoAsync(CustomerDto role);
    
    /// <summary>
    /// فراموشی رمز
    /// </summary>
    /// <param name="forgotPasswordDto"></param>
    /// <returns></returns>
    Task ForgetPasswordAsync(ForgotPasswordDto forgotPasswordDto);
    
    /// <summary>
    /// بازنشانی رمزعبور
    /// </summary>
    /// <param name="resetPasswordDto"></param>
    /// <returns></returns>
    Task ResetPasswordAsync(ResetPasswordDto resetPasswordDto);

    /// <summary>
    /// صحت رمزعبور
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task CheckPasswordAsync(string username , string password);
    /// <summary>
    /// حذف کاربر
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteCustomerAsync(int id);
}

