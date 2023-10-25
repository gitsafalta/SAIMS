using Moq;
using SAIMS.Infrastructure.DataAccess;
using Xunit;

namespace SAIMS.UnitTests;

public class SalesTests
{
   /* [Fact]    
    public async Task Get_SalesDetails()
    {
        // Arrange
        var expectedModel = new TotalSalesViewModel
        {
            dailyTotalSales = 10,
            monthlyTotalSales = 10,
            yearlyTotalSales = 10
        }; 

        var _daMock = new Mock<ISqlDataAccess>();

        // Act
        _daMock.Setup(x => x.LoadSingle<TotalSalesViewModel>("GetSalesDetails","Default"))
            .ReturnsAsync(expectedModel); // Configuring the mock behavior

        // Assuming you have a class that uses ISqlDataAccess, create an instance of that class
        var myService = new SalesRepository(_daMock.Object);

        // Call the method you want to test        
        var result = await myService.GetTotalSalesDetails();

        // Assert
        Assert.Equal(expectedModel, result); // Compare the result with the expected model

    }*/


}