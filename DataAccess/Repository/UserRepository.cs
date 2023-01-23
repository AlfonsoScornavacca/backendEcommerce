using DataAccess.Abstractions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository

{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if(user != null)
            {
                _context.Users.Remove(user);
                await  _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<User>> GetAll(int pageSize, int pageNumber)
        {
            IQueryable<User> query = _context.Users;
            query = query.Skip((pageSize - 1) * pageSize).Take(pageNumber);
            return await query
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User> GetById(int id) =>
        await _context.Users
            .AsNoTracking().
            SingleAsync();

        public async Task<User> Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}

