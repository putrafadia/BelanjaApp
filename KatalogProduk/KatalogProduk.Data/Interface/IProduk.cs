using KatalogProduk.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalogProduk.Data.Interface
{
    public interface IProduk 
    {
        Task<Produk> GetProduk(int categoryId, int produkId);
        Task<IEnumerable<Produk>> GetAllProduk(int categoryId);
        Task<Produk> CreateProduk(int categoryId,Produk produk);
        Task<Produk> UpdateProduk(int categoryId, int produkId, Produk produk);
        bool CategoryExist(int categoryId);
        Task Delete(int categoryId, int produkId);
    }
}
