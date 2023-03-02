using Core.Models;
using Infrastructure;

namespace UnitOfWork
{
    public static class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicatioBuilder)
        {
            using (var serviceScope = applicatioBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Products
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<ProductDetails>()
                    {
                        new ProductDetails()
                        {
                           ProductName = "Sport-100 Helmet, Red",
                           ProductDescription = "Chromoly steel.",
                           ProductPrice = 34,
                           ProductStock = 4
                        },
                        new ProductDetails()
                        {
                           ProductName = "Long-Sleeve Logo Jersey, M",
                           ProductDescription = "100% cotton.",
                           ProductPrice = 50,
                           ProductStock = 6
                        },
                        new ProductDetails()
                        {
                           ProductName = "Road-650 Black, 44",
                           ProductDescription = "Lightweight aluminum alloy construction.",
                           ProductPrice = 349,
                           ProductStock = 1
                        },
                        new ProductDetails()
                        {
                           ProductName = "Headlights - Dual-Beam",
                           ProductDescription = "Designed to absorb shock.",
                           ProductPrice = 35,
                           ProductStock = 3
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
