using KatalogProduk.Data.Interface;
using KatalogProduk.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalogProduk.Data
{
    public class CategoryRepo : ICategory
    {
        private readonly KatalogProdukContext _context;

        public CategoryRepo(KatalogProdukContext context)
        {
            _context = context;
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var results = await _context.Categories.OrderBy(s => s.Name).AsNoTracking().ToListAsync();
            return results;
        }

        public Task<Category> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Insert(Category obj)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Update(int id, Category obj)
        {
            throw new NotImplementedException();
        }
    }
}
