using Core.AdditionalTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Product : BaseDBEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ProductCategory Category { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<UserShoppingCart> UserShoppingCart { get; set; } = new List<UserShoppingCart>();
        public virtual ICollection<UserOrder> UserOrder { get; set; } = new List<UserOrder>();
    }
}
