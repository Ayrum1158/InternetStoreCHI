using Core.DBNotRelatedEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts.PL_BL
{
    public class UserOrdersContract// each separate order
    {
        public int OrderId { get; set; }
        public DateTime TimePurchased { get; set; }
        public List<ProductWithQuantityLocal> ItemsPurchased { get; set; }
        public decimal TotalOrderPrice { get; set; }
    }
}
