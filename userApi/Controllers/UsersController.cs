using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserApi.Models;

namespace UserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController: ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(User), 200)]
    public List<User> GetUsers([FromServices] List<User> users)
    {
        return users;
    }

    [HttpPost]
    public ObjectResult AddUser(User user, [FromServices] List<User> users)
    {
        if (users.Exists(u => u.Email == user.Email))
        {
            return Ok("user already added");
        }
        
        users.Add(user);
        return Ok("user added to list");
    }

    [HttpDelete]
    [Authorize]
    public ObjectResult DeleteUser(string email, [FromServices] List<User> users)
    {
        if (users.Exists(user => user.Email == email))
        {
            users.RemoveAll(user => user.Email == email);
            return Ok("deleted user");
        }

        return Ok("no user to delete");
    }
    
}