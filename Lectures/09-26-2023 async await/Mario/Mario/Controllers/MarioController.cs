using Mario.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarioController : Controller
    {
        private readonly ExternalMarioService externalMarioService;

        public MarioController(ExternalMarioService externalMarioService)
        {
            this.externalMarioService = externalMarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Json(await externalMarioService.GetMarioLevelResultAsync());
        }
    }
}