using DataAccess.Abstractions;
using DataAccess.Entities;
using DataAccess.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppContext _context;

        public ProductRepository(AppContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Product>> GetAll(int pageSize, int pageNumber)
        {
            return await _context.Products
                .Page(pageSize, pageNumber)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<ICollection<Product>> Search(int pageSize, int pageNumber, string name)
        {
            return await _context.Products
                .FilterByName(name)
                .Page(pageSize, pageNumber)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product> GetById(int id) =>
        await _context.Products
            .AsNoTracking().
            SingleAsync();

        public async Task<Product> Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
