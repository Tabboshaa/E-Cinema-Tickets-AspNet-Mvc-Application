using eTickets.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eTickets.Models.Repositories
{
    public class Repository<T> : IRepository<T> where T :class, IEntityBase , new()
    {
        private readonly AppDbContext context;

        public Repository(AppDbContext context )
        {
            this.context = context;
        }

        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete( int id )
        {
            var e = GetEntityAsync(id);
            EntityEntry entityEntry = context.Entry<Task<T>>(e);
            entityEntry.State = EntityState.Modified;
        }

        public async Task<T> GetEntityAsync(int id)
        {
          var result=  await context.Set<T>().FirstOrDefaultAsync(x=>x.id==id);
            return result;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var result = await context.Set<T>().ToListAsync();

            return result;
        }

        public async Task UpdateAsync(T entity)
        {
            EntityEntry entityEntry = context.Entry<T>(entity);
            entityEntry.State=EntityState.Modified;
        }
    }
}
