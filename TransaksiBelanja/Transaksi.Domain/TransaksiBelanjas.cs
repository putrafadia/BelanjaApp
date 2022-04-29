using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaksi.Domain
{
    public class TransaksiBelanjas
    {
        public int Id { get; set; }
        public DateTime TanggalTransaksi { get; set; }
        public int IdProduk { get; set; }
    }
}
