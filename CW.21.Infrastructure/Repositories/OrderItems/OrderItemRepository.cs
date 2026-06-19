using CW._21.Domain.OrderItems;
using CW._21.Infrastructures.Data;
using CW._21.Infrastructures.Repositories.Generics;

namespace CW._21.Infrastructures.Repositories.OrderItems;

public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(AppDbContext context) : base(context)
    {
    }
}