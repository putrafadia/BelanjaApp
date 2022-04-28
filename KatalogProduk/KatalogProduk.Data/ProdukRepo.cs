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

        public async Task<Produk> CreateProduk(int categoryId, Produk produk)
        {
            if (produk == null)
                throw new ArgumentNullException(nameof(produk));

            produk.CategoryId = categoryId;
            _context.Produks.Add(produk);
            await _context.SaveChangesAsync();
            return produk;
        }

        public async Task<Produk> GetProduk(int categoryId, int produkId)
        {
            return await _context.Produks.Where(c => c.CategoryId == categoryId &&
                c.Id == produkId).FirstOrDefaultAsync();
        }

        public bool CategoryExist(int categoryId)
        {
            return _context.Categories.Any(p => p.Id == categoryId);
        }

        public async Task<IEnumerable<Produk>> GetAllProduk(int categoryId)
        {
            return await _context.Produks.Where(c=>c.CategoryId == categoryId).ToListAsync();
        }

        public async Task<Produk> UpdateProduk(int categoryId, int produkId, Produk produk)
        {
            try
            {
                var updateKategori = await GetProduk(categoryId,produkId);
                updateKategori.Name = produk.Name;
                await _context.SaveChangesAsync();
                return updateKategori;
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(int categoryId, int produkId)
        {
            try
            {
                var deleteProduk = await GetProduk(categoryId,produkId);
                _context.Produks.Remove(deleteProduk);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
