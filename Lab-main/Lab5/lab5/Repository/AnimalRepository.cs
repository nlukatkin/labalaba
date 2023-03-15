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
    public class AnimalRepository : RepositoryBase<Animal>, IAnimalRepository
    {
        public AnimalRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
        }

        public IEnumerable<Animal> GetAllAnimal(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.AnimalName).ToList();

        public Animal GetAnimal(Guid animalId, bool trackChanges) => FindByCondition(c
            => c.Id.Equals(animalId), trackChanges).SingleOrDefault();

        public void CreateAnimal(Animal animal) => Create(animal);

        public IEnumerable<Animal> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.guid), trackChanges).ToList();
    }
}
