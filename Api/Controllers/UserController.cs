using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Exceptions;

namespace Api.Controllers;

/// <inheritdoc />
/// <summary>
/// User Controller
/// </summary>
[ApiController]
[Route("users")]
[Authorize]
public class UserController : ControllerBase
{
    /// <summary>
    /// Buscar todos os usuários
    /// </summary>
    [HttpGet]
    [Authorize(Roles = "Principal")]
    public IActionResult GetAll([FromServices] UserService service)
    {
        try
        {
            List<User> users = service.FindAll();
            return Ok(users);
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }

    /// <summary>
    /// Adicionar usuário
    /// </summary>
    [HttpPost]
    [AllowAnonymous]
    public IActionResult Post([FromServices] UserService service, [FromBody] User user)
    {
        try 
        {
            User pessoa = service.Add(user);
            return Ok(pessoa);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
        }
    }

    /// <summary>
    /// Buscar usuário
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult GetById([FromServices] UserService service, long id)
    {
        try
        {
            User user = service.GetById(id);
            return Ok(user);
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }


    /// <summary>
    /// Atualizar usuário
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Update([FromServices] UserService service, [FromBody] User user, long id)
    {
        try
        {
            user.Id = id;
            user = service.Update(user);
            return Ok(user);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
        }
        catch (AccessDeniedException e)
        {
            return Unauthorized(new { message = e.Message });
        }
    }

    /// <summary>
    /// Remover usuário
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete([FromServices] UserService service, long id)
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
    }
}
