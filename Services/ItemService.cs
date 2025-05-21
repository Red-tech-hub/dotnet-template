using MyWeatherApi.Models;
using MyWeatherApi.Services.Interfaces;

namespace MyWeatherApi.Services
{
    public class ItemService : IItemService
    {
        private readonly List<Item> _items = new();

        public ItemService()
        {
            // Initialize with some sample data
            _items.Add(new Item 
            { 
                Id = Guid.NewGuid(), 
                Name = "Item 1", 
                Description = "Description for Item 1" 
            });
            
            _items.Add(new Item 
            { 
                Id = Guid.NewGuid(), 
                Name = "Item 2", 
                Description = "Description for Item 2" 
            });
            
            _items.Add(new Item 
            { 
                Id = Guid.NewGuid(), 
                Name = "Item 3", 
                Description = "Description for Item 3" 
            });
        }

        public Task<IEnumerable<Item>> GetItemsAsync()
        {
            return Task.FromResult<IEnumerable<Item>>(_items);
        }

        public Task<Item?> GetItemByIdAsync(Guid id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            return Task.FromResult(item);
        }

        public Task<Item> CreateItemAsync(Item item)
        {
            item.Id = Guid.NewGuid();
            item.CreatedDate = DateTime.UtcNow;
            _items.Add(item);
            return Task.FromResult(item);
        }

        public Task<Item?> UpdateItemAsync(Guid id, Item updatedItem)
        {
            var existingItem = _items.FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
            {
                return Task.FromResult<Item?>(null);
            }

            existingItem.Name = updatedItem.Name;
            existingItem.Description = updatedItem.Description;
            existingItem.IsActive = updatedItem.IsActive;

            return Task.FromResult<Item?>(existingItem);
        }

        public Task<bool> DeleteItemAsync(Guid id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return Task.FromResult(false);
            }

            _items.Remove(item);
            return Task.FromResult(true);
        }
    }
}
