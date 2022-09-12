using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Exceptions;
using Services.Interfaces;

namespace Api.Controllers;

/// <inheritdoc />
/// <summary>
/// Log Controller
/// </summary>
[ApiController]
[Route("logs")]
[Authorize(Roles = "Principal")]
public class LogController : ControllerBase
{
    /// <summary>
    /// Buscar todos os logs
    /// </summary>
    [HttpGet]
    public IActionResult GetAll([FromServices] ILogService service)
    {
        try
        {
            List<Log> logs = service.FindAll();
            return Ok(logs);
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }
}