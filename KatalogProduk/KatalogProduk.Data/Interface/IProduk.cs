using KatalogProduk.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalogProduk.Data.Interface
{
    public interface IProduk : ICrud<Produk>
    {
        Task<Produk> GetProduk(int categoryId, int produkId);
        Task<IEnumerable<Produk>> GetAllProduk(int categoryId);
    }
}
