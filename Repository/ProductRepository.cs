using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorEcommerceApp.Data;
using BlazorEcommerceApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerceApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Product> CreateAsync(Product obj)
        {
            await _db.Product.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _db.Product.FindAsync(id);
            if (product != null)
            {
                _db.Product.Remove(product);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }

        public async Task<Product> GetAsync(int id)
        {
            var obj = await _db.Product.FirstOrDefaultAsync(u => u.Id == id);
            if (obj == null)
            {
                return new Product();
            }
            return obj;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Product.ToListAsync();
        }

        public async Task<Product> UpdateAsync(Product obj)
        {
            var product = await _db.Product.FirstOrDefaultAsync(u => u.Id == obj.Id);
            if (product != null)
            {
                product.Name = obj.Name;
                product.Price = obj.Price;
                product.Description = obj.Description;
                product.CategoryId = obj.CategoryId;
                _db.Product.Update(product);
                await _db.SaveChangesAsync();
                return product;
            }
            return obj;
        }
    }
}