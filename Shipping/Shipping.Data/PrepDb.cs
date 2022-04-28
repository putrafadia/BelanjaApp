using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shipping.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Data
{
    public class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateAsyncScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ShippingContext>());
            }
        }
        private static void SeedData(ShippingContext context)
        {

            if (!context.Sending.Any())
            {

                Console.WriteLine("--> Seeding Data...");
                context.Sending.AddRange(
                    new Pengiriman { NameKurir = "JNE" },
                    new Pengiriman { NameKurir = "TiKi" },
                    new Pengiriman { NameKurir = "Si Cepat" },
                    new Pengiriman { NameKurir = "Anteraja"}
                );
               
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Seeding Data...");
            }
        }
    }
}
