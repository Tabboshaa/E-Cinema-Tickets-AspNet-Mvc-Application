using eTickets.Data;
using eTickets.Models;
using eTickets.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IRepository<Producer> producerService;

        public ProducersController(IRepository<Producer>  producerService )
        {
            this.producerService = producerService;
        }

        public async Task<IActionResult> Index()
        {
            var producers= await producerService.GetAllAsync();
            return View(producers);
        }
    }
}
