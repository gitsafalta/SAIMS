using System.Data;
using SAIMS.Application.Interfaces;
using SAIMS.Application.Model;
using SAIMS.Infrastructure.DataAccess;

public class DiscountRepository: IDiscountRepository
{
    private readonly ISqlDataAccess _db;

    public DiscountRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<DiscountDetails>> LoadDiscountDetails()
    {
        //var x = await _db.LoadData<SalesDetails, SalesRequestViewModel>("GetTotalSales", model);
        var samledata = DiscountDetails();       
        return  samledata;
    }

    private IEnumerable<DiscountDetails> DiscountDetails()
    {
        return new List<DiscountDetails>{
            new DiscountDetails{
                discountTypeId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                typeName="Percentage",
                categoryId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                categoryName = "Electronics",
                itemId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                itemName= "Laptop"
            },
            new DiscountDetails{
                discountTypeId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                typeName="Flat",
                categoryId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                categoryName = "Electronics",
                itemId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                itemName= "Laptop"
            },
            new DiscountDetails{
                discountTypeId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                typeName="Random Offer",
                categoryId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                categoryName = "Electronics",
                itemId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                itemName= "Charger"
            }
        };
    }

}