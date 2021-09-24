using System.Threading.Tasks;

namespace MyApp.Helpers
{
    public interface IOpenBrowserHelper
    {
        Task OpenInBrowser(string param);
    }
}