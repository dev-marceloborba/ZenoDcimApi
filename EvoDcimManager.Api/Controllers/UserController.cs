using System.Collections.Generic;
using EvoDcimManager.Domain.UserContext.Commands;
using EvoDcimManager.Domain.UserContext.Entities;
using EvoDcimManager.Domain.UserContext.Handlers;
using EvoDcimManager.Domain.UserContext.Repositories;
using EvoDcimManager.Shared.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EvoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("/v1/users")]
    public class UserController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        [AllowAnonymous]
        public ICommandResult Create(
            [FromBody] CreateUserCommand command,
            [FromServices] UserHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        [Authorize]
        public IEnumerable<User> GetUsers(
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

        [Route("")]
        [HttpDelete("{email}")]
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