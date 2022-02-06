using Catalog.Entities;
using System.Collections.Generic;
using System;

namespace Catalog.Repositories
 {   
    public interface IItemsRepository
    {
        Item GetItem(System.Guid id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
        void UpdateItem(Item item);
    }
 }