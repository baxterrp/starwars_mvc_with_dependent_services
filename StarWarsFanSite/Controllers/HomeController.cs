using Microsoft.AspNetCore.Mvc;
using StarWarsFanSite.Services;
using System.Threading.Tasks;

namespace StarWarsFanSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFilmAndCharacterService _service;

        public HomeController(IFilmAndCharacterService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var films = await _service.GetAllFilms();
            return View(films);
        }
    }
}
