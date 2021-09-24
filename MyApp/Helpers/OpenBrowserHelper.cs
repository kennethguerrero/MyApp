using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MyApp.Helpers
{
    public class OpenBrowserHelper : IOpenBrowserHelper
    {
        public async Task OpenInBrowser(string param)
        {
            await Browser.OpenAsync(param);
        }
    }
}
