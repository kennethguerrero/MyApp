using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyApp.Helpers
{
    public class ShellHelper : IShellHelper
    {
        public async Task DisplayAlert(string param)
        {
            await Shell.Current.DisplayAlert(null, param, "OK");
        }
    }
}
