using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Teacher")]
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
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
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
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Atualizar curso
    /// </summary>
    [HttpPut("{id}")]
    [Authorize(Roles = "Teacher")]
    public IActionResult Update([FromServices] CourseService service, [FromBody] Course course, long id)
    {
        try
        {
            course.Id = id;
            course = service.Update(course);
            return Ok(course);
        }
        catch (AccessDeniedException e)
        {
            return Unauthorized(new { message = e.Message });
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
        }
    }

    /// <summary>
    /// Remover curso
    /// </summary>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Teacher")]
    public IActionResult Delete([FromServices] CourseService service, long id)
    {
        try
        {
            service.Delete(id);
            return NoContent();
        }
        catch (AccessDeniedException e)
        {
            return Unauthorized(new { message = e.Message });
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Realizar matrícula
    /// </summary>
    [HttpPut("{idCourse}/students")]
    [Authorize]
    public IActionResult Subscribe([FromServices] CourseService service, [FromRoute] long idCourse)
    {
        try
        {
            service.Subscribe(idCourse);
            return NoContent();
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
    /// Cancelar matrícula
    /// </summary>
    [HttpPut("{idCourse}/students/{idStudent}")]
    [Authorize]
    public IActionResult Unsubscribe([FromServices] CourseService service, [FromRoute] long idCourse, [FromRoute] long idStudent)
    {
        try
        {
            service.Unsubscribe(idCourse, idStudent);
            return NoContent();
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
