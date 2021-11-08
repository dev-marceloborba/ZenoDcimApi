using System.Collections.Generic;
using ZenoDcimManager.Domain.UserContext.Commands;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Handlers;
using ZenoDcimManager.Domain.UserContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("/v1/users")]
    public class UserController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        [AllowAnonymous]
        public ICommandResult CreateUser(
            [FromBody] CreateUserCommand command,
            [FromServices] UserHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        [Authorize]
        public IEnumerable<User> GetAllUsers(
            [FromServices] IUserRepository repository
        )
        {
            return repository.List();
        }

        [Route("")]
        [HttpPut]
        [Authorize]
        public void Update()
        {

        }

        [Route("{email}")]
        [HttpDelete]
        [Authorize(Roles = "admin")]
        public ActionResult RemoveUserByEmail(
            string email,
            [FromServices] IUserRepository repository
        )
        {
            try
            {
                repository.DeleteByEmail(email);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public ICommandResult Login(
            [FromBody] LoginCommand command,
            [FromServices] LoginHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }
    }
}