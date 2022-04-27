using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalogProduk.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Produk> Produks { get; set; } = new List<Produk>();
    }
}
