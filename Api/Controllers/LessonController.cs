using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Exceptions;

namespace Api.Controllers;

/// <inheritdoc />
/// <summary>
/// Lesson Controller
/// </summary>
[ApiController]
[Route("course")]
public class LessonController : ControllerBase
{
    /// <summary>
    /// Buscar todas as lições
    /// </summary>
    [HttpGet("lessons")]
    public IActionResult GetAll([FromServices] LessonService service)
    {
        List<Lesson> lessons = new List<Lesson>();
        try
        {
            lessons = service.FindAll();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }

        return Ok(lessons);
    }

    /// <summary>
    /// Adicionar Lição
    /// </summary>
    [HttpPost("{courseId}/lesson")]
    [Authorize(Roles = "Teacher")]
    public IActionResult Post([FromRoute] long courseId, [FromBody] Lesson lesson, [FromServices] LessonService service)
    {
        try
        {
            lesson = service.Add(lesson, courseId);
            return Ok(lesson);
        }
        catch (AccessDeniedException e)
        {
            return Unauthorized(new { message = e.Message });
        }
        
    }
}
