using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Xunit;
using SAIMS.Application.Models;
using SAIMS.Application.Enum;

namespace SAIMS.UnitTests;

public class MinimalApiTests
{
    private readonly HttpClient _client;

    public MinimalApiTests()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5281");
    }

    [Fact]
    public async Task TestValidation_ExceptionThrown()
    {        
        //Arrange
        var requestparam = new DTOSalesRequest
        {
            year = 0,
            month=1,
            day=1,
            period = Period.Monthly
        }; 
        var json = JsonSerializer.Serialize(requestparam);
        HttpContent content = new StringContent(json, Encoding.UTF8,"application/json");
        //Act
        var repsonse = await _client.PostAsync("/api/sales", content);
        var conent = await repsonse.Content.ReadAsStringAsync();
        //Assert
        Assert.Equal(HttpStatusCode.BadRequest,repsonse.StatusCode);
        
    }
}