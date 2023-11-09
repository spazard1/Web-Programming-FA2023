using Microsoft.AspNetCore.Mvc;
using Portal.Services;
using System.Security.Claims;

namespace Portal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController
    {
        private readonly ISecurityProvider securityProvider;

        public LoginController(ISecurityProvider securityProvider) {
            this.securityProvider = securityProvider;
        }

        // This will be POST in your assignment
        [HttpGet]
        public IActionResult Login()
        {
            var claims = new List<Claim>() { new Claim("username", "yacste") };

            var token = this.securityProvider.GetToken(claims);

            return new ContentResult()
            {
                Content = token,
            };
        }
    }
}
