using Hobbits.Entities;
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
            hobbitLogger.Log("Starting GET ALL");

            var hobbits = hobbitsDatabase.GetAll().Select(hobbit => new HobbitEntity(hobbit));

            hobbitLogger.Log("Finishing GET ALL");

            return Json(hobbits);
        }

        [HttpGet("{index:int}")]
        public IActionResult Get(int index)
        {
            hobbitLogger.Log("Starting GET ONE " + index);

            if (index < 0 || index >= hobbitsDatabase.Count)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            return Json(new HobbitEntity(hobbitsDatabase.Get(index)));
        }

        [HttpPost]
        public IActionResult Post([FromBody] HobbitEntity hobbitEntity)
        {
            hobbitLogger.Log("Starting POST");

            hobbitsDatabase.Add(hobbitEntity.ToModel());

            return Json(hobbitEntity);
        }
    }
}