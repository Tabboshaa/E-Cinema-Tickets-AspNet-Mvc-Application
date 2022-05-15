using eTickets.Data;
using eTickets.Models;
using eTickets.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService actorService;

        public ActorsController( IActorService actorService)
        {
            this.actorService = actorService;
        }

        public async Task<IActionResult> Index()
        {
            var data= await actorService.GetAllActorAsync();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await actorService.AddActorAsync(actor);
            return RedirectToAction(nameof(Index));
         }

        public async Task<IActionResult> Details(int id)
        {
            var actor= await actorService.GetActorAsync(id);
            if(actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var actor = await actorService.GetActorAsync(id);
            if(actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Actor actor)
        {
          await actorService.UpdateActorAsync(actor);
           
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id )
        {
         
          var actor = await actorService.GetActorAsync(id);
            if (actor == null) { return View("NotFound"); }
          return RedirectToAction(nameof(Index));
        }

    }
}
