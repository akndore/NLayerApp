using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerApp.Core.Entities;

namespace NLayerApp.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product()
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Kalem 1",
                    Price = 100,
                    Stock = 20,
                    CreatedDate = DateTime.Now,
                },
                new Product()
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Kalem 2",
                    Price = 200,
                    Stock = 30,
                    CreatedDate = DateTime.Now,
                },
                new Product()
                {
                    Id = 3,
                    CategoryId = 1,
                    Name = "Kalem 3",
                    Price = 300,
                    Stock = 60,
                    CreatedDate = DateTime.Now,
                },
                new Product()
                {
                    Id = 4,
                    CategoryId = 2,
                    Name = "Kitap 1",
                    Price = 800,
                    Stock = 85,
                    CreatedDate = DateTime.Now,
                },
                new Product()
                {
                    Id = 5,
                    CategoryId = 2,
                    Name = "Kitap 2",
                    Price = 212,
                    Stock = 500,
                    CreatedDate = DateTime.Now,
                });
        }
    }
}
