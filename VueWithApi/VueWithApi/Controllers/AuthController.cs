using Microsoft.AspNetCore.Mvc;
using SimpleIAM.PasswordlessLogin.Orchestrators;
using System.Net;
using System.Threading.Tasks;

namespace VueWithApi.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthenticateOrchestrator _authenticateOrchestrator;

        public AuthController(AuthenticateOrchestrator authenticateOrchestrator)
        {
            _authenticateOrchestrator = authenticateOrchestrator;
        }

        [HttpGet("signin/{longCode}")]
        public async Task<IActionResult> SignInLink(string longCode)
        {
            var response = await _authenticateOrchestrator.AuthenticateLongCodeAsync(longCode);
            switch (response.StatusCode)
            {
                case HttpStatusCode.Redirect:
                    return Redirect(response.RedirectUrl);
                case HttpStatusCode.NotFound:
                    return NotFound();
                case HttpStatusCode.Unauthorized:
                default:                    
                    return Redirect("/signin"); // todo: pass response.Message along to be displayed to the user
            }
        }
    }
}
