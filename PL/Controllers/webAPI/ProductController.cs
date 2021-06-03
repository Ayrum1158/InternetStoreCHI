using Core.Contracts.WebAPI;
using Core.Enums;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Controllers.webAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("{category}/{pageSize}/{page}/{sortBy}/{sortHow}")]
        public IEnumerable<ProductInfo> Get(string category, int pageSize, int page, string sortBy, int sortHow)// sortBy expected: 0,1,2
        {
            SortHow sortOrder;
            if (sortHow > 2 || sortHow < 0)
                sortOrder = SortHow.None;
            else
                sortOrder = (SortHow)sortHow;
            var result = productService.GetProductsByCategory(pageSize, pageSize * (page - 1), category, sortBy, sortOrder)
                .Select(p => new ProductInfo() { Id = p.Id, Name = p.Name, Price = p.Price });
            return result;
        }

        [HttpGet("GetMaxPages/{pageSize}")]
        public int GetMaxPages(int pageSize)
        {
            return productService.GetProductsPageAmount(pageSize, "TV");
        }
    }
}
