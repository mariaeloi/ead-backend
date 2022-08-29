using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <inheritdoc />
/// <summary>
/// User Controller
/// </summary>
[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    /// <summary>
    /// Buscar todos os usuários
    /// </summary>
    [HttpGet]
    public IActionResult GetAll()
    {
        return NotFound("Nenhum dado encontrado.");
    }
}
