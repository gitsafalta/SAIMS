
public class DiscountType{
    public Guid discountTypeId { get; set; }
    public string? TypeName { get; set; }
}
public class DiscountRule{
    public Guid discountRuleId { get; set; }
    public Guid discountTypeId { get; set; }
    public string? discountValue { get; set; }
    public int dayOfWeek { get; set; }
}