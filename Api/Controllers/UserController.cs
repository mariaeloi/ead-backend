using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

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
    public IActionResult GetAll([FromServices] UserService service)
    {
        List<User> users = new List<User>();
        try {
            users = service.FindAll();
        } catch (Exception e) {
            return NotFound(e.Message);
        }
        
        return Ok(users);
    }

    /// <summary>
    /// Adicionar usuário
    /// </summary>
    [HttpPost]
    public IActionResult Post([FromServices] UserService service, [FromBody] User user){

        User pessoa = new User();
        pessoa = service.Add(user);
        return Ok(pessoa);


    }
}
