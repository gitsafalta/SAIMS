public class Order{
    public Guid id { get; set; }
    public Guid customerId { get; set; }
    public DateTime orderDate { get; set; }
    public decimal grandTotal{ get; set; }
}

public class OrderItem{
    public Guid id { get; set; }
    public Guid orderId { get; set; }
    public Guid itemId { get; set; }
    public decimal quantity { get; set; }
    public Guid discountRuleId { get; set; }
    public decimal discountAmount { get; set; }
    public decimal total { get; set; }
    
}