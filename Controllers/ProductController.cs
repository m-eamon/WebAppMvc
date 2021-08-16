using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppMvc.Models;
using WebAppMvc.Services;

namespace WebAppMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        private readonly ILogger<ProductController> _logger;

    
        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _logger = logger;
            _productService = productService;
        }
        public IActionResult Index()
        {
            IEnumerable<ProductModel> productModels = _productService.GetProducts();
            return View(productModels);
        }

    }
}
