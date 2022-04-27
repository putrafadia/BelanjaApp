using KatalogProduk.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalogProduk.Data
{
    public class PrebDb
    {

        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateAsyncScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<KatalogProdukContext>());
            }
        }

        private static void SeedData(KatalogProdukContext context)
        {
           
            if (!context.Categories.Any())
            {
                Console.WriteLine("--> Seeding Data...");
                context.Categories.AddRange(
                    new Category { Name = "Pria"},
                    new Category { Name = "Wanita" },
                    new Category { Name ="Anak-Anak"}
                );
                context.Produks.AddRange(
                   new Produk { Name = "Celana Pendek",CategoryId= 1 },
                   new Produk { Name = "Kaos", CategoryId = 2 },
                   new Produk { Name = "Sepatu", CategoryId = 3 }
                   );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Data Kategori sudah ada..");
            }
        }
    }
}
