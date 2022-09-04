using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Exceptions;

namespace Api.Controllers;

/// <inheritdoc />
/// <summary>
/// Auth Controller
/// </summary>
[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    /// <summary>
    /// Realizar login
    /// </summary>
    [HttpPost("login")]
    [AllowAnonymous]
    public IActionResult Login([FromServices] AuthService service, [FromBody] User user)
    {
        try
        {
            var result = service.Authenticate(user);
            return Ok(result);
        } catch (Exception e) when (e is NotFoundException || e is BadCredentialsException)
        {
            return NotFound(new { message = "Usuário ou senha inválidos" });
        }
    }
}
