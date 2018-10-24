using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VueWithApi.Models;

namespace VueWithApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpGet("app-info")]
        public ActionResult<AppInfo> GetAppInfo()
        {
            return new AppInfo() {
                MinimumPasswordLength = 8,
                MinimumPasswordStrength = 30,
                User = new UserInfo() {
                    IsAuthenticated = User.Identity.IsAuthenticated,
                    Email = User.Identity.Name ?? "-",
                    Username = User.Identity.Name ?? "anon",
                },
                Permissions = User.Identity.IsAuthenticated ? 
                    new[] { "view-profile", "set-password" } : 
                    new string[] { }
            };
        }

        [Authorize]
        [HttpGet("protected-info")]
        public IActionResult GetProtectedInfo()
        {
            return new JsonResult(new
            {
                Message = "Hello! This message is from a protected API."
            });
        }
    }
}
