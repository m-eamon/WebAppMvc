using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppMvc.Models;
using WebAppMvc.Services;
using System.Net.Http;

namespace WebAppMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        private readonly ILogger<ProductController> _logger;

    
        //public ProductController(ProductService productService, ILogger<ProductController> logger)
        //{
        //    _logger = logger;
        //    _productService = productService;
       // }

       public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index()
        //{
         //   IEnumerable<ProductModel> productModels = _productService.GetProducts();
        //    return View(productModels);
        //}

          public IActionResult Index()
        {
            // get my data and then pass to the view of Weather
            //https://localhost:5006/WeatherForecast

            
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            IEnumerable<ProductModel> productList = null;
            
            //GET request
            using(var client = new HttpClient(httpClientHandler)) {
            
                // this should be in a separate file
                client.BaseAddress = new Uri("https://localhost:5006");
               
                var responseTask = client.GetAsync("api/Products");
            
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode) {
                    var readJob = result.Content.ReadAsAsync<IList<ProductModel>>();
                    
                    readJob.Wait();

                    productList = readJob.Result;
                } else {
                    
                    _logger.LogInformation("Got No Data :(");
                    _logger.LogInformation("STATUS CODE: " + result.StatusCode.ToString());           
                    productList = Enumerable.Empty<ProductModel>();
                    ModelState.AddModelError(string.Empty, "No products found!");    
                }
            }
            return View(productList);
        }

    }
}
