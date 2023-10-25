
public class Transcation{
    public Guid TransactionId { get; set; }
    public Guid ItemId { get; set; }
    public decimal Quantity { get; set; }
    public bool InOut { get; set; }
    public DateTime OccuredDated { get; set; }
    public decimal Price { get; set; }
}