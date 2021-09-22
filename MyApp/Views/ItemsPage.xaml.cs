using System;
using System.Collections.Generic;
using MyApp.ViewModels;
using Xamarin.Forms;

namespace MyApp.Views
{
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = ServiceLocator.GetItemsViewModel();
        }
    }
}
