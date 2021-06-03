using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DBNotRelatedEntities
{
    public class ProductWithQuantityLocal
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPositionPrice { get; set; }
    }
}
