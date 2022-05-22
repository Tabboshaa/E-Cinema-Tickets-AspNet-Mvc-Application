using eTickets.Data;
using eTickets.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Models.Services
{
    public class MovieServices : Repository<Movie> , IMovieServices
    {
        private readonly AppDbContext context;

        public MovieServices(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Movie> GetMovieById(int id)
        {
           var movie= await context.Movies
                .Include(m => m.Cinema)
                .Include(m => m.Producer)
                .Include(m => m.Actors).ThenInclude(A => A.Actor)
                .FirstOrDefaultAsync(m=>m.id==id);
            return movie;
        }
    }
}
