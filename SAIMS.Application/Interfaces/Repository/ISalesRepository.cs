using SAIMS.Application.Models;

namespace SAIMS.Application.Interfaces;
public interface ISalesRepository
{
   //Total sales
   public Task<IEnumerable<SalesDetails>> GetTotalSalesDetails(DTOSalesRequest model);
   
} 