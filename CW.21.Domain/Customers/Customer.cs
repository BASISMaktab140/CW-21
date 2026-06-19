using System.ComponentModel.DataAnnotations;
using Cw._21.Abstraction;
using CW._21.Domain.Orders;

namespace CW._21.Domain.Customers;

public class Customer : BaseEntity
{
    private Customer()
    {
        
    }
    public Customer(string fullname, string email, string phoneNumber)
    {
        Fullname = fullname;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    [Required]
    [MaxLength(100)]
    public string Fullname { get; set; }
    
    [Required]
    [MaxLength(150)]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string PhoneNumber { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }
    
    public List<Order> Orders { get; set; }
}