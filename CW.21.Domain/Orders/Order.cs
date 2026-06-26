using System.ComponentModel.DataAnnotations;
using Cw._21.Abstraction;
using CW._21.Domain.Customers;
using CW._21.Domain.DTOs.OrderItems;
using CW._21.Domain.OrderItems;

namespace CW._21.Domain.Orders;

public class Order : BaseEntity
{
    public Order(int customerId, DateTime orderDate, string status,List<OrderItem> items)
    {
        CustomerId = customerId;
        OrderDate = orderDate;
        Status = status;
        OrderItems = items;
    }

    private Order()
    {
        
    }
    
    
    public Order(int customerId, DateTime orderDate, decimal totalAmount, string status, Customer customer)
    {
        CustomerId = customerId;
        OrderDate = orderDate;
        TotalAmount = totalAmount;
        Status = status;
        Customer = customer;
    }

    [Required]
    public int CustomerId { get; set; }
    
    [Required]
    public DateTime OrderDate { get; set; }
    
    [Required]
    public decimal TotalAmount { get; set; }

    [Required]
    [MaxLength(50)]
    public string Status { get; set; }
    
    
    public Customer Customer { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new();
}