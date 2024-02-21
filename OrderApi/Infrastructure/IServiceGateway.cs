using OrderApi.Models;
using System.Collections.Generic;

namespace OrderApi.Infrastructure
{
    public interface IServiceGateway<T>
    {
        Task<ProductDto> GetAsync(int id);
    }
}
