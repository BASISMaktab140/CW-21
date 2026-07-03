namespace CW._21.Domain.DTOs.Customers;

public record RegisterCustomerDto(string FirstName, string LastName,
    string Username, string Password,
    string PhoneNumber, string Email);