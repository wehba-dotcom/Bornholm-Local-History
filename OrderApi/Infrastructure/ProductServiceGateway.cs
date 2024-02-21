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
            var apiContet = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContet);
            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(resp.Result));
            }
            return new ProductDto();
        }
    }
}
