using DeliVeggieService.Entity;
using DeliVeggieService.Infrastructure;
using DeliVeggieService.Logger;
using Microsoft.AspNetCore.Mvc;
using static DeliVeggieService.Infrastructure.DTO;

namespace DeliVeggieService.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ILoggerManager logger;
        private readonly IRepository<Product> repository;
        private readonly IRepository<PriceReductions> prrepository;
        public ProductController(IRepository<Product> repository, IRepository<PriceReductions> prrepository, ILoggerManager logger)
        {
            this.repository = repository;
            this.prrepository = prrepository;
            this.logger = logger;
        }

        /// <summary>
        /// This method gets all the products from the DB
        /// </summary>
        /// <returns>List of all products</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAsync()
        {
            logger.LogInfo("Fetching all products");
            var allProductsList = (await repository.GetAllAsync()).Select(a => a.AsDto());

            return Ok(allProductsList);
        }

        /// <summary>
        /// This method gets details of a product with discounted price for the day from the DB
        /// </summary>
        /// <param name="id">unique id of a product</param>
        /// <returns>product detail with discounted price</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetByIdAsync(Guid id)
        {
            var priceReductionsDetails = (await prrepository.GetAllAsync()).Select(a => a.AsDto());

            var productDetail = await repository.GetAsync(id);

            Product product = priceReductionsDetails.GetPriceReduction(productDetail);

            if (product == null)
            {
                return NotFound();
            }

            return product.AsDto();
        }

        /// <summary>
        /// This is used to add details of a product to the DB
        /// </summary>
        /// <param name="createProductDto"></param>
        /// <returns>204</returns>
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostAsync(CreateProductDto createProductDto)
        {
            var Product = new Product
            {
                Name = createProductDto.Name,
                EntryDate = DateTime.UtcNow,
                Price = createProductDto.Price,
            };

            await repository.CreateAsync(Product);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = Product.Id }, Product);
        }

    }
}
