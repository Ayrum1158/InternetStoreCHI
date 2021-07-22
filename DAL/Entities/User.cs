using DAL.AdditionalTables;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class User : BaseDBEntity
    {
        public string Login { get; set; }
        public string PasswordHashed { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public virtual ICollection<UserShoppingCart> UserShoppingCart { get; set; } = new List<UserShoppingCart>();
        public virtual ICollection<UserOrder> UserOrder { get; set; } = new List<UserOrder>();
    }
}
