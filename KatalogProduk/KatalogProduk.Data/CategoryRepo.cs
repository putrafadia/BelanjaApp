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
        public async Task Delete(int id)
        {
            try
            {
                var deletePedang = await GetById(id);
                _context.Categories.Remove(deletePedang);
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

        public async Task<IEnumerable<Category>> GetAll()
        {
            var results = await _context.Categories.Include(p=>p.Produks).OrderBy(s => s.Name).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<Category> GetById(int id)
        {
            var result = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data Kategori id: {id} Tidak ditemukan");
            return result;
        }

        public async Task<Category> Insert(Category obj)
        {

            try
            {
                _context.Categories.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
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

        public async Task<Category> Update(int id, Category obj)
        {
            try
            {
                var updateKategori = await GetById(id);
                updateKategori.Name = obj.Name;
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
    }
}
