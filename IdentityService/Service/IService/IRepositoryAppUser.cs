namespace IdentityApi.Service.IService
{
    public interface IRepositoryAppUser<T>
    {
        IEnumerable<T> GetAll();
        T Get(string id);
        T Add(T entity);
        void Edit(T entity);
        void Remove(string id);
    }
}
