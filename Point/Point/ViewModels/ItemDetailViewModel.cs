using System;

using Point.Models;

namespace Point.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public PointEntry Item { get; set; }
        public ItemDetailViewModel(PointEntry item = null)
        {
            Title = item?.Title;
            Item = item;

        }
    }
}
