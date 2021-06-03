using Core.Contracts.PL_BL;
using Core.DBNotRelatedEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models
{
    public class UserOrdersPageVM
    {
        public List<UserOrdersContract> ItemsPurchased { get; set; }// collection of separate orders
    }
}
