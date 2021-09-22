using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Services
{
    public interface IDataService
    {
        Task<IEnumerable<Item>> GetItems();
    }
}