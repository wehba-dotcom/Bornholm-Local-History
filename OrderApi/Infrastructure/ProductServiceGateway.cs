using System;
using Newtonsoft.Json;
using RestSharp;
using SharedModels;
using OrderApi.Models;
using OrderAPI.Models.Dto;
using ProductDto = OrderApi.Models.ProductDto;
using ServiceStack;

namespace OrderApi.Infrastructure
{
    public class ProductServiceGateway : IServiceGateway<ProductDto>
    {
        
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductServiceGateway( IHttpClientFactory httpClientFactory)
        {
            
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ProductDto> GetAsync(int id)
        {
            var client = _httpClientFactory.CreateClient("Product");
            var response = await client.GetAsync($"/api/product/{id}");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);

            if (resp.IsSuccess)
            {
                var productJson = Convert.ToString(resp.Result);
                if (!string.IsNullOrEmpty(productJson))
                {
                    return JsonConvert.DeserializeObject<ProductDto>(productJson);
                }
            }

            return null; // Return null if the product is not found or there's an error.
        }

    }
}
