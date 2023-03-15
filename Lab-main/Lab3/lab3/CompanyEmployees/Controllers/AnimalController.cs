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
        [HttpGet]
        public IActionResult GetAnimal()
        {
            var animals = _repository.Animal.GetAllAnimal(trackChanges: false);
            var animalsDto = _mapper.Map<IEnumerable<AnimalDto>>(animals);
            return Ok(animalsDto);
        }
    }
}
