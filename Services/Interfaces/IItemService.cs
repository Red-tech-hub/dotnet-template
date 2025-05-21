using MyWeatherApi.Models;

namespace MyWeatherApi.Services.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<Item?> GetItemByIdAsync(Guid id);
        Task<Item> CreateItemAsync(Item item);
        Task<Item?> UpdateItemAsync(Guid id, Item item);
        Task<bool> DeleteItemAsync(Guid id);
    }
}
