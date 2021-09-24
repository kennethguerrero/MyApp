using MyApp.Helpers;
using MyApp.Managers;
using MyApp.Services;

namespace MyApp.ViewModels
{
    public class ServiceLocator
    {
        public static IShellHelper ShellHelper = new ShellHelper();
        public static IOpenBrowserHelper OpenBrowserHelper = new OpenBrowserHelper();
        public static IConnectivityHelper ConnectivityHelper = new ConnectivityHelper();
        public static IDataService DataService = new DataService();
        public static IItemManager itemManager = new ItemManager(DataService, ConnectivityHelper);

        public static ItemsViewModel GetItemsViewModel()
        {
            return new ItemsViewModel(DataService, OpenBrowserHelper, ShellHelper);
        }
    }
}
