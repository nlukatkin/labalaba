using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Product> GetProduct(Guid animalId, bool trackChanges) =>
        FindByCondition(e => e.ProductId.Equals(animalId), trackChanges)
        .OrderBy(e => e.NameProduct);

        public Product GetProduct(Guid animalId, Guid id, bool trackChanges) =>
        FindByCondition(e => e.ProductId.Equals(animalId) && e.ProductId.Equals(id),
        trackChanges).SingleOrDefault();

        public void CreateProductForAnimal(Guid animalId, Product product)
        {
            product.AnimalId = animalId;
            Create(product);
        }
    }
}
