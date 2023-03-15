using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData
            (
            new Product
            {
                ProductId = 1,
                NameProduct = "Носки",
                Cost = 100,
                Quantity=4
            },
            new Product
            {
                ProductId = 2,
                NameProduct = "Шапка",
                Cost = 400,
                Quantity=5
            }
            );
        }
    }
}
