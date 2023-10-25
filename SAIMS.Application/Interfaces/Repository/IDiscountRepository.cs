using SAIMS.Application.Model;

namespace SAIMS.Application.Interfaces;
public interface IDiscountRepository
{
   //Total sales
   public Task<IEnumerable<DiscountDetails>> LoadDiscountDetails();
   
} 