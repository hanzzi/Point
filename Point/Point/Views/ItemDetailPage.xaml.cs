using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Point.Models;
using Point.ViewModels;
using Point.Utilities;

namespace Point.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        public PointEntry Entry { get; set; }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            InitializeData();

            //BindingContext = this.viewModel = viewModel;
            BindingContext = Entry;
        }

        public ItemDetailPage()
        {
            InitializeComponent();
            InitializeData();
            //var entry = new PointEntry
            //{
            //    Title = "Item 1",
            //    Category = "Café"
            //};

            //viewModel = new ItemDetailViewModel(entry);

            //BindingContext = viewModel;
            BindingContext = Entry;
        }

        async void InitializeData()
        {
            Coordinate coords = await LocationUtil.GetCurrentLocation();
            Entry = new PointEntry { Title = "Test Entry", Id = Guid.NewGuid().ToString(), Latitude = coords.Latitude, Longitude = coords.Longitude, Category = "Café" };
    }

        protected async override void OnAppearing()
        {
            base.OnAppearing();


            Coordinate location = await LocationUtil.GetCurrentLocation();

            viewModel.Item.Latitude = location.Latitude;
            viewModel.Item.Longitude = location.Longitude;
        }

        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        public async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", viewModel.Item);
            await Navigation.PopModalAsync();
        }
    }
}