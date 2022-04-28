
using Microsoft.EntityFrameworkCore;
using Shipping.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Data
{
    public class ShippingContext : DbContext
    {
        public ShippingContext(DbContextOptions<ShippingContext> options) : base(options)
        {

        }
        public DbSet<Pengiriman> Sending { get; set; }
       

    }
}