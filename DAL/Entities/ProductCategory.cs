using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace DAL.Entities
{
    public class ProductCategory : BaseDBEntity
    {
        public string CategoryName { get; set; }
    }
}
