using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Point.Utilities;

using Point.Models;

namespace Point.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public PointEntry Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();



            Item = new PointEntry
            {
                Title = "Item name",
                Category = "Cafe",
            };

            BindingContext = this;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();


            Coordinate location = await LocationUtil.GetCurrentLocation();

            Item.Latitude = location.Latitude;
            Item.Longitude = location.Longitude;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}