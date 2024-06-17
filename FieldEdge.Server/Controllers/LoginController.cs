using Microsoft.AspNetCore.Mvc;

namespace FieldEdge.Server.Controllers
{
    [ApiController]
    [Route("api")]
    public class LoginController : ControllerBase
    {
        [HttpGet("Token")]
        public string Get(string secretKey, string userId)
        {
            return FieldEdge.Server.SecurityLayer.Authentication.GenerateJwtToken(secretKey, userId);
        }
    }
}
