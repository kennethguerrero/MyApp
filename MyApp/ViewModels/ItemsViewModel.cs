using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Exceptions;
using MyApp.Models;
using MyApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private IEnumerable<Item> _allItems;
        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<string> SearchCommand { get; }
        private readonly IDataService _dataService;

        public ItemsViewModel(IDataService dataService)
        {
            Title = "Items";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await LoadItems());
            SearchCommand = new Command<string>(async (query) => await Search(query));
            _dataService = dataService;

            Initialize = LoadItems();
        }

        private Task Initialize { get; set; }
        public async Task LoadItems()
        {
            try
            {
                IsBusy = true;
                Items.Clear();
                _allItems = await _dataService.GetItems();

                foreach (var item in _allItems)
                {
                    Items.Add(item);
                }
            }
            catch (NoInternetException)
            {
                await Shell.Current.DisplayAlert(null, "Check your internet connection", "close");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        Item selectedItem;
        public Item SelectedItem
        {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value, onChanged: async () => await Selected(selectedItem));
        }

        private async Task Selected(Item item)
        {
            if (item == null)
                return;

            SelectedItem = null;

            await Browser.OpenAsync(item.ImageUrl);
        }

        public async Task Search(string query)
        {
            try
            {
                var capitalizedEntry = char.ToUpper(query[0]) + query.Substring(1);

                var searchedItems = _allItems.Where(i => i.Name.Contains(capitalizedEntry));

                Items.Clear();

                foreach (var item in searchedItems)
                {
                    Items.Add(item);
                }
            }
            catch (NoInternetException)
            {
                await Shell.Current.DisplayAlert(null, "Check your internet connection", "close");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
