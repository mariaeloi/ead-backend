using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers;

/// <inheritdoc />
/// <summary>
/// User Controller
/// </summary>
[ApiController]
[Route("courses")]
public class CourseController : ControllerBase
{
    /// <summary>
    /// Buscar todos os usuários
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
        curso = service.Add(curso);
        return Ok(curso);
    }
}
