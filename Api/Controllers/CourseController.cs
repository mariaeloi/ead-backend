using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Exceptions;

namespace Api.Controllers;

/// <inheritdoc />
/// <summary>
/// Course Controller
/// </summary>
[ApiController]
[Route("courses")]
public class CourseController : ControllerBase
{
    /// <summary>
    /// Buscar todos os cursos
    /// </summary>
    [HttpGet]
    public IActionResult GetAll([FromServices] CourseService service)
    {
        List<Course> courses = new List<Course>();
        try
        {
            courses = service.FindAll();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }

        return Ok(courses);
    }

    /// <summary>
    /// Adicionar Curso
    /// </summary>
    [HttpPost]
    public IActionResult Post([FromServices] CourseService service, [FromBody] Course curso)
    {
        try
        {
            curso = service.Add(curso);
            return Ok(curso);
        }
        catch (AccessDeniedException e)
        {
            return Unauthorized(new { message = e.Message });
        }
        
    }

    /// <summary>
    /// Buscar curso por ID
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult GetById([FromServices] CourseService service, long id)
    {
        try
        {
            Course course = service.GetById(id);
            return Ok(course);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
