using Hobbits.Entities;
using Hobbits.Filters;
using Hobbits.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hobbits.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(RequestLoggingFilter))]
    [ServiceFilter(typeof(RequestIdFilter))]
    public class HobbitsController : Controller
    {
        private readonly HobbitLogger hobbitLogger;
        private readonly HobbitsDatabase hobbitsDatabase;

        public HobbitsController(HobbitLogger hobbitLogger, HobbitsDatabase hobbitsDatabase) { 
            this.hobbitLogger = hobbitLogger;
            this.hobbitsDatabase = hobbitsDatabase;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var hobbits = hobbitsDatabase.GetAll().Select(hobbit => new HobbitEntity(hobbit));
            hobbitLogger.Log("Hobbits returned: " + hobbits.Count());
            return Json(hobbits);
        }

        [HttpGet("{index:int}")]
        public IActionResult Get(int index)
        {
            if (index < 0 || index >= hobbitsDatabase.Count)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            return Json(new HobbitEntity(hobbitsDatabase.Get(index)));
        }

        [HttpPost]
        public IActionResult Post([FromBody] HobbitEntity hobbitEntity)
        {
            hobbitsDatabase.Add(hobbitEntity.ToModel());

            return Json(hobbitEntity);
        }
    }
}