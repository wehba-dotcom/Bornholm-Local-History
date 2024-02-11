using WebApi.Models;
using WebApi.SharedModels;

namespace WebApi.Service.IService
{
    public interface IFeallesService
    {
        Task<Response?> GetFeallesAsync(string feallesname);
        Task<Response?> GetAllFeallesesAsync();
        Task<Response?> GetFeallesByIdAsync(int id);
        Task<Response?> CreateFeallesAsync(Feallesbase feallesbase);
        Task<Response?> UpdateFeallesAsync(Feallesbase feallesbase);
        Task<Response?> DeleteFeallesAsync(int id);
    }
}
