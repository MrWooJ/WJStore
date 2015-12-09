using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WJStore.Domain.Entities;

namespace WJStore.Data.Context.Config
{
    public class ContextInitializer : DropCreateDatabaseAlways<WJStoreContext>
    {
        protected override void Seed(WJStoreContext context)
        {
            var categories = new List<Category>
            {
                new Category { Name = "Mobile" },
                new Category { Name = "Laptop" },
                new Category { Name = "Hard" },
            };

            var owners = new List<Owner>
            {
                new Owner { Name = "Apple" },
                new Owner { Name = "Nokia" },
                new Owner { Name = "Sony" },
                new Owner { Name = "Samsung" },
                new Owner { Name = "BlackBerry" },

                new Owner { Name = "Vaio" },
                new Owner { Name = "Dell" },
                new Owner { Name = "Asus" },

                new Owner { Name = "Western Digital" },
                new Owner { Name = "Adata" },
            };

            new List<Product>
            {
                new Product { Title = "Apple iPhone 6 Plus - 64GB", Category = categories.Single(c => c.Name == "Mobile"), Price = 11.9M, Owner = owners.Single(o => o.Name == "Apple"), ProductArtUrl = "/Content/Images/placeholder.gif" },
                new Product { Title = "Apple iPhone 6 Plus - 16GB", Category = categories.Single(c => c.Name == "Mobile"), Price = 10.9M, Owner = owners.Single(o => o.Name == "Apple"), ProductArtUrl = "/Content/Images/placeholder.gif" },
                new Product { Title = "Apple iPhone 6 - 64GB", Category = categories.Single(c => c.Name == "Mobile"), Price = 9.9M, Owner = owners.Single(o => o.Name == "Apple"), ProductArtUrl = "/Content/Images/placeholder.gif" },
                new Product { Title = "Samsung Galaxy S6 -32GB SM-G920F", Category = categories.Single(c => c.Name == "Mobile"), Price = 8.99M, Owner = owners.Single(o => o.Name == "Samsung"), ProductArtUrl = "/Content/Images/placeholder.gif" },
                new Product { Title = "Samsung Galaxy A3 Dual SIM - 16GB - SM-A300H/DS", Category = categories.Single(c => c.Name == "Mobile"), Price = 7.99M, Owner = owners.Single(o => o.Name == "Samsung"), ProductArtUrl = "/Content/Images/placeholder.gif" },
                new Product { Title = "Sony Xperia Z2 D6502", Category = categories.Single(c => c.Name == "Mobile"), Price = 6.99M, Owner = owners.Single(o => o.Name == "Sony"), ProductArtUrl = "/Content/Images/placeholder.gif" },
                new Product { Title = "Sony Xperia Z Ultra", Category = categories.Single(c => c.Name == "Mobile"), Price = 4.99M, Owner = owners.Single(o => o.Name == "Sony"), ProductArtUrl = "/Content/Images/placeholder.gif" },

                new Product { Title = "Apple MacBook Pro MF839 with Retina Display - 13 inch Laptop", Category = categories.Single(c => c.Name == "Laptop"), Price = 99.99M, Owner = owners.Single(o => o.Name == "Apple"), ProductArtUrl = "/Content/Images/placeholder.gif" },
                new Product { Title = "Apple MacBook with Retina Display MF855 12 Inch", Category = categories.Single(c => c.Name == "Laptop"), Price = 84.99M, Owner = owners.Single(o => o.Name == "Apple"), ProductArtUrl = "/Content/Images/placeholder.gif" },
                new Product { Title = "Sony Vaio F23B9E", Category = categories.Single(c => c.Name == "Laptop"), Price = 77.99M, Owner = owners.Single(o => o.Name == "Sony"), ProductArtUrl = "/Content/Images/placeholder.gif" },
                new Product { Title = "VAIO Pro 13 SVP13215PX", Category = categories.Single(c => c.Name == "Laptop"), Price = 68.99M, Owner = owners.Single(o => o.Name == "Sony"), ProductArtUrl = "/Content/Images/placeholder.gif" },
                new Product { Title = "Asus Zenbook UX301LA - A - 13 inch Laptop", Category = categories.Single(c => c.Name == "Laptop"), Price = 73.99M, Owner = owners.Single(o => o.Name == "Asus"), ProductArtUrl = "/Content/Images/placeholder.gif" },
                new Product { Title = "ASUS X553MA - B - 15 inch Laptop", Category = categories.Single(c => c.Name == "Laptop"), Price = 64.99M, Owner = owners.Single(o => o.Name == "Asus"), ProductArtUrl = "/Content/Images/placeholder.gif" },

                new Product { Title = "Adata DashDrive Durable HD710 External Hard Drive - 1TB", Category = categories.Single(c => c.Name == "Hard"), Price = 25.99M, Owner = owners.Single(o => o.Name == "Adata"), ProductArtUrl = "/Content/Images/placeholder.gif" },
                new Product { Title = "Western Digital Elements External Hard Drive - 1TB", Category = categories.Single(c => c.Name == "Hard"), Price = 16.99M, Owner = owners.Single(o => o.Name == "Western Digital"), ProductArtUrl = "/Content/Images/placeholder.gif" },
                new Product { Title = "Adata DashDrive Durable HD650 External HDD - 1TB", Category = categories.Single(c => c.Name == "Hard"), Price = 15.99M, Owner = owners.Single(o => o.Name == "Adata"), ProductArtUrl = "/Content/Images/placeholder.gif" },

            }.ForEach(o => context.Products.Add(o));

            context.SaveChanges();
        }
    }
}