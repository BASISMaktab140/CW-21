using CW._21.Domain.Customers;
using CW._21.Infrastructures.Data;
using CW._21.Infrastructures.Repositories.Generics;

namespace CW._21.Infrastructures.Repositories.Customers;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(AppDbContext context) : base(context)
    {
    }
}