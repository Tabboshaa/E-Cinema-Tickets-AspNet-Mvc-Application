using eTickets.Data;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Models.Services
{
    public class ActorService : IActorService
    {
        private readonly AppDbContext context;

        public ActorService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IReadOnlyList<Actor>> GetAllActorAsync()
        {
            var Actors= await context.Actors.ToListAsync();
            
            return Actors;
        }
        public async Task<Actor> GetActorAsync(int id)
        {
            var Actor = await context.Actors.FirstOrDefaultAsync(n=>n.id == id );
            return Actor;
        }
        public async Task  AddActorAsync(Actor actor)
        {
           await context.Actors.AddAsync(actor);
           await context.SaveChangesAsync();
        }

        public async Task DeleteActor(Actor actor)
        {
           
            context.Actors.Remove(actor);
            context.SaveChanges();
        }

        public async Task<Actor> UpdateActorAsync( Actor actor)
        {
            context.Update(actor);
            await context.SaveChangesAsync();
            return actor;
        }
    }
}
