using DataAccess.Abstractions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Order> Create(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task Delete(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Order>> GetAll(int pageSize, int pageNumber)
        {
            IQueryable<Order> query = _context.Orders;
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return await query
                .Include(x => x.Items)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Order> GetById(int id) =>
        await _context.Orders
            .Include(x => x.Items)
            .AsNoTracking().
            SingleAsync();

        public async Task<Order> Update(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
