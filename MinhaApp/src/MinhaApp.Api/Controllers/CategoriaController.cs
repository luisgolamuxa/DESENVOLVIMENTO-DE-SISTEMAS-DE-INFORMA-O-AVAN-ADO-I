using Microsoft.AspNetCore.Mvc;
using MinhaApp.Application.Interfaces;
using System.Threading.Tasks;

namespace MinhaApp.Api.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // Página com busca via Ajax
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/categoria/search")]
        public async Task<IActionResult> Search([FromQuery] string q)
        {
            var results = await _categoriaService.SearchByNameAsync(q);
            return Json(results);
        }

        [HttpGet]
        [Route("api/categoria")]
        public async Task<IActionResult> GetAll()
        {
            var all = await _categoriaService.GetAllAsync();
            return Ok(all);
        }
    }
}
