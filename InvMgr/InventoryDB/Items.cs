using System;
using System.Collections.Generic;

namespace InventoryDB
{
    public partial class Items
    {
        public int id { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public double cost { get; set; }
        public DateTime createDate { get; set; }
    }
}
