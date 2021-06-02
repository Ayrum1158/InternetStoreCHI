using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts.PL_BL
{
    public class ProductInfoContract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
