using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalogProduk.Domain
{
    public class Produk
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
