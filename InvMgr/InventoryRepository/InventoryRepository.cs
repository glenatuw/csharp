using System;
using System.Collections.Generic;
using System.Linq;
using InventoryDB;

namespace InventoryRepository
{
    public class InventoryItemModel
    {
        public int id { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public int quantity { get; set; }
        public float price { get; set; }
        public float cost { get; set; }
        public System.DateTime createDate { get; set; }
    }

    public class InventoryRepository
    {
        public InventoryItemModel Add(InventoryItemModel inventoryItemModel)
        {
            Items inventoryItem = ToDbModel(inventoryItemModel);

            DatabaseManager.Instance.Items.Add(inventoryItem);
            DatabaseManager.Instance.SaveChanges();

            inventoryItemModel = new InventoryItemModel
            {
                id = inventoryItem.id,
                description = inventoryItem.description,
                location = inventoryItem.location,
                quantity = inventoryItem.quantity,
                price = (float) inventoryItem.price,
                cost = (float) inventoryItem.cost,
                createDate = inventoryItem.createDate,
            };
            return inventoryItemModel;
        }

        public List<InventoryItemModel> GetAll()
        {
            // Use .Select() to map the database items to InventoryItemModel
            var items = DatabaseManager.Instance.Items
              .Select(t => new InventoryItemModel
              {
                  id = t.id,
                  description = t.description,
                  location = t.location,
                  quantity = t.quantity,
                  price = (float) t.price,
                  cost = (float) t.cost,
                  createDate = t.createDate,
              }).ToList();

            return items;
        }

        public List<InventoryItemModel> GetSome(string str)
        {
            // Use .Select() to map the database items to InventoryItemModel
            var items = DatabaseManager.Instance.Items
              .Select(t => new InventoryItemModel
              {
                  id = t.id,
                  description = t.description,
                  location = t.location,
                  quantity = t.quantity,
                  price = (float)t.price,
                  cost = (float)t.cost,
                  createDate = t.createDate,
              })
              .Where(t => t.description.Contains(str))
              .ToList();

            return items;
        }

        public bool Update(InventoryItemModel inventoryItemModel)
        {
            var original = DatabaseManager.Instance.Items.Find(inventoryItemModel.id);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(inventoryItemModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int id)
        {
            var items = DatabaseManager.Instance.Items
                                .Where(t => t.id == id);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Items.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Items ToDbModel(InventoryItemModel inventoryItemModel)
        {
            var inventoryItem = new Items
            {
                id = inventoryItemModel.id,
                description = inventoryItemModel.description,
                location = inventoryItemModel.location,
                quantity = inventoryItemModel.quantity,
                price = inventoryItemModel.price,
                cost = inventoryItemModel.cost,
                createDate = inventoryItemModel.createDate,
            };

            return inventoryItem;
        }
    }
}
