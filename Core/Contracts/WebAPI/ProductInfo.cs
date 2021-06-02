using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts.WebAPI
{
    public class ProductInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
