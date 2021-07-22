using Core.Contracts.PL_BL;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Interfaces
{
    public interface IProductService
    {
        List<ProductInfoContract> GetProductsByCategory(
            int pageSize,
            int from,
            string ProductCategory = "*",
            string SortPropName = "Id",
            SortHow sortHow = SortHow.None);
        ProductInfoContract GetProductById(int id);
        public int GetProductsPageAmount(int pageSize, string ProductCategory = "*");
    }
}
