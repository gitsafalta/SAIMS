using SAIMS.Application.Model;
using SAIMS.Application.Models;

namespace SAIMS.Application.Interfaces;
public interface IInventoryRepository
{
    //Inventory List
    public Task<List<InventoryListModel>> GetInventoryList();
} 