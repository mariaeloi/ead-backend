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
[Route("courses")]
public class LessonController : ControllerBase
{
    /// <summary>
    /// Buscar todas as aulas
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
    /// Adicionar aula
    /// </summary>
    [HttpPost("{courseId}/lessons")]
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
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
        
    }

    /// <summary>
    /// Buscar aula por ID
    /// </summary>
    [HttpGet("lessons/{id}")]
    public IActionResult GetById([FromServices] LessonService service, long id)
    {
        try
        {
            Lesson lesson = service.GetById(id);
            return Ok(lesson);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Atualizar aula
    /// </summary>
    [HttpPut("lessons/{id}")]
    [Authorize(Roles = "Teacher")]
    public IActionResult Update([FromServices] LessonService service, [FromBody] Lesson lesson, long id)
    {
        try
        {
            lesson.Id = id;
            lesson = service.Update(lesson);
            return Ok(lesson);
        }
        catch (AccessDeniedException e)
        {
            return Unauthorized(new { message = e.Message });
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }
}
