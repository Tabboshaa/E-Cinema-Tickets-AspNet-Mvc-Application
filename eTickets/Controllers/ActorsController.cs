using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext context;

        public ActorsController( AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data= await context.Actors.ToListAsync();
            return View(data);
        }
    }
}
