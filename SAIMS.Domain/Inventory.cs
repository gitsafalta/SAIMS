
public class TransactionHistory{
    public Guid transactionId { get; set; }
    public Guid itemId { get; set; }
    public decimal quantity { get; set; }
    public bool inOut { get; set; }
     public DateTime occuredDate { get; set; }
     public decimal price { get; set; }
}