using System;
using System.Linq;
using System.Collections.Generic;
using Catalog.Entities;
using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.Dtos;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository){
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => new ItemDto{
                Id = item.Id,
                Name = item.Name,
                Price= item.Price,
                CreatedDate = item.CreatedDate
            });
            return items;
        }
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if(item is null){
                return NotFound();
            }

            return item;  
        }
    }
    
}