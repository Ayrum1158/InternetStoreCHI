using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AdditionalTables
{
    public class UserShoppingCart
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
