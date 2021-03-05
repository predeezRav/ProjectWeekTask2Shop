using ProjectShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShop.Data
{
    public class DbInitializer
    {
        public static void Initialize(ProductShopContext context)
        {
            context.Database.EnsureCreated();

            // Look for any products.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var products = new Product[]
            {
                new Product{Navn="Fancy", Beskrivelse="Lidt dyr, bro", Billeder="https://img01.ztat.net/article/spp-media-p1/f584ce49fe2a35dbbef8317541b69090/8794de55f9bd4690998043bf0af8d484.jpg?imwidth=156&filter=packshot", Farver="Teal", Pris=450, Size=28 },
                new Product{Navn="Fancy", Beskrivelse="Fræk kjole til mænd og kvinder", Billeder="Something", Farver="Rød", Pris=450, Size=28 }

            };

            context.Products.AddRange(products);
            context.SaveChanges();

            var tøjtyper = new Tøjtype[] { 
            
            new Tøjtype { Titel="Kjoler", TøjtypeID=001},
            new Tøjtype { Titel="Toppe", TøjtypeID=002},
            new Tøjtype { Titel="Skjorte", TøjtypeID=003},
            new Tøjtype { Titel="Bluser", TøjtypeID=004},
            new Tøjtype { Titel="Blazer", TøjtypeID=005},
            new Tøjtype { Titel="Strik", TøjtypeID=006},
            new Tøjtype { Titel="Bukser", TøjtypeID=007},
            new Tøjtype { Titel="Sko", TøjtypeID=008}


            };

            context.Tøjtyper.AddRange(tøjtyper);
            context.SaveChanges();

            var kvinder = new Kvinde[]
            {
                new Kvinde{ ProductID=1, TøjtypeID=001},
                new Kvinde{ ProductID=2, TøjtypeID=001}
                
            };

            context.Kvinder.AddRange(kvinder);
            context.SaveChanges();


        }
    }
}
    