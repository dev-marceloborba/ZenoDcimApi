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
    [AllowAnonymous]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        [HttpPost]
        public async Task<ActionResult> CreateUser(
            [FromBody] CreateUserCommand command,
            [FromServices] UserHandler handler
        )
        {
            var user = await handler.Handle(command);
            if (user.Success)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest(user.Data);
            }
        }

        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _repository.FindAllAsync();
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> FindUserById(Guid id)
        {
            var user = await _repository.FindUser(id);
            return Ok(user);
        }

        [HttpDelete]
        [Route("{id}")]
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
        public async Task<ActionResult> Edit(
            [FromBody] EditUserCommand command,
            [FromServices] UserHandler handler
        )
        {
            var user = await handler.Handle(command);
            if (user.Success)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest(user.Data);
            }
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