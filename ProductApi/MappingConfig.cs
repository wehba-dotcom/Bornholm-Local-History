using AutoMapper;
using ProductApi.Models;
using ProductApi.Models.Dto;

namespace ProductApi.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<FastningBookDto, FastningBook>();
                config.CreateMap<FastningBook, FastningBookDto>();
            });
            return mappingConfig;
        }
    }
}
