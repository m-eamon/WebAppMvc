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
    class ProductService
    {
        public HttpClient Client    { get; }
        public ProductService(HttpClient httpClient) {
            httpClient.BaseAddress = new Uri("https://localhost:5006");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            Client = httpClient;
        }

        public async Task<IEnumerable<ProductModel>> GetProducts() 
        {
            return await Client.GetFromJsonAsync<IEnumerable<ProductModel>>("products");
        }

        //public async Task<WeatherModel> GetWeatherByCountry(int? id) 
        //{
        //    return await Client.GetFromJsonAsync<WeatherModel>("weatherforecast/" + id);
        //}

    }
}