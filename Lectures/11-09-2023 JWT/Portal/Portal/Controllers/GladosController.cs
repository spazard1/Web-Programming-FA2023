using Microsoft.AspNetCore.Mvc;
using Portal.Filters;

namespace Portal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [TypeFilter(typeof(AuthorizationFilter))]
    public class GladosController
    {

        [HttpGet]
        public IActionResult Get()
        {
            return new ContentResult()
            {
                Content = "This is a glaos quote"
            };
        }
    }
}
