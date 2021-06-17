using System;

namespace InvMgr.Models
{
    public class InventoryItemModel
    {
        public int id { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public int quantity { get; set; }
        public float price { get; set; }
        public float cost { get; set; }
        public DateTime createDate { get; set; }

        public InventoryRepository.InventoryItemModel ToRepositoryModel()
        {
            var repositoryModel = new InventoryRepository.InventoryItemModel
            {
                id = id,
                description = description,
                location = location,
                quantity = quantity,
                price = price,
                cost = cost,
                createDate = createDate,
            };

            return repositoryModel;
        }

        public static InventoryItemModel ToModel(InventoryRepository.InventoryItemModel repositoryModel)
        {
            var inventoryItemModel = new InventoryItemModel
            {
                id = repositoryModel.id,
                description = repositoryModel.description,
                location = repositoryModel.location,
                quantity = repositoryModel.quantity,
                price = repositoryModel.price,
                cost = repositoryModel.cost,
                createDate = repositoryModel.createDate,
            };

            return inventoryItemModel;
        }

        internal InventoryItemModel Clone()
        {
            return (InventoryItemModel)this.MemberwiseClone();
        }
    }
}
