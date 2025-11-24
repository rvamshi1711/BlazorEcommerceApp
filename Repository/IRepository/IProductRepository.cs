using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorEcommerceApp.Data;

namespace BlazorEcommerceApp.Repository.IRepository
{
    public interface IProductRepository
    {
        public Task<Product> CreateAsync(Product obj);
        public Task<Product> UpdateAsync(Product obj);
        public Task<bool> DeleteAsync(int id);
        public Task<Product> GetAsync(int id);
        public Task<IEnumerable<Product>> GetAllAsync();
    }
}