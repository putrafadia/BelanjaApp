using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaksi.Domain;

namespace Transaksi.Data
{
    public class TransaksiContext : DbContext
    {
        public TransaksiContext()
        {
           
        }
        public TransaksiContext(DbContextOptions<TransaksiContext> Options) : base(Options)
        {

        }
        public DbSet<TransaksiBelanjas> TransaksiBelanja { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                 "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DataTransaksiDb");
                 /*.LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Name},
                 Microsoft.Extensions.Logging.LogLevel.Information)
                 .EnableSensitiveDataLogging();*/

            /*if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TransaksiBelanjaDB");
            }*/
        }
    }
}
