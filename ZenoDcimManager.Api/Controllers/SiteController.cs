using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZenoDcimManager.Domain.ZenoContext.Commands.Inputs;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Handlers;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/data-center/sites")]
    [AllowAnonymous]
    public class SiteController : ControllerBase
    {
        private readonly ISiteRepository _repository;

        public SiteController(ISiteRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        [HttpPost]
        public async Task<ICommandResult> CreateSite(
            [FromBody] CreateSiteCommand command,
            [FromServices] SiteHandler handler)
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateSite(
            [FromRoute] Guid id,
            [FromBody] CreateSiteCommand command,
            [FromServices] SiteHandler handler)
        {
            try
            {
                var site = await _repository.FindByIdAsync(id);
                site.Name = command.Name;
                site.TrackModifiedDate();
                _repository.Update(site);
                await _repository.Commit();
                return Ok(new CommandResult(true, "Site atualizado com sucesso", site));
            }
            catch
            {
                return BadRequest(new CommandResult(false, "Erro ao atualizar o site", new { id }));
            }
        }

        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<Site>> FindAllSites()
        {
            return await _repository.FindAllAsync();
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> FindSiteById(
            [FromRoute] Guid id
        )
        {
            var result = await _repository.FindByIdAsync(id);
            return Ok(result);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteSite(
            [FromRoute] Guid id)
        {
            try
            {
                var site = new Site();
                site.SetId(id);
                _repository.Delete(site);
                await _repository.Commit();
                return Ok(site);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("load-cards")]
        public async Task<ActionResult> ListCards()
        {
            var result = await _repository.LoadSiteCards();
            return Ok(result);
        }
    }
}