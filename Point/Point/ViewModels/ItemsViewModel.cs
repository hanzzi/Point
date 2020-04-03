using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Point.Models;
using Point.Views;

namespace Point.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<PointEntry> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Points";
            Items = new ObservableCollection<PointEntry>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            // Used to subscribe to the ItemDetailPage when the message AddItem message is sent the following code will be executed
            MessagingCenter.Subscribe<ItemDetailPage, PointEntry>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as PointEntry;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
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
    }
}