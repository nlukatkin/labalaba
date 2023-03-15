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
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasData
            (
            new Animal
            {
                Id = 1,
                AnimalName = "Кот",
                WeightKg = 14
            },
            new Animal
            {
                Id = 2,
                AnimalName = "Собака",
                WeightKg = 3
            }
            );
        }
    }
}
