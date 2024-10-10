namespace Proyecto2.Repository.Interface
{
    public interface IUserRepository<T> where T : class
    {
        Task<T> GetUserByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
