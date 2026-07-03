using System.ComponentModel.DataAnnotations;
using CW._21.Domain.Books;
using CW._21.Domain.Orders;

namespace CW._21.Domain.OrderItems;

public class OrderItem : BaseEntity
{
    private OrderItem()
    {
        
    }

    public OrderItem(int bookId, int quantity, decimal unitPrice)
    {
        BookId = bookId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public OrderItem(int orderId, int bookId, int quantity, decimal unitPrice, Order order, Book book)
    {
        OrderId = orderId;
        BookId = bookId;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Order = order;
        Book = book;
    }

    [Required]
    public int OrderId { get; set; }

    [Required]
    public int BookId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
    
    [Required]
    public decimal UnitPrice { get; set; }
    
    
    public Order Order { get; set; }
    public Book Book { get; set; }
}