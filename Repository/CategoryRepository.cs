using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorEcommerceApp.Data;
using BlazorEcommerceApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerceApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Category> CreateAsync(Category obj)
        {
            await _db.Category.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _db.Category.FindAsync(id);
            if (category != null)
            {
                _db.Category.Remove(category);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }

        public async Task<Category> GetAsync(int id)
        {
            var obj = await _db.Category.FirstOrDefaultAsync(u => u.Id == id);
            if (obj == null)
            {
                return new Category();
            }
            return obj;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _db.Category.ToListAsync();
        }

        public async Task<Category> UpdateAsync(Category obj)
        {
            var category = await _db.Category.FirstOrDefaultAsync(u => u.Id == obj.Id);
            if (category != null)
            {
                category.Name = obj.Name;
                _db.Category.Update(category);
                await _db.SaveChangesAsync();
                return category;
            }
            return obj;
        }
    }
}