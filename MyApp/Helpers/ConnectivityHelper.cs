using Xamarin.Essentials;

namespace MyApp.Helpers
{
    public class ConnectivityHelper : IConnectivityHelper
    {
        public bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
    }
}
