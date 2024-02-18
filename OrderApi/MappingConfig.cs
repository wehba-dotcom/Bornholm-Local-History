using AutoMapper;
using OrderApi.Models;
using SharedModels;


namespace OrderApi.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<OrderDto, Order>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
