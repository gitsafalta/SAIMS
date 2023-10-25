using SAIMS.Application.Models;

namespace SAIMS.Application.Interfaces
{
    public interface ISalesService
    {
        //Total sales
        public Task<DTOSalesResponse> GetTotalSalesDetails(DTOSalesRequest model);
        
    }
}