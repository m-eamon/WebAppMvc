using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppMvc.Models;

namespace WebAppMvc.Services
{
    public class ProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        public ProductService(IHttpClientFactory clientFactory) {
            _clientFactory = clientFactory;
        }

        public IEnumerable<ProductModel> GetProducts() {
            IEnumerable<ProductModel> productList = null;
            var request = new HttpRequestMessage(HttpMethod.Get,
            "https://localhost:5006");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            
            var client = _clientFactory.CreateClient();
            var response = client.GetAsync("api/Products");
            response.Wait();

            var result = response.Result;

            if(result.IsSuccessStatusCode) {
                var readJob = result.Content.ReadFromJsonAsync<IList<ProductModel>>();
                //var readJob = result.Content.ReadAsAsync<IList<ProductModel>>();
                readJob.Wait();
                productList = readJob.Result;  
            }else {
                productList = Enumerable.Empty<ProductModel>();
            } 
            return productList;               
        }
    }
}