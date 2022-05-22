using eTickets.Data;
using eTickets.Models;
using eTickets.Models.Repositories;
using eTickets.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieServices movieServices;

        public MoviesController(IMovieServices movieServices)
        {
            this.movieServices = movieServices;
        }


        public async  Task<IActionResult> Index()
        {

         //   var data= await con.Movies.Include(e=>e.Cinema).OrderBy(e=>e.Name).ToListAsync();
            var data= await movieServices.GetAllAsync(e=>e.Cinema);
            return View(data);
        }
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public async Task<Movie> create(Movie movie)
        {

            return movie;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id )
        {
            var movie = await movieServices.GetMovieById(id);
            return View(movie);
        }
    }
}
