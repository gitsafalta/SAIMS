public class Item{
    public Guid id { get; set; }
    public string name { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public decimal quantity { get; set; }
    public bool isAvailable { get; set; }
    public string imageUrl { get; set; } = string.Empty;
    public decimal price { get; set; }
    public decimal thresholdQuantity { get; set; }
}


public class CategoryItem{
    public Guid id { get; set; }
    public Guid categoryId { get; set; }
    public Guid itemId { get; set; }
}