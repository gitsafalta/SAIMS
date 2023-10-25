using FluentValidation;
using SAIMS.Application.Interfaces;
using SAIMS.Application.Models;
using SAIMS.Application.Extensions;

namespace SAIMS.Application.Services;
public class SalesService : ISalesService
{
    private readonly ISalesRepository _salesrepository;
    public SalesService(ISalesRepository  salesrepository)
    {
        _salesrepository = salesrepository;
    }

    public async Task<DTOSalesResponse> GetTotalSalesDetails(DTOSalesRequest model)
    {
        var validator = new SalesRequestViewModelValidator();
        var validationResult = validator.Validate(model); 

        validator.ValidateAndThrow(model);

        var saleslist= await _salesrepository.GetTotalSalesDetails(model);
       
        var sum = saleslist.Sum(x=>x.totalAmount);
        var r = new DTOSalesResponse 
        {
            totalSales = sum,
            salesDetails = saleslist
        };
        return r;
    }

    public async Task<DTPostResult> GetRevenueDetails(DTPostModel param)
    {
        string searchBy = string.Empty;
        int skip = 0;
        int take = 2;
            string sortBy = "Name";
            bool sortDir = false;

            int totalResultsCount = 0;
            int filteredResultsCount = 0;
            int draw = 0;

            if (param != null)
            {
                searchBy = param.search?.value ?? "";
                if (searchBy != null)
                {
                    searchBy = searchBy.Trim();
                }
                take = param.length;
                skip = param.start;
                draw = param.draw;
                if (param.order != null)
                {
                    sortBy = param.columns?[param.order[0].column].data?.CapitalizeFirstLetter() ?? "";
                    sortDir = param.order?[0]?.dir?.ToLower() == "desc";
                }
            };

            //TODO: Memoization Cache
            var smodel = new DTOSalesRequest();
            smodel.pageNumber = skip;
            smodel.pageSize = take;
            var salesList =await _salesrepository.GetTotalSalesDetails(new DTOSalesRequest());
           
            totalResultsCount = salesList.Count();
            salesList = salesList.AsQueryable().OrderBy(sortBy, sortDir);
                
            return new DTPostResult
            {
                draw = draw,
                recordsTotal = filteredResultsCount,
                recordsFiltered = totalResultsCount,
                data = salesList
            }; 
    }

}
