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
        [HttpGet("{id}")]
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
    }
}
