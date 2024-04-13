using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _db;
        public OrderService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<Order> GetOrder()
        {
           return Task.FromResult( _db.Orders
               .OrderByDescending(x => x.Price)
               .FirstOrDefault());
        }

        public Task<List<Order>> GetOrders()
        {
            return Task.FromResult(_db.Orders
                .Where(x=> x.Quantity>10)
                .ToList());
        }
    }
}
