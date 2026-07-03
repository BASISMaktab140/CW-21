using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using CW._21.Domain.Orders;

namespace CW._21.Domain.Customers;

public class Customer : IdentityUser, IAudible
{
    public Customer()
    {

    }
    public Customer(string firstName, string lastName, string username,
        string passwordHash, string phoneNumber, string email )
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = username;
        PasswordHash = passwordHash;
        PhoneNumber = phoneNumber;
        Email = email;
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
    public override string UserName { get; set; }
    [Required]

    [EmailAddress(ErrorMessage = "Not valid Email Address")]
    public override string Email { get; set; }
    [Required]
    public override string PasswordHash { get; set; }
    
    
    [Required]
    [MinLength(10)]
    [MaxLength(11)]
    public override string PhoneNumber { get; set; }

    public List<Order> Orders { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime ModifiedAt { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public void Validate()
    {
        if (string.IsNullOrEmpty(FirstName))
            throw new Exception("First name is required");

        if (string.IsNullOrEmpty(LastName))
            throw new Exception("Last name is required");


        if (string.IsNullOrEmpty(UserName))
            throw new Exception("Username is required");

        if (string.IsNullOrEmpty(PasswordHash))
            throw new Exception("Password is required");

        if (string.IsNullOrEmpty(Email))
            throw new Exception("Email is required");


        if (string.IsNullOrEmpty(PhoneNumber))
            throw new Exception("Phone number is required");
        
    }
}

