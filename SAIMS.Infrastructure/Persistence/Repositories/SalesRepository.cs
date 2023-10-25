using System.Data;
using SAIMS.Application.Interfaces;
using SAIMS.Infrastructure.DataAccess;
using SAIMS.Application.Models;
using SAIMS.Application.Enum;

public class SalesRepository: ISalesRepository
{
    private readonly ISqlDataAccess _db;
    public SalesRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<SalesDetails>> GetTotalSalesDetails(DTOSalesRequest model)
    {
        //var x = await _db.LoadData<SalesDetails, SalesRequestViewModel>("GetTotalSales", model);
        IEnumerable<SalesDetails> samledata;
        if(model.period == Period.Daily)
            samledata = await GetDailySalesDetails();
        else if(model.period == Period.Monthly)
            samledata =await GetMonthlySalesDetails();
        else
            samledata =await GetYearlySalesDetails();
        return  samledata??new List<SalesDetails>();
    }

     private async Task<IEnumerable<SalesDetails>> GetYearlySalesDetails()
    {
        return new List<SalesDetails>{
            new SalesDetails{
                customerName = "Safalta",
                categoryId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                categoryName ="Fitness",
                itemId= Guid.Parse("34bdb06d-edf1-4cc4-b58c-675e50748181"),
                itemName = "Pound",
                totalAmount =10000m,
                quantity = 10,
                orderDate = DateTime.Now.ToUniversalTime(),
                discountAmount = 0,
                price = 1000
            },
            new SalesDetails{
                customerName = "Safalta",
                categoryId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                categoryName ="Fitness",
                itemId= Guid.Parse("ebd54e44-6353-4300-86f8-4b620b5b54b8"),
                itemName = "Trade Mill",
                totalAmount =80000m,
                quantity = 8,
                orderDate = DateTime.Parse("2023-09-22"),
                discountAmount = 0,
                price = 10000
            },
            new SalesDetails{
                customerName = "Safalta",
                categoryId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                categoryName ="Fitness",
                itemId= Guid.Parse("ebd54e44-6353-4300-86f8-4b620b5b54b8"),
                itemName = "Trade Mill",
                totalAmount =9000m,
                quantity = 9,
                orderDate = DateTime.Parse("2022-09-22"),
                discountAmount = 0,
                price = 1000
            },
            new SalesDetails{
                customerName = "Anil",
                categoryId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                categoryName ="Fitness",
                itemId= Guid.Parse("ebd54e44-6353-4300-86f8-4b620b5b54b8"),
                itemName = "Trade Mill",
                totalAmount =9000m,
                quantity = 1,
                orderDate = DateTime.Parse("2022-09-22"),
                discountAmount = 0,
                price = 1000
            },
            new SalesDetails{
                customerName = "Simon",
                categoryId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                categoryName ="Fitness",
                itemId= Guid.Parse("ebd54e44-6353-4300-86f8-4b620b5b54b8"),
                itemName = "Trade Mill",
                totalAmount =9000m,
                quantity = 2,
                orderDate = DateTime.Parse("2022-09-22"),
                discountAmount = 0,
                price = 1000
            },
            new SalesDetails{
                customerName = "Kevin",
                categoryId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                categoryName ="Vegetable",
                itemId= Guid.Parse("ebd54e44-6353-4300-86f8-4b620b5b54b8"),
                itemName = "Trade Mill",
                totalAmount =145,
                quantity = 3,
                orderDate = DateTime.Parse("2022-09-22"),
                discountAmount = 5,
                price = 50
            },
            new SalesDetails{
                customerName = "Safalta",
                categoryId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                categoryName ="Vegetable",
                itemId= Guid.Parse("ebd54e44-6353-4300-86f8-4b620b5b54b8"),
                itemName = "Tomato",
                totalAmount =245,
                quantity = 5,
                orderDate = DateTime.Parse("2022-09-22"),
                discountAmount = 5,
                price = 50
            },
            new SalesDetails{
                customerName = "Safalta",
                categoryId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                categoryName ="Fitness",
                itemId= Guid.Parse("34bdb06d-edf1-4cc4-b58c-675e50748181"),
                itemName = "Pound",
                totalAmount =10000m,
                quantity = 10,
                orderDate = DateTime.Parse("2023-05-05"),
                discountAmount = 0,
                price = 1000
            },
            new SalesDetails{
                customerName = "Safalta",
                categoryId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                categoryName ="Vegetable",
                itemId= Guid.Parse("ebd54e44-6353-4300-86f8-4b620b5b54b8"),
                itemName = "Tomato",
                totalAmount =200,
                quantity = 4,
                orderDate = DateTime.Parse("2023-09-22"),
                discountAmount = 0,
                price = 50
            },
            new SalesDetails{
                customerName = "Safalta",
                categoryId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                categoryName ="Vegetable",
                itemId= Guid.Parse("ebd54e44-6353-4300-86f8-4b620b5b54b8"),
                itemName = "Tomato",
                totalAmount =350,
                quantity = 5,
                orderDate = DateTime.Parse("2023-07-22"),
                discountAmount = 0,
                price = 70
            },
            new SalesDetails{
                customerName = "Safalta",
                categoryId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                categoryName ="Vegetable",
                itemId= Guid.Parse("ebd54e44-6353-4300-86f8-4b620b5b54b8"),
                itemName = "Potato",
                totalAmount =700,
                quantity = 5,
                orderDate = DateTime.Parse("2022-09-22"),
                discountAmount = 0,
                price = 120
            }
        };
    }
    private async Task<IEnumerable<SalesDetails>> GetMonthlySalesDetails()
    {
        return new List<SalesDetails>{
            new SalesDetails{
                customerName = "Safalta",
                categoryId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                categoryName ="Fitness",
                itemId= Guid.Parse("34bdb06d-edf1-4cc4-b58c-675e50748181"),
                itemName = "Pound",
                totalAmount =1000m,
                quantity = 1,
                orderDate = DateTime.Now.ToUniversalTime(),
                discountAmount = 0,
                price = 1000m
            },
            new SalesDetails{
                customerName = "Safalta",
                categoryId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                categoryName ="Fitness",
                itemId= Guid.Parse("ebd54e44-6353-4300-86f8-4b620b5b54b8"),
                itemName = "Trade Mill",
                totalAmount =20000m,
                quantity = 2,
                orderDate = DateTime.Parse("2023-09-22"),
                discountAmount = 0,
                price = 10000
            },
            new SalesDetails{
                customerName = "Safalta",
                categoryId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                categoryName ="Fitness",
                itemId= Guid.Parse("ebd54e44-6353-4300-86f8-4b620b5b54b8"),
                itemName = "Trade Mill",
                totalAmount =3000m,
                quantity = 3,
                orderDate = DateTime.Parse("2022-09-22"),
                discountAmount = 0,
                price = 1000
            },
        };
    }

