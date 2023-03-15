using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public AnimalController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)

        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet("{id}", Name = "AnimalById")]
        public IActionResult GetAnimal(Guid id)
        {
            var animal = _repository.Animal.GetAnimal(id, trackChanges: false);
            if (animal == null)
            {
                _logger.LogInfo($"Animal with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var animalDto = _mapper.Map<AnimalDto>(animal);
                return Ok(animalDto);
            }
        }

        [HttpPost]
        public IActionResult CreateAnimal([FromBody] AnimalForCreationDto animal)
        {
            if (animal == null)
            {
                _logger.LogError("AnimalForCreationDto object sent from client is null.");
                return BadRequest("AnimalForCreationDto object is null");
            }
            var animalEntity = _mapper.Map<Animal>(animal);
            _repository.Animal.CreateAnimal(animalEntity);
            _repository.Save();
            var animalToReturn = _mapper.Map<AnimalDto>(animalEntity);
            return CreatedAtRoute("AnimalById", new { id = animalToReturn.AnimalId },
            animalToReturn);
        }

        [HttpPost("collection")]
        public IActionResult CreateAnimalCollection([FromBody] IEnumerable<AnimalForCreationDto>animalCollection)
        {
            if (animalCollection == null)
            {
                _logger.LogError("Animal collection sent from client is null.");
                return BadRequest("Animal collection is null");
            }
            var animalEntities = _mapper.Map<IEnumerable<Animal>>(animalCollection);
            foreach (var animal in animalEntities)
            {
                _repository.Animal.CreateAnimal(animal);
            }
            _repository.Save();
            var animalCollectionToReturn =
            _mapper.Map<IEnumerable<AnimalDto>>(animalEntities);
            var ids = string.Join(",", animalCollectionToReturn.Select(c => c.AnimalId));
            return CreatedAtRoute("AnimalCollection", new { ids }, animalCollectionToReturn);
        }
    }
}
