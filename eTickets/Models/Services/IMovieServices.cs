using eTickets.Models.Repositories;

namespace eTickets.Models.Services
{
    public interface IMovieServices : IRepository<Movie>
    {
        Task<Movie> GetMovieById(int id);
    }
}