    private async Task<IEnumerable<SalesDetails>>GetDailySalesDetails()
    {
        return new List<SalesDetails>{
            new SalesDetails{
                customerName = "Safalta",
                categoryId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                categoryName ="Fitness",
                itemId= Guid.Parse("34bdb06d-edf1-4cc4-b58c-675e50748181"),
                itemName = "Pound",
                totalAmount =1000m,
                quantity = 1,
                orderDate = DateTime.Now.ToUniversalTime(),
                discountAmount = 10,
                price = 1000
            },
            new SalesDetails{
                customerName = "Safalta",
                categoryId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                categoryName ="Fitness",
                itemId= Guid.Parse("ebd54e44-6353-4300-86f8-4b620b5b54b8"),
                itemName = "Trade Mill",
                totalAmount =10000m,
                quantity = 1,
                orderDate = DateTime.Parse("2023-09-22"),
                discountAmount = 10,
                price = 10000m
            },
            new SalesDetails{
                customerName = "Safalta",
                categoryId = Guid.Parse("ebd54e44-6353-4303-86f8-4b620b5b54b8"),
                categoryName ="Fitness",
                itemId= Guid.Parse("ebd54e44-6353-4300-86f8-4b620b5b54b8"),
                itemName = "Trade Mill",
                totalAmount =1000,
                quantity = 1,
                orderDate = DateTime.Parse("2022-09-22"),
                discountAmount = 0,
                price = 1000
            },
        };
    }
}