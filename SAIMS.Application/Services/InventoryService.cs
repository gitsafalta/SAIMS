using SAIMS.Application.Interfaces;
using SAIMS.Application.Models;
using static SAIMS.Application.Extensions.Extension;

namespace SAIMS.Application.Services
{
    public class InvertoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InvertoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<DTPostResult> GetInventoryList(DTPostModel param)
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
                searchBy = (param.search != null) ? param.search.value : null;
                if (searchBy != null)
                {
                    searchBy = searchBy.Trim();
                }
                take = param.length;
                skip = param.start;
                draw = param.draw;
                if (param.order != null)
                {
                    sortBy = param.columns[param.order[0].column].data.CapitalizeFirstLetter();
                    sortDir = param.order[0].dir.ToLower() == "desc";
                }
            };
            var inventoryList =await _inventoryRepository.GetInventoryList();
           
                totalResultsCount = inventoryList.Count();

                if (!String.IsNullOrEmpty(searchBy))
                {
                    var searchByLower = searchBy.ToLower();
                    inventoryList = inventoryList.Where(x => x.Item.ToLower().Contains(searchByLower)).ToList();
                }

                filteredResultsCount = inventoryList.Count();
                inventoryList = inventoryList.AsQueryable().OrderBy(sortBy, sortDir).Skip(skip).Take(take).ToList();

            return new DTPostResult
            {
                draw = draw,
                recordsTotal = filteredResultsCount,
                recordsFiltered = totalResultsCount,
                data = inventoryList
            };            
        }
    }
}