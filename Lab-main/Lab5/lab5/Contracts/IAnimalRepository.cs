using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> GetAllAnimal(bool trackChanges);
        Animal GetAnimal(Guid animalId, bool trackChanges);
        void CreateAnimal(Animal animal);
        IEnumerable<Animal> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    }
}
