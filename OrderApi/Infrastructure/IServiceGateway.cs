namespace OrderApi.Infrastructure
{
    public interface IServiceGateway<T>
    {
        Task<T> GetAsync(int ID);
    }
}
