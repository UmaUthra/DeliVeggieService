using System.ComponentModel.DataAnnotations;

namespace DeliVeggieService.Infrastructure
{
    /// <summary>
    /// DTO Models for Product and Price Reductions collections 
    /// </summary>
    public class DTO
    {
        public record ProductDto(Guid Id, string Name, DateTime EntryDate, double Price);
        public record PriceReductionsDto(Guid Id, int DayOfWeek, double Reduction);
        public record CreateProductDto([Required] string Name, DateTime EntryDate, double Price);
        public record CreatePriceReductionsDto([Required] int DayOfWeek, double Reduction);
        public record UpdateProductDto([Required] string Name, DateTime EntryDate, double Price);
    }
}
