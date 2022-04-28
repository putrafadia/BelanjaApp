using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Domain
{
    public class Pengiriman
    {
        public int Id { get; set; }
        public string NameKurir { get; set; }
        public int IdTransaksi { get; set; }
    }
}
