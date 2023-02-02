using DataAccess.Abstractions;
using DataAccess.Entities;
using DataAccess.Extentions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository

{
    public class UserRepository : IUserRepository
    {
        private readonly AppContext _context;

        public UserRepository(AppContext context)
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
            return await _context.Users
                .Page(pageSize, pageNumber)
                .AsNoTracking()
                .ToListAsync();
        }

        public async  Task<User?> GetByEmailAndPassword(string email, string password)
        {
            return await _context.Users
                .Where(x => x.Email == email && x.Password == password)
                .FirstAsync();
            
        }

        public async Task<User> GetById(int id) =>
        await _context.Users
            .AsNoTracking()
            .SingleAsync(x => x.Id == id);

        public async Task<User> Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}

