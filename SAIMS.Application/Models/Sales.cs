using SAIMS.Application.Enum;
using FluentValidation;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace SAIMS.Application.Models;

public class DTOSalesRequest{
    public int year { get; set; }
    public int? month { get; set; }
    public int? day { get; set; }
    public Period period { get; set; }
    [JsonIgnore]
    public int pageNumber{get; set;}
    [JsonIgnore]
    public int pageSize { get; set; }
    [JsonIgnore]
    public string? searchBy { get; set; }
}

public class SalesDetails{
    public string customerName { get; set; } = string.Empty;
    [JsonIgnore]
    public Guid categoryId { get; set; }
    public string categoryName { get; set; }= string.Empty;
    [JsonIgnore]
    public Guid itemId { get; set; }
    public string itemName { get; set; }= string.Empty;
    public decimal price { get; set; }
    public decimal totalAmount { get; set; }
    public decimal quantity { get; set; }
    public decimal discountAmount { get; set; }
    [JsonIgnore]
    public DateTime orderDate { get; set; }
    public string date { 
        get{
            return orderDate.ToString("yyyy-MM-dd");
        }
    }
}

public class DTOSalesResponse{
    public decimal totalSales { get; set; }
    public IEnumerable<SalesDetails>? salesDetails { get; set; }
}

public class SalesRequestViewModelValidator:AbstractValidator<DTOSalesRequest>
{
    public SalesRequestViewModelValidator()
    {
        RuleFor(x=>x.year).NotEmpty()
            .WithMessage("year cannot be empty");
        RuleFor(x=>x.month)
        .Must(x => x >=1 && x<=12).When(x => x.period == Period.Monthly || x.period == Period.Daily)
        .WithMessage("Invalid month");
        RuleFor(x=>x.day)
        .Must(x => x >=1 && x<=31).When(x => x.period == Period.Daily)
        .WithMessage("Invalid Day");
        RuleFor(x => x.period).NotEmpty()
            .WithMessage("period cannot be empty");
    }
}