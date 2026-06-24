namespace CW._21.Domain.DTOs.Customers;

public record ResetPasswordDto(string Code, string EmailOrPhoneNumber, string NewPassword);