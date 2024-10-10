using Microsoft.EntityFrameworkCore;
using Proyecto2.Data;
using Proyecto2.Model;
using Proyecto2.Repository.Interface;

namespace Proyecto2.Repository
{
    public class UserRepository<T> : IUserRepository<T> where T : class
    {
        private readonly UserContext _context;
        private readonly DbSet<T> _dbSet;

        public UserRepository(UserContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> GetUserByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Database.ExecuteSqlRaw("EXEC UpdateUser @Id={0}, @Name={1}, @Age={2}",
                ((User)(object)entity).Id, ((User)(object)entity).Name, ((User)(object)entity).Age);
        }

        public async Task DeleteAsync(int id)
        {
            _context.Database.ExecuteSqlRaw("EXEC DeleteUser @Id={0}", id);
        }
    }
}
