using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.CustomComponent;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Controllers
{
    public class ProductController : ControllerWithUserSession
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult ProductPage(int productId)
        {
            var response = productService.GetProductById(productId);

            ProductInfoVM pivm = new ProductInfoVM()
            {
                Id = response.Id,
                Category = response.Category,
                Description = response.Description,
                Name = response.Name,
                Price = response.Price
            };

            return View(pivm);
        }
    }
}
