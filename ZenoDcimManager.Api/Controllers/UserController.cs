using System.Collections.Generic;
using ZenoDcimManager.Domain.UserContext.Commands;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Handlers;
using ZenoDcimManager.Domain.UserContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using ZenoDcimManager.Domain.UserContext.Commands.Output;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("/v1/users")]
    public class UserController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<ICommandResult> CreateUser(
            [FromBody] CreateUserCommand command,
            [FromServices] UserHandler handler
        )
        {
            var result = (ICommandResult)handler.Handle(command);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [Route("")]
        [HttpGet]
        //[Authorize]
        [AllowAnonymous]
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
        // [Authorize(Roles = "admin")]
        [AllowAnonymous]
        public ActionResult RemoveUserByEmail(
            string email,
            [FromServices] IUserRepository repository
        )
        {
            try
            {
                repository.DeleteByEmail(email);
                repository.Commit();
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

        [Route("edit")]
        [HttpPost]
        [AllowAnonymous]
        public ICommandResult Edit(
            [FromBody] EditUserCommand command,
            [FromServices] UserHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("{email}")]
        [HttpGet]
        public UserOutputCommand GetUser(
            string email,
            [FromServices] IUserRepository repository
        )
        {
            // var Id = Guid.Parse(id);
            // return repository.Find(Id);
            var user = repository.FindUserByEmail(email);
            return new UserOutputCommand(user.Id, user.FirstName, user.LastName, user.Email, user.Role, user.Active);
        }
    }
}