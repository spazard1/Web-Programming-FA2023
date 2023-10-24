using Gargoyles.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Net;

namespace Gargoyles.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GargoylesController : Controller
    {
        private readonly GargoyleDatabase gargoyleDatabase;

        public GargoylesController(GargoyleDatabase gargoyleDatabase)
        {
            this.gargoyleDatabase = gargoyleDatabase;
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var gargoleModel = this.gargoyleDatabase.Get(name);
            if (gargoleModel == null)
            {
                return NotFound();
            }

            Response.Headers["ETag"] = gargoleModel.ETag();

            return Json(new GargoyleEntity(gargoleModel));
        }

        [HttpPut]
        public IActionResult Put([FromBody] GargoyleEntity entity)
        {
            var gargoleModel = this.gargoyleDatabase.Get(entity.Name);

            if (gargoleModel != null)
            {
                if (Request.Headers.TryGetValue("if-match", out StringValues ifMatch)) {
                    if (gargoleModel.ETag() != ifMatch)
                    {
                        return StatusCode((int)HttpStatusCode.PreconditionFailed);
                    }
                }
                else
                {
                    return StatusCode((int) HttpStatusCode.PreconditionFailed);
                }
            }

            gargoleModel = entity.ToModel();
            this.gargoyleDatabase.AddOrReplace(entity.ToModel());

            return Json(new GargoyleEntity(gargoleModel));
        }
    }
}
