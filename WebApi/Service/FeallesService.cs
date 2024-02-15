using WebApi.Models;
using WebApi.Service.IService;
using WebApi.SharedModels;
using WebApi.Utility;

namespace WebApi.Service
{
    public class FeallesService : IFeallesService
    {
        private readonly IBaseService _baseService;
        public FeallesService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateFeallesAsync(Feallesbase feallesbase)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data=feallesbase,
                Url = SD.FeallesAPIBase + "/api/feallesbase" 
            });
        }

        public async Task<ResponseDto?> DeleteFeallesAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.FeallesAPIBase + "/api/feallesbase/" + id
            }); 
        }

        public async Task<ResponseDto?> GetAllFeallesesAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.FeallesAPIBase + "/api/feallesbase"
            });
        }

        public async Task<ResponseDto?> GetFeallesAsync(string feallesName)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.FeallesAPIBase + "/api/feallesbase/GetByCode/"+ feallesName
            });
        }

        public async Task<ResponseDto?> GetFeallesByIdAsync(int ID)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.FeallesAPIBase + "/api/feallesbase/" + ID
            });
        }

        public async Task<ResponseDto?> UpdateFeallesAsync(Feallesbase feallesbase)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = feallesbase,
                Url = SD.FeallesAPIBase + "/api/feallesbase",
                ContentType = SD.ContentType.MultipartFormData
            });
        }
    }
}
