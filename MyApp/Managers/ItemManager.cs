using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Exceptions;
using MyApp.Helpers;
using MyApp.Models;
using MyApp.Services;

namespace MyApp.Managers
{
    public class ItemManager : BaseManager, IItemManager
    {
        private readonly IDataService _dataService;

        public ItemManager(IDataService dataService, IConnectivityHelper connectivityHelper) : base(connectivityHelper)
        {
            _dataService = dataService;
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            if (!CheckInternetConnection())
                throw new NoInternetException();

            var result = await _dataService.GetItems();
            return result;
        }
    }
}
