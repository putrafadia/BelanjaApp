using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaksi.Data.Interface;
using Transaksi.Domain;

namespace Transaksi.Data
{
    public class TransaksiRepo : ITransaksi
    {
        private readonly TransaksiContext _context;

        public TransaksiRepo(TransaksiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TransaksiBelanjas>> GetAll()
        {
            var result = await _context.TransaksiBelanja.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<TransaksiBelanjas> GetById(int id)
        {
            var result = await _context.TransaksiBelanja.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data Transaksi id: {id} tidak ditemukan");
            return result;
        }

        public async Task<TransaksiBelanjas> Insert(TransaksiBelanjas obj)
        {
            try
            {
                //ditampilkan obj yg berhasil ditambahkan
                _context.TransaksiBelanja.Add(obj);
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

        public async Task<TransaksiBelanjas> Update(int id, TransaksiBelanjas obj)
        {
            try
            {
                var updateTransaksi = await GetById(id);                                
                updateTransaksi.TanggalTransaksi = obj.TanggalTransaksi;          
                await _context.SaveChangesAsync();                                  
                return updateTransaksi;                                              
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

        public async Task Delete(int id)
        {
            try
            {
                var deleteTransaksi = await GetById(id);
                _context.TransaksiBelanja.Remove(deleteTransaksi);
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
