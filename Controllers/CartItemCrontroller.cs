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
    public class CartItemController : Controller
    {
      
        private readonly ILogger<CartItemController> _logger;


        public CartItemController(ILogger<CartItemController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index()
        {
            
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            IEnumerable<CartItemModel> cartList = null;
            
            //GET request
            using(var client = new HttpClient(httpClientHandler)) {
            
                // this should be in a separate file
                client.BaseAddress = new Uri("https://shoppingcart-api:8086");

                var responseTask = client.GetAsync("api/CartItems");
            
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode) {
                    var readJob = result.Content.ReadFromJsonAsync<IList<CartItemModel>>();
                    readJob.Wait();

                    cartList = readJob.Result;
                } else {
                    
                    _logger.LogInformation("Got No Data :(");
                    _logger.LogInformation("STATUS CODE: " + result.StatusCode.ToString());           
                    cartList = Enumerable.Empty<CartItemModel>();
                    ModelState.AddModelError(string.Empty, "No items in shopping cart!");    
                }
            }
            return View(cartList);
        }

        public IActionResult Delete(long id)
        {
            
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            //Delete request
            using(var client = new HttpClient(httpClientHandler)) {
            
                // this should be in a separate file
                client.BaseAddress = new Uri("https://shoppingcart-api:8086");
                var responseTask = client.DeleteAsync("api/CartItems/" + id);
            
                responseTask.Wait();

                var result = responseTask.Result;

                if (!result.IsSuccessStatusCode) 
                {
                    _logger.LogInformation("Status Code {0}, {1}",result.StatusCode, 
                    result.StatusCode.ToString());
                }                                 
            }
            return RedirectToAction(nameof(Index));
        }
       
        //public IActionResult Add([Bind("Id,Title,Category,Description,Price,Retailer")] CartItemModel cartItem)
        public IActionResult Add([Bind("Title,Category,Description,Price,Retailer")] CartItemModel cartItem)
        {           
            
            JsonContent content = JsonContent.Create(cartItem);

            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            //Post request
            using(var client = new HttpClient(httpClientHandler)) {
            
                // this should be in a separate file
                client.BaseAddress = new Uri("https://shoppingcart-api:8086");
                
                var responseTask = client.PostAsync("api/CartItems", content);
            
                responseTask.Wait();

                var result = responseTask.Result;

                if (!result.IsSuccessStatusCode) 
                {
                    _logger.LogInformation("Status Code {0}, {1}",result.StatusCode, 
                    result.StatusCode.ToString());
                }                                 
            }
            return RedirectToAction(nameof(Index));
        }      
    }
}
