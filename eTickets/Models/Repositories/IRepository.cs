namespace eTickets.Models.Repositories
{
    public interface IRepository<T> where T : IEntityBase
    { 
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetEntityAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task Delete(int id );
    }
}
