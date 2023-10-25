using Xunit;
using Moq;
using SAIMS.Application.Interfaces;
using SAIMS.Application.Services;
using SAIMS.Application.Enum;
using SAIMS.Application.Models;

namespace SAIMS.UnitTests;

public class SalesTests{

    [Theory]
    [MemberData(nameof(GetSalesRequest))]
    public async Task Get_DailySalesDetails(DTOSalesRequest request)
    {
        //Arrange
        var sampleData =await GetDailySalesDetails();
        var expectedModel = new DTOSalesResponse
        {
            totalSales = 12000,
            salesDetails = sampleData
        };
        var requestParam = request;
        
        // Create a mock of ISalesRepository and set up its behavior
        var salesRepository = new Mock<ISalesRepository>();
        salesRepository.Setup(x=>x.GetTotalSalesDetails(requestParam)).ReturnsAsync(sampleData);

        //Act
        var salesService = new SalesService(salesRepository.Object);        
        var result =await salesService.GetTotalSalesDetails(requestParam);

        //Assert
        Assert.Equal(expectedModel.totalSales, result.totalSales);
    }

    [Theory]
    [MemberData(nameof(GetSalesRequest))]
    public async Task Get_MonthlySalesDetails(DTOSalesRequest request)
    {
        //Arrange

        var sampleData =await GetMonthlySalesDetails();
        var expectedModel = new DTOSalesResponse
        {
            totalSales = 24000,
            salesDetails = sampleData
        };
        var requestParam = request;
        
        // Create a mock of ISalesRepository and set up its behavior
        var salesRepository = new Mock<ISalesRepository>();
        salesRepository.Setup(x=>x.GetTotalSalesDetails(requestParam)).ReturnsAsync(sampleData);

        //Act
        var salesService = new SalesService(salesRepository.Object);        
        var result =await salesService.GetTotalSalesDetails(requestParam);

        //Assert
        Assert.Equal(expectedModel.totalSales, result.totalSales);
    }

    [Theory]
    [MemberData(nameof(GetSalesRequest))]
    public async Task Get_YearlySalesDetails(DTOSalesRequest request)
    {
        //Arrange
        var sampleData =await GetYearlySalesDetails();
        var expectedModel = new DTOSalesResponse
        {
            totalSales = 99000,
            salesDetails = sampleData
        };
        var requestParam = request;
        
        // Create a mock of ISalesRepository and set up its behavior
        var salesRepository = new Mock<ISalesRepository>();
        salesRepository.Setup(x=>x.GetTotalSalesDetails(requestParam)).ReturnsAsync(sampleData);

        //Act
        var salesService = new SalesService(salesRepository.Object);        
        var result =await salesService.GetTotalSalesDetails(requestParam);

        //Assert
        Assert.Equal(expectedModel.totalSales, result.totalSales);
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

    public static IEnumerable<object[]> GetSalesRequest()
    {
        yield return new object[]
        {
            new DTOSalesRequest
            {
                year = 2023,
                month = 1,
                day = 1,
                period = Period.Monthly
            }
        };
    }
}