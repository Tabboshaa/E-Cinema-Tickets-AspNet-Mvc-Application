namespace eTickets.Models.Services
{
    public interface IActorService
    {
        Task<IReadOnlyList<Actor>> GetAllActorAsync();
        Task<Actor> GetActorAsync(int id );
        Task AddActorAsync(Actor actor);
        Task<Actor> UpdateActorAsync(Actor actor);
        Task DeleteActor(Actor actor);

    }
}
