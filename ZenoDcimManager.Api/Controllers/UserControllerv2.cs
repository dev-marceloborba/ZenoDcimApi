using System.Collections.Generic;
using ZenoDcimManager.Domain.UserContext.Commands;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Handlers;
using ZenoDcimManager.Domain.UserContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("/v2/users")]
    public class UserControllerv2 : ControllerBase
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
        //[Authorize]
        [AllowAnonymous]
        public ActionResult<IEnumerable<User>> GetAllUsers(
            [FromServices] IUserRepository repository
        )
        {
            // return repository.List();
            return Ok(repository.List());
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
        public ActionResult<ICommandResult> Login(
            [FromBody] LoginCommand command,
            [FromServices] LoginHandler handler
        )
        {
            // return (ICommandResult)handler.Handle(command);
            // return new ContentResult();
            var result = (ICommandResult)handler.Handle(command);
            if (result.Success)
                return Ok(result);
            else
                return Unauthorized(result);
        }

        [Route("edit/{id}")]
        [HttpPost]
        [AllowAnonymous]
        public ICommandResult Edit(
            string id,
            [FromBody] EditUserCommand command,
            [FromServices] UserHandler handler
        )
        {
            var Id = Guid.Parse(id);
            command.Id = Id;
            return (ICommandResult)handler.Handle(command);
        }

        [Route("{id}")]
        [HttpGet]
        public User GetUser(
            string id,
            [FromServices] IUserRepository repository
        )
        {
            var Id = Guid.Parse(id);
            return repository.Find(Id);
        }
    }
}