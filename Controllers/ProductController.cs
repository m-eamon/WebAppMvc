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
using System.Net.Http.Json;

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
       //}

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index()
        //{
        //    IEnumerable<ProductModel> productModels = _productService.GetProducts();
        //    return View(productModels);
        //}

        
        public IActionResult Index()
        {
            
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

                // client.BaseAddress = new Uri("https://products-api:8085"); // all containers

                var responseTask = client.GetAsync("api/Products");
            
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode) {
                    var readJob = result.Content.ReadFromJsonAsync<IList<ProductModel>>();
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

        public IActionResult Details(long id)
        {
            
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            ProductModel product = null;

            //GET request
            using(var client = new HttpClient(httpClientHandler)) {
            
                // this should be in a separate file
                // client.BaseAddress = new Uri("https://products-api:8085");

                 client.BaseAddress = new Uri("https://localhost:5006");

                var responseTask = client.GetAsync("api/Products/" + id);
            
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode) {
                    var readJob = result.Content.ReadFromJsonAsync<ProductModel>();
                    readJob.Wait();

                    product = readJob.Result; 
                } else {                    
                    _logger.LogInformation("Got No Data :(");
                    _logger.LogInformation("STATUS CODE: " + result.StatusCode.ToString());           
                    // set an empty product item
                    ModelState.AddModelError(string.Empty, "No product found!");    
                }
            }
            return View(product);
        }
    }
}
