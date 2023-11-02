using ApiVersioning.Entities.V1U1;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiVersioning.Controllers.V1U1
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.1")]
    public class ValuesController : Controller
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] ValueEntity entity)
        {
            // todo save this entity into the database.

            return Json(entity);
        }
    }
}
