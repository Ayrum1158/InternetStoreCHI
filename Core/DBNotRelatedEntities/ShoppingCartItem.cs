using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DBNotRelatedEntities
{
    public class ShoppingCartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}
