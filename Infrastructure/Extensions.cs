using DeliVeggieService.Entity;
using static DeliVeggieService.Infrastructure.DTO;

namespace DeliVeggieService.Infrastructure
{
    public static class Extensions
    {
        public static ProductDto AsDto(this Product product)
        {
            return new ProductDto(product.Id, product.Name, product.EntryDate, product.Price);
        }

        public static PriceReductionsDto AsDto(this PriceReductions priceReductions)
        {
            return new PriceReductionsDto(priceReductions.Id, priceReductions.DayOfWeek, priceReductions.Reduction);
        }
    }
}
