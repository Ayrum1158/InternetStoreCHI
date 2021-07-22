using Core.Contracts.PL_BL;
using DAL.Entities;
using BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Enums;
using System.Reflection;
using Core.Interfaces;

namespace BL.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepo;
        private readonly IRepository<ProductCategory> productCategoryRepo;

        public ProductService(
            IRepository<Product> productRepo,
            IRepository<ProductCategory> productCategoryRepo)
        {
            this.productRepo = productRepo;
            this.productCategoryRepo = productCategoryRepo;
        }

        public ProductInfoContract GetProductById(int id)
        {
            var product = productRepo.FindFirst((p) => p.Id == id);

            return new ProductInfoContract()
            {
                Id = product.Id,
                Category = product.Category.CategoryName,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price
            };
        }

        public List<ProductInfoContract> GetProductsByCategory(
            int pageSize,
            int from,
            string ProductCategory = "*",
            string SortPropName = "Id",
            SortHow sortHow = SortHow.None)
        {
            List<Product> products = null;

            var category = productCategoryRepo.FindFirst(pc => pc.CategoryName == ProductCategory);

            var prop = typeof(Product).GetProperty(SortPropName);

            if (ProductCategory != "*")
            {
                products = productRepo.FindAndSortAll(
                    p => p.CategoryId == category.Id,
                    p => prop.GetValue(p, null),
                    sortHow)
                    //
                    .Skip(from)
                    .Take(pageSize)
                    .ToList();
            }
            else// ProductCategory == "*"
            {
                products = productRepo.FindAndSortAll(
                    p => true,
                    p => prop.GetValue(p, null),
                    sortHow)
                    //
                    .Skip(from)
                    .Take(pageSize)
                    .ToList();
            }


            List<ProductInfoContract> result = new List<ProductInfoContract>();

            foreach (var product in products)
            {
                result.Add(new ProductInfoContract()
                {
                    Id = product.Id,
                    Category = product.Category.CategoryName,
                    Description = product.Description,
                    Name = product.Name,
                    Price = product.Price
                });
            }

            return result;
        }

        public int GetProductsPageAmount(int pageSize, string ProductCategory = "*")
        {
            float count;

            if (ProductCategory != "*")
                count = productRepo.FindAll(p => p.Category.CategoryName == ProductCategory).Count();
            else
                count = productRepo.GetAll().Count();

            float res = count / 4;

            return (res > (int)res) ? (int)res + 1 : (int)res;
        }
    }
}
