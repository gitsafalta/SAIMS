using SAIMS.Application.Model;
using SAIMS.Application.Interfaces;
using SAIMS.Application.Services;
using System.Linq;
using Moq;

namespace SAIMS.UnitTests;

public class DiscountTests
{
    [Fact]
    public async Task Get_DiscountDetails()
    {
        //Arrange
        var expectedModel = new DiscountReportViewModel {
            popularDiscount = new List<PopularDiscount>{
                new PopularDiscount{
                    discountType ="Percentage",
                    discountUsed = 2
                },
                new PopularDiscount{
                    discountType ="Flat",
                    discountUsed = 1 
                },
                new PopularDiscount{
                    discountType ="Random Offer",
                    discountUsed = 1
                } 
            },
            discountUsageDetails = new List<DiscountUsageDetails>{
               new DiscountUsageDetails{
                categoryName = "Electronics",
                itemName = "Laptop",
                discountType = "Percentage"
               }
           }
        };
        var sampledata = DiscountDetails();

        // Create a mock of ISalesRepository and set up its behavior
        var mockDiscountRepo = new Mock<IDiscountRepository>();
        mockDiscountRepo.Setup(x=>x.LoadDiscountDetails()).ReturnsAsync(sampledata);

        //Act
        DiscountService discountService = new DiscountService(mockDiscountRepo.Object);
        var result =await discountService.GetDiscountDetails();
        
        //Assert
        Assert.Equal(expectedModel.popularDiscount.Count, result.popularDiscount.Count); 
    }

    [Fact]
    public async Task Validate_DiscountDetails()
    {
        // Arrange
        int expectedDiscountType = 1;
        var sampledata = DiscountDetails();
        
        // Create a mock of ISalesRepository and set up its behavior
        var mockDiscountRepo = new Mock<IDiscountRepository>();
        mockDiscountRepo.Setup(x=>x.LoadDiscountDetails()).ReturnsAsync(sampledata);

        // Act
        DiscountService discountService = new DiscountService(mockDiscountRepo.Object);
        var result =await discountService.GetDiscountDetails();

        // Assert
        var p = result.popularDiscount.Where(x=>x.discountType == "Percentage").FirstOrDefault();
        Assert.Equal(expectedDiscountType, p.discountUsed);
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