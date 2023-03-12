namespace DeliVeggieService.Entity
{
    /// <summary>
    /// Model Entity for Product
    /// </summary>
    public class Product : IEntity
    {
        /// <summary>
        /// Unique ID
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Name of the product
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// EntryDate when this item was added to the store
        /// </summary>
        public DateTime EntryDate { get; set; }
        /// <summary>
        /// Price of the item without discount
        /// </summary>
        public double Price { get; set; }

    }
}
