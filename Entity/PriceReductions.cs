
namespace DeliVeggieService.Entity
{
    /// <summary>
    /// Model Entity for PriceReductions
    /// </summary>
    public class PriceReductions : IEntity
    {
        /// <summary>
        /// Unique ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// DayOfWeek 
        /// First day of the week: Sunday (with a value of zero) 
        /// </summary>
        public int DayOfWeek { get; set; }

        /// <summary>
        /// Reduction percentage in decimal
        /// </summary>
        public double Reduction { get; set; }
    }
}
