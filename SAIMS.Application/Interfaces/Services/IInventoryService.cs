
using SAIMS.Application.Model;
using SAIMS.Application.Models;

namespace SAIMS.Application.Interfaces
{
    public interface IInventoryService
    {
        //Inventory List
        public Task<DTPostResult> GetInventoryList(DTPostModel model);
    }
}