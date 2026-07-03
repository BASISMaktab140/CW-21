using CW._21.Domain.Orders;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CW._21.Domain.Customers;

public class Customer : IdentityUser<int>, IAudible
{
    // Public Sealed Class
    public Customer()
    {

    }
    public Customer(string firstName, string lastName, string userName, string email, string password, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
    }

    [Required]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "It has to be between 3 to 50 characters")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "only letter allowed")]
    public string FirstName { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "It has to be between 3 to 50 characters")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "only letter allowed")]
    public string LastName { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]

    [EmailAddress(ErrorMessage = "Not valid Email Address")]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [MaxLength(11)]
    [MinLength(11)]
    public string PhoneNumber { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool IsDeleted { get; set; }
    public void Validate()
    {
        if (string.IsNullOrEmpty(FirstName))
            throw new Exception("First name is required");

        if (string.IsNullOrEmpty(LastName))
            throw new Exception("Last name is required");


        if (string.IsNullOrEmpty(Username))
            throw new Exception("Username is required");

        if (string.IsNullOrEmpty(Password))
            throw new Exception("Password is required");

        if (string.IsNullOrEmpty(Email))
            throw new Exception("Email is required");


        if (string.IsNullOrEmpty(PhoneNumber))
            throw new Exception("Phone number is required");
        
    }
}

