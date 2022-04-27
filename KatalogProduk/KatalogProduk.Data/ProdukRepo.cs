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
    public class ProdukRepo : IProduk
    {
        private readonly KatalogProdukContext _context;

        public ProdukRepo(KatalogProdukContext context)
        {
            _context = context;
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Produk>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Produk>> GetAllProduk(int categoryId)
        {
            return _context.Produks.Where(c => c.CategoryId == categoryId)
                .OrderBy(c => c.Category.Name);
        }

        public async Task<Produk> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Produk> GetProduk(int categoryId, int produkId)
        {
            return _context.Produks.Where(c => c.CategoryId == categoryId &&
                c.Id == produkId).FirstOrDefault();
        }

        public async Task<Produk> Insert(Produk obj)
        {
            throw new NotImplementedException();
        }

        public Task<Produk> Update(int id, Produk obj)
        {
            throw new NotImplementedException();
        }

        
    }
}
