using SAIMS.Application.Interfaces;
using SAIMS.Application.Models;
using SAIMS.Infrastructure.DataAccess;



public class InventoryRepository : IInventoryRepository
{
    private readonly ISqlDataAccess _db;

    public InventoryRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<List<InventoryListModel>> GetInventoryList()
    {
        var inventoryList = InventoryListData();
        return inventoryList;        
    }

    private List<InventoryListModel> InventoryListData()
    {
        return new List<InventoryListModel>
        {
            new InventoryListModel
            {
                Id = 1,
                Item = "HDD",
                Category = "Storage Device",
                AvailableQuantity  = 0
            },
             new InventoryListModel
            {
                Id = 2,
                Item = "Laptop",
                Category = "Electronics",
                AvailableQuantity  = 3
            },
              new InventoryListModel
            {
                Id = 3,
                Item = "XBOX",
                Category = "Consoles",
                AvailableQuantity  = 10
            },
            new InventoryListModel
            {
                Id = 4,
                Item = "Charger",
                Category = "Electronics",
                AvailableQuantity  = 5
            },
            new InventoryListModel
            {
                Id = 5,
                Item = "Power Banke",
                Category = "Electronics",
                AvailableQuantity  = 6
            },
            new InventoryListModel
            {
                Id = 6,
                Item = "Pen Drive",
                Category = "Storage Device",
                AvailableQuantity  = 2
            },
            new InventoryListModel
            {
                Id = 7,
                Item = "Laptop7",
                Category = "Electronics",
                AvailableQuantity  = 3
            },
            new InventoryListModel
            {
                Id = 8,
                Item = "Laptop8",
                Category = "Electronics",
                AvailableQuantity  = 3
            },
            new InventoryListModel
            {
                Id = 9,
                Item = "Laptop9",
                Category = "Electronics",
                AvailableQuantity  = 3
            },
            new InventoryListModel
            {
                Id = 10,
                Item = "Laptop10",
                Category = "Electronics",
                AvailableQuantity  = 3
            },
            new InventoryListModel
            {
                Id =11,
                Item = "Laptop11",
                Category = "Electronics",
                AvailableQuantity  = 3
            },
            new InventoryListModel
            {
                Id = 12,
                Item = "Laptop12",
                Category = "Electronics",
                AvailableQuantity  = 3
            }
        };
    }
}