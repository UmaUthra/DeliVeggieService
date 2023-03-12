using DeliVeggieService.Entity;
using DeliVeggieService.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using static DeliVeggieService.Infrastructure.DTO;

namespace DeliVeggieService.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class PriceReductionsController : ControllerBase
    {
        private readonly IRepository<PriceReductions> prrepository;
        public PriceReductionsController(IRepository<PriceReductions> prrepository)
        {
            this.prrepository = prrepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PriceReductionsDto>> GetByIdAsync(Guid id)
        {
            var item = await prrepository.GetAsync(id);
            if (item == null)
            {
                NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<PriceReductionsDto>> PostAsync(CreatePriceReductionsDto createPriceReductionsDto)
        {
            var PriceReductions = new PriceReductions
            {
                DayOfWeek = createPriceReductionsDto.DayOfWeek,
                Reduction = createPriceReductionsDto.Reduction,
            };

            await prrepository.CreateAsync(PriceReductions);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = PriceReductions.Id }, PriceReductions);
        }

    }
}
