
namespace SAIMS.Application.Model;

public class DiscountDetails{
    public Guid discountTypeId { get; set; }
    public string typeName { get; set; } = string.Empty;
    public Guid categoryId { get; set; }
    public string categoryName { get; set; }= string.Empty;
    public Guid itemId { get; set; }
    public string itemName { get; set; }= string.Empty;
}

public class DiscountReportViewModel{
    public List<PopularDiscount>? popularDiscount{get; set;}
    public List<DiscountUsageDetails>? discountUsageDetails{get; set;}
}

public class PopularDiscount{
    public string discountType{get; set;} = string.Empty;
    public int discountUsed{get; set;}
}

public class DiscountUsageDetails{
    public string categoryName { get; set; } = string.Empty;
    public string itemName { get; set; } = string.Empty;
    public string discountType { get; set; } =string.Empty;
}