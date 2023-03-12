using DeliVeggieService.Entity;
using static DeliVeggieService.Infrastructure.DTO;

namespace DeliVeggieService.Infrastructure
{
    public static class Helper
    {
        /// <summary>
        /// This calculates the reduced price for a product on a specific day.
        /// First day of the week: Sunday (with a value of zero) 
        /// Every day is incremented by 1 to match DB value
        /// </summary>
        /// <param name="priceReductionsDetails">Price Reduction for every day of the week</param>
        /// <param name="product"></param>
        /// <returns>Product with discounted price for the day</returns>
        public static Product GetPriceReduction(this IEnumerable<PriceReductionsDto> priceReductionsDetails, Product product)
        {
            var pr = priceReductionsDetails.Where(a => a.DayOfWeek == ((int)DateTime.UtcNow.DayOfWeek + 1)).FirstOrDefault();
            if (product != null && pr != null)
            {
                product.Price = Math.Round(product.Price - product.Price * (pr.Reduction / 100), 2, MidpointRounding.AwayFromZero);
                return product;

            }
            return product;
        }
    }
}
