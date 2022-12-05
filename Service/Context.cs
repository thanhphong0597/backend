using clothes_backend.Entities.Cart;
using clothes_backend.Entities.Dal;
using Microsoft.EntityFrameworkCore;

namespace clothes_backend.Service
{
    public class Context : DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Attri> attries { get; set; }
        public DbSet<Stock> stocks { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public Context(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder b)
        {
            b.ApplyConfiguration(new StockConfig());
            b.Initial();
        }
        
    }
    public static class Dulieumau
    {
        public static void Initial (this ModelBuilder b)
        {
            b.Entity<Category>().HasData(
                new Category { id = 1, name = "Men's Clothing" },
                new Category { id = 2, name = "Women's Clothing" },
                new Category { id = 3, name = "Jewelery" }

            );

            b.Entity<Product>().HasData(
                new Product { 
                    id=1, 
                    name= "Mens Casual Premium Slim Fit T - Shirts",
                    price=33.4,
                    title="Men",
                    categoryID=1
                },
                new Product
                {
                    id = 2,
                    name = "Mens Cotton Jacket ",
                    price = 12.4,
                    title = "Men",
                    categoryID=1
                },
                new Product
                {
                    id = 3,
                    name = "Ao nu 1",
                    price = 33.4,
                    title = "Women",
                    categoryID=2
                },
                new Product
                {
                    id = 4,
                    name = "Vong Vang nay no a",
                    price = 33.4,
                    title = "Jewelery",
                    categoryID = 3

                }
                );

            b.Entity<Attri>().HasData(
                new Attri { id=1,color="red",number=2,size=38},
                new Attri { id = 2, color = "green", number = 3, size = 40 },
                new Attri { id = 3, color = "red", number = 1, size = 39 },
                new Attri { id = 4, color = "red", number = 2, size = 41 },
                new Attri { id = 5, color = "yellow", number = 2 }

                );
            b.Entity<Stock>().HasData(
                new Stock { productID=1,attriID=1},
                new Stock { productID = 1, attriID = 2 },
                new Stock { productID = 2, attriID = 3 },
                new Stock { productID = 3, attriID = 4 },
                new Stock { productID = 4, attriID = 5 }
                );
        }
    }
}
