using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZenoDcimManager.Domain.ActiveContext.Commands.Inputs;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Domain.ActiveContext.Handlers;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/data-center")]
    [AllowAnonymous]
    public class SiteController : ControllerBase
    {
        private readonly IDataCenterRepository _repository;

        public SiteController(IDataCenterRepository repository)
        {
            _repository = repository;
        }

        [Route("site")]
        [HttpPost]
        public async Task<ICommandResult> CreateSite(
            [FromBody] CreateSiteCommand command,
            [FromServices] BuildingHandler handler)
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("site/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateSite(
            [FromRoute] Guid id,
            [FromBody] CreateSiteCommand command,
            [FromServices] BuildingHandler handler)
        {
            try
            {
                var site = await _repository.FindSiteById(id);
                site.Name = command.Name;
                site.TrackModifiedDate();
                _repository.UpdateSite(site);
                await _repository.Commit();
                return Ok(new CommandResult(true, "Site atualizado com sucesso", site));
            }
            catch
            {
                return BadRequest(new CommandResult(false, "Erro ao atualizar o site", new { id }));
            }
        }

        [Route("site")]
        [HttpGet]
        public async Task<IEnumerable<Site>> FindAllSites()
        {
            return await _repository.FindAllSites();
        }

        [Route("site")]
        [HttpDelete]
        public async Task<ActionResult> DeleteSite(Guid id)
        {
            try
            {
                var site = new Site();
                site.SetId(id);
                _repository.DeleteSite(site);
                await _repository.Commit();
                return Ok(site);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}