using System.Collections.Generic;
using EvoDcimManager.Domain.UserContext.Commands;
using EvoDcimManager.Domain.UserContext.Entities;
using EvoDcimManager.Domain.UserContext.Handlers;
using EvoDcimManager.Domain.UserContext.Repositories;
using EvoDcimManager.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EvoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("/v1/users")]
    public class UserController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public ICommandResult Create(
            [FromBody] CreateUserCommand command,
            [FromServices] UserHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<User> GetUsers(
            [FromServices] IUserRepository repository
        )
        {
            return repository.List();
        }

        [Route("")]
        [HttpPut]
        public void Update()
        {

        }

        [Route("")]
        [HttpDelete("{email}")]
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
        public ICommandResult Login(
            [FromBody] LoginCommand command,
            [FromServices] LoginHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }
    }
}