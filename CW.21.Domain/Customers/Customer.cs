using System.ComponentModel.DataAnnotations;
using Cw._21.Abstraction;
using CW._21.Domain.Orders;

namespace CW._21.Domain.Customers;

public class Customer : BaseEntity
{
    private Customer()
    {
        
    }
    public Customer(string fullname, string email, string phoneNumber, string username, string passwordHash)
    {
        Fullname = fullname;
        Email = email;
        PhoneNumber = phoneNumber;
        Username = username;
        PasswordHash = passwordHash;
    }
    

    [Required]
    [MaxLength(100)]
    public string Fullname { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Username { get; set; }
    
    
    [Required]
    [MaxLength(256)]
    public string PasswordHash { get; set; }
    
    [Required]
    [MaxLength(150)]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string PhoneNumber { get; set; }
    
    public bool IsAcive { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public List<Order> Orders { get; set; }

}