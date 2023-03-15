using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using LoggerService;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers
{

    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ProductController(IRepositoryManager repository, ILoggerManager
       logger,
        IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProductForAnimal(Guid animalId)
        {
            var animal = _repository.Animal.GetAnimal(animalId, trackChanges: false);
            if (animal == null)
            {
                _logger.LogInfo($"Animal with id: {animalId} doesn't exist in the database.");
            return NotFound();
            }

            var productFromDb = _repository.Product.GetProduct(animalId,
            trackChanges: false);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productFromDb);
            return Ok(productDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductForAnimal(Guid animalId, Guid id)
        {
            var animal = _repository.Animal.GetAnimal(animalId, trackChanges: false);
            if (animal == null)
            {
                _logger.LogInfo($"Animal with id: {animalId} doesn't exist in the database.");
                 return NotFound();
            }
            var productDb = _repository.Product.GetProduct(animalId, id,
           trackChanges:
            false);
            if (productDb == null)
            {
                _logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
            return NotFound();
            }
            var product = _mapper.Map<ProductDto>(productDb);
            return Ok(product);
        }
    }
}
