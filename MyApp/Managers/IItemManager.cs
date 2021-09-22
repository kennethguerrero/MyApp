using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Models;

namespace MyApp.Managers
{
    public interface IItemManager
    {
        Task<IEnumerable<Item>> GetItems();
    }
}