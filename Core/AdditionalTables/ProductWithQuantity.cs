using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AdditionalTables
{
    public class ProductWithQuantity : BaseDBEntity
    {
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<UserOrder> UserOrder { get; set; }// just for nav prop needs
    }
}
