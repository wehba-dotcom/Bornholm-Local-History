using OrderApi.Models;
using System.Collections.Generic;

namespace OrderApi.Infrastructure
{
    public interface IServiceGateway<T>
    {
        Task<T> GetAsync(int id);
    }
}
