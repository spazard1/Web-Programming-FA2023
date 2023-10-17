using Common.Entities;
using Kuscotopia.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kuscotopia.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OverseerController : Controller
    {
        private readonly QueueService queueService;

        public OverseerController(QueueService queueService)
        {
            this.queueService = queueService;
        }


        [HttpPost]
        public async Task PostAsync([FromBody] WorkEntity workEntity)
        {
            await this.queueService.QueueWorkAsync(workEntity);
        }
    }
}
