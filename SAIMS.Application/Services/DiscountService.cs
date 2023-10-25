using SAIMS.Application.Interfaces;
using SAIMS.Application.Model;
using System.Linq;

namespace SAIMS.Application.Services;
    
public class DiscountService : IDiscountService
{
    public readonly IDiscountRepository _discountRepository;
    public DiscountService(IDiscountRepository discountRepository)
    {
            _discountRepository = discountRepository;
    }
    
    public async Task<DiscountReportViewModel> GetDiscountDetails()
    {
        var d =await _discountRepository.LoadDiscountDetails();
        var x = d.GroupBy(p =>new {p.discountTypeId, p.typeName} )
                .Select(g=>new PopularDiscount{
                    discountType = g.Key.typeName,
                    discountUsed=g.Count()
                });
        var y = d.Select(g => new DiscountUsageDetails{
                categoryName = g.categoryName,
                itemName = g.itemName,
                discountType = g.typeName
        });
        DiscountReportViewModel response = new DiscountReportViewModel {
            popularDiscount = x.ToList(),
            discountUsageDetails = y.ToList()           
        };
           return response;
    }
}
