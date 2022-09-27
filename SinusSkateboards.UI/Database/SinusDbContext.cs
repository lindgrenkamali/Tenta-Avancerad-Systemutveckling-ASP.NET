
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SinusSkateboards.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinusSkateboards.UI.Databas
{
    public class SinusDbContext : IdentityDbContext<AdminModel>
    {
        public DbSet<UserModel> User { get; set; }
        public DbSet<ProductModel> Product { get; set; }

        public DbSet<ProductQuantityModel> ProductQuantity { get; set; }

        public DbSet<OrderModel> Order {get; set;}
        public DbSet<ColorModel> Color { get; set; }
        public DbSet<CategoryModel> Category { get; set; }

        public SinusDbContext(DbContextOptions<SinusDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<ColorModel>().HasData(
                new ColorModel { ColorID = 1, ColorName = "Blue" },
                new ColorModel { ColorID = 2, ColorName = "Red" },
                new ColorModel { ColorID = 3, ColorName = "Grey" },
                new ColorModel { ColorID = 4, ColorName = "Green" },
                new ColorModel { ColorID = 5, ColorName = "Purple" },
                new ColorModel { ColorID = 6, ColorName = "Yellow" },
                new ColorModel { ColorID = 7, ColorName = "Pink" },
                 new ColorModel { ColorID = 8, ColorName = "White" },
                new ColorModel { ColorID = 9, ColorName = "Multi-colored"},
                 new ColorModel { ColorID = 10, ColorName = "None" }
                );

            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { CategoryID = 1, CategoryName = "Hoodie" },
                new CategoryModel { CategoryID = 2, CategoryName = "Skateboard" },
                new CategoryModel { CategoryID = 3, CategoryName = "Cap" },
                new CategoryModel { CategoryID = 4, CategoryName = "T-shirt" },
                new CategoryModel { CategoryID = 5, CategoryName = "Wheel" }

                );

            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel { ProductID = 1, Title = "Purple hoodie", CategoryID = 1, ColorID = 5, Description = "100% cotton", PhotoPath = "hoodie-purple.png", Price = 499m },
                    new ProductModel { ProductID = 2, Title = "Fire hoodie", CategoryID = 1, ColorID = 2, Description = "100% cotton", PhotoPath = "hoodie-fire.png", Price = 499m },
                    new ProductModel { ProductID = 3, Title = "Blue cap", CategoryID = 3, ColorID = 1, Description = "100% polyester", PhotoPath = "sinus-cap-blue.png", Price = 299m },
                    new ProductModel { ProductID = 4, Title = "Blue T-shirt", CategoryID = 4, ColorID = 1, Description = "100% cotton", PhotoPath = "sinus-tshirt-blue.png", Price = 349m },
                    new ProductModel { ProductID = 5, Title = "Ink skateboard", CategoryID = 2, ColorID = 9, Description = "2% glue, 98% maple", PhotoPath = "sinus-skateboard-ink.png", Price = 999m },
                    new ProductModel { ProductID = 6, Title = "Spinner wheel", CategoryID = 5, ColorID = 8, Description = "4-pack, 100% PU-gummy", PhotoPath = "sinus-wheel-spinner.png", Price = 289m },
                    new ProductModel { ProductID = 7, Title = "Purple cap", CategoryID = 3, ColorID = 5, Description = "100% polyester", PhotoPath = "sinus-cap-purple.png", Price = 299m },
                    new ProductModel { ProductID = 8, Title = "Yellow T-shirt", CategoryID = 4, ColorID = 6, Description = "100% cotton", PhotoPath = "sinus-tshirt-yellow.png", Price = 349m },
                    new ProductModel { ProductID = 9, Title = "Purple T-shirt", CategoryID = 4, ColorID = 5, Description = "100% cotton", PhotoPath = "sinus-tshirt-purple.png", Price = 349m },
                    new ProductModel { ProductID = 10, Title = "Yellow skateboard", CategoryID = 2, ColorID = 6, Description = "2% glue, 98% maple", PhotoPath = "sinus-skateboard-yellow.png", Price = 999m },
                    new ProductModel { ProductID = 11, Title = "Fire skateboard", CategoryID = 2, ColorID = 9, Description = "2% glue, 98% maple", PhotoPath = "sinus-skateboard-fire.png", Price = 999m },
                    new ProductModel { ProductID = 12, Title = "Northern lights skateboard", CategoryID = 2, ColorID = 9, Description = "2% glue, 98% maple", PhotoPath = "sinus-skateboard-northern_lights.png", Price = 999m },
                    new ProductModel { ProductID = 13, Title = "Pink T-shirt", CategoryID = 4, ColorID = 7, Description = "100% cotton", PhotoPath = "sinus-tshirt-pink.png", Price = 349m },
                    new ProductModel { ProductID = 14, Title = "Logo skateboard", CategoryID = 2, ColorID = 10, Description = "2% glue, 98% maple", PhotoPath = "sinus-skateboard-logo.png", Price = 999m },
                    new ProductModel { ProductID = 15, Title = "Purple skateboard", CategoryID = 2, ColorID = 5, Description = "2% glue, 98% maple", PhotoPath = "sinus-skateboard-purple.png", Price = 999m },
                    new ProductModel { ProductID = 16, Title = "Ocean hoodie", CategoryID = 1, ColorID = 1, Description = "100% cotton", PhotoPath = "hoodie-ocean.png", Price = 499m },
                    new ProductModel { ProductID = 17, Title = "Red cap", CategoryID = 3, ColorID = 2, Description = "100% polyester", PhotoPath = "sinus-cap-red.png", Price = 299m },
                    new ProductModel { ProductID = 18, Title = "Green cap", CategoryID = 3, ColorID = 4, Description = "100% polyester", PhotoPath = "sinus-cap-green.png", Price = 299m },
                    new ProductModel { ProductID = 19, Title = "Rocket wheel", CategoryID = 5, ColorID = 8, Description = "4-pack, 100% PU-gummy", PhotoPath = "sinus-wheel-rocket.png", Price = 289m },
                    new ProductModel { ProductID = 20, Title = "Grey T-shirt", CategoryID = 4, ColorID = 3, Description = "100% cotton", PhotoPath = "sinus-tshirt-grey.png", Price = 349m },
                    new ProductModel { ProductID = 21, Title = "Eagle skateboard", CategoryID = 2, ColorID = 9, Description = "2% glue, 98% maple", PhotoPath = "sinus-skateboard-eagle.png", Price = 999m },
                    new ProductModel { ProductID = 22, Title = "Gretasfury skateboard", CategoryID = 2, ColorID = 9, Description = "2% glue, 98% maple", PhotoPath = "sinus-skateboard-gretasfury.png", Price = 999m },
                    new ProductModel { ProductID = 23, Title = "Plastic skateboard", CategoryID = 2, ColorID = 9, Description = "2% glue, 98% maple", PhotoPath = "sinus-skateboard-plastic.png", Price = 999m },
                    new ProductModel { ProductID = 24, Title = "Wave wheel", CategoryID = 5, ColorID = 8, Description = "4-pack, 100% PU-gummy", PhotoPath = "sinus-wheel-wave.png", Price = 289m },
                    new ProductModel { ProductID = 25, Title = "Ash hoodie", CategoryID = 1, ColorID = 3, Description = "100% cotton", PhotoPath = "hoodie-ash.png", Price = 499m },
                    new ProductModel { ProductID = 26, Title = "Green hoodie", CategoryID = 1, ColorID = 4, Description = "100% cotton", PhotoPath = "hoodie-green.png", Price = 499m },
                    new ProductModel { ProductID = 27, Title = "Polar skateboard", CategoryID = 2, ColorID = 9, Description = "2% glue, 98% maple", PhotoPath = "sinus-skateboard-polar.png", Price = 999m }


                );
            base.OnModelCreating(modelBuilder);

        }



    }
}
