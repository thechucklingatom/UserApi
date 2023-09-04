using Microsoft.AspNetCore.Mvc;
using UserApi.Models;

namespace UserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController: ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(User), 200)]
    public List<User> Get([FromServices] List<User> user)
    {
        return user;
    }
}