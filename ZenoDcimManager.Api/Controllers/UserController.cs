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
using System.Threading.Tasks;

namespace ZenoDcimManager.Api.Controllers
{           
    [ApiController]
    [Route("/v1/users")]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ICommandResult> CreateUser(
            [FromBody] CreateUserCommand command,
            [FromServices] UserHandler handler
        )
        {
            return await handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        //[Authorize]
        [AllowAnonymous]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _repository.List();
        }

        [Route("{id}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<UserOutputCommand> FindUserById(Guid id)
        {
            var user = await _repository.FindUserById(id);
            return new UserOutputCommand(user.Id, user.FirstName, user.LastName, user.Email, user.Role, user.Active);
        }

        [Route("")]
        [HttpPut]
        [Authorize]
        public void Update()
        {

        }

        [HttpDelete]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> DeleteUserById(Guid id)
        {
            try
            {
                var user = new User();
                user.SetId(id);
                _repository.Delete(user);
                await _repository.Commit();
                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<ICommandResult>> Login(
            [FromBody] LoginCommand command,
            [FromServices] LoginHandler handler
        )
        {
            var result = await handler.Handle(command);
            if (result.Success)
                return Ok(result);
            else
                return Unauthorized(result);
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

        //[Route("{email}")]
        //[HttpGet]
        //public UserOutputCommand GetUser(
        //    string email,
        //    [FromServices] IUserRepository repository
        //)
        //{
        //    // var Id = Guid.Parse(id);
        //    // return repository.Find(Id);
        //    var user = repository.FindUserByEmail(email);
        //    return new UserOutputCommand(user.Id, user.FirstName, user.LastName, user.Email, user.Role, user.Active);
        //}
    }
}