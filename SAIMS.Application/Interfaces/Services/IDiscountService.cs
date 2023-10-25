using SAIMS.Application.Model;

namespace SAIMS.Application.Interfaces;

public interface IDiscountService
{
    Task<DiscountReportViewModel> GetDiscountDetails();
}
