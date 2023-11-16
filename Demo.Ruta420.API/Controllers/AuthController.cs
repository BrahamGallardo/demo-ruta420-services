using Demo.Ruta420.Application.Interfaces.Services;
using Demo.Ruta420.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Ruta420.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISessionAsyncService _sessionAsync;

        public AuthController(ISessionAsyncService sessionAsync)
        {
            _sessionAsync = sessionAsync;
        }

        [HttpPost]
        public async Task<ActionResult<SessionDto>> Post(string email, string password)
        {
            try
            {
                SessionDto session = await _sessionAsync.GetSessionAsync(email, password);
                return session != null ? Ok(session) : NotFound();
            }
            catch (Exception e)
            {
                var ex = e.InnerException ?? new Exception(e.Message);
                return StatusCode(500, ex);
            }
        }
    }
}
