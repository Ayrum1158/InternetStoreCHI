using Core.Entities;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.AdditionalTables
{
    public class UserOrder : BaseDBEntity
    {
        public virtual User User { get; set; }
        public virtual ICollection<ProductWithQuantity> ProductsBought { get; set; } = new List<ProductWithQuantity>();
        public DateTime TimePurchased { get; set; }
    }
}
