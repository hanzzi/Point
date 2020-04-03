using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Point.Models;

namespace Point.Services
{
    public class MockDataStore : IDataStore<PointEntry>
    {
        readonly List<PointEntry> items;

        public MockDataStore()
        {
            items = new List<PointEntry>()
            {
                new PointEntry { Id = Guid.NewGuid().ToString(), Title = "First item", Category="Cafe" },
                new PointEntry { Id = Guid.NewGuid().ToString(), Title = "Second item",Category="Cafe" },
                new PointEntry { Id = Guid.NewGuid().ToString(), Title = "Third item", Category="Cafe" },
                new PointEntry { Id = Guid.NewGuid().ToString(), Title = "Fourth item", Category="Cafe" },
                new PointEntry { Id = Guid.NewGuid().ToString(), Title = "Fifth item", Category="Cafe" },
                new PointEntry { Id = Guid.NewGuid().ToString(), Title = "Sixth item", Category="Cafe" }
            };
        }

        public async Task<bool> AddItemAsync(PointEntry item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(PointEntry item)
        {
            var oldItem = items.Where((PointEntry arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((PointEntry arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<PointEntry> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<PointEntry>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}