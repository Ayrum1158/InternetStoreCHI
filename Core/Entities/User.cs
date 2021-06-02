using Core.AdditionalTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class User : BaseDBEntity
    {
        public string Login { get; set; }
        public string PasswordHashed { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public virtual ICollection<UserShoppingCart> UserShoppingCart { get; set; }
        public virtual ICollection<UserProductsBought> UserProductsBought { get; set; }
    }
}
