using Microsoft.EntityFrameworkCore;
using Shipping.Data.Interface;
using Shipping.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Data.Repo
{
    public class ShippingRepo : IShipping
    {
        private readonly ShippingContext _context;

        public ShippingRepo(ShippingContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var deleteShipping = await GetById(id);
                _context.Sending.Remove(deleteShipping);
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

        public async Task<IEnumerable<Pengiriman>> GetAll()
        {
            var results = await _context.Sending.AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<Pengiriman> GetById(int id)
        {
            var results = await _context.Sending/*.Include(s => s.Swords)*/.FirstOrDefaultAsync(s => s.Id == id);
            if (results == null) throw new Exception($"Data produk id: {id} tidak ditemukan");
            return results;
        }

        public async Task<Pengiriman> Insert(Pengiriman obj)
        {
            try
            {
                _context.Sending.Add(obj);
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

        public async Task<Pengiriman> Update(int id, Pengiriman obj)
        {
            try
            {
                var updateshipping = await GetById(id);
                updateshipping.NameKurir = obj.NameKurir;
                await _context.SaveChangesAsync();
                return updateshipping;
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
