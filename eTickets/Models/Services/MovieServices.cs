using eTickets.Data;
using eTickets.Models.Repositories;
using eTickets.Models.ViewModels;
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

        //public async Task<Movie> AddMovieAsync(Movie movie , CreateMovieDropDownsVM createMovieDropDownsVM)
        //{
          
        //}

        public async Task<CreateMovieDropDownsVM> GetCreateMovieDropDownsValues()
        {
            var cinemas =await context.Cinemas.OrderBy(n => n.Name).ToListAsync();
            var Actors =await context.Actors.OrderBy(n => n.FullName).ToListAsync();
            var Producers =await context.Producers.OrderBy(n => n.FullName).ToListAsync();
            var response = new CreateMovieDropDownsVM() {Actors=Actors,Cinemas=cinemas,Producers=Producers};

            return response;
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
