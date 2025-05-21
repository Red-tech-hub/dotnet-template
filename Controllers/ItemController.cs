using Microsoft.AspNetCore.Mvc;
using MyWeatherApi.Models;
using MyWeatherApi.Services.Interfaces;

namespace MyWeatherApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly ILogger<ItemController> _logger;

        public ItemController(IItemService itemService, ILogger<ItemController> logger)
        {
            _itemService = itemService;
            _logger = logger;
        }

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns>A list of all items</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            try
            {
                var items = await _itemService.GetItemsAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all items");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Get an item by id
        /// </summary>
        /// <param name="id">The ID of the item to retrieve</param>
        /// <returns>The requested item</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Item>> GetItem(Guid id)
        {
            try
            {
                var item = await _itemService.GetItemByIdAsync(id);
                if (item == null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting item {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Create a new item
        /// </summary>
        /// <param name="item">The item to create</param>
        /// <returns>The created item</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Item>> CreateItem(Item item)
        {
            try
            {
                if (item == null)
                {
                    return BadRequest("Item cannot be null");
                }

                var createdItem = await _itemService.CreateItemAsync(item);
                return CreatedAtAction(nameof(GetItem), new { id = createdItem.Id }, createdItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating item");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Update an existing item
        /// </summary>
        /// <param name="id">The ID of the item to update</param>
        /// <param name="item">The updated item data</param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateItem(Guid id, Item item)
        {
            try
            {
                if (item == null || id != item.Id)
                {
                    return BadRequest("Invalid item or ID mismatch");
                }

                var updatedItem = await _itemService.UpdateItemAsync(id, item);
                if (updatedItem == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating item {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="id">The ID of the item to delete</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            try
            {
                var result = await _itemService.DeleteItemAsync(id);
                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting item {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

