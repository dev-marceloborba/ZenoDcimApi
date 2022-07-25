using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.ZenoContext.Commands;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Handlers;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("/v1/racks")]
    public class RackController : ControllerBase
    {
        private readonly IRackRepository _repository;

        public RackController(IRackRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ICommandResult> CreateRack(
            [FromBody] CreateRackCommand command,
            [FromServices] RackHandler handler
        )
        {
            return (ICommandResult)await handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Rack>> GetAllRacks()
        {
            return await _repository.FindAllAsync();
        }

        [Route("statistics/total-equipments/{id}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<int> GetTotalEquipments(Guid id)
        {
            return (await _repository.FindByIdAsync(id)).TotalEquipments();
        }

        [Route("statistics/total-occuped-slots/{id}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<int> GetTotalOccupedSlots(Guid id)
        {
            return (await _repository.FindByIdAsync(id)).TotalOccupedSlots();
        }

        [Route("statistics/available-positions/{id}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<int[]> GetAvailablePositions(Guid id)
        {
            return (await _repository.FindByIdAsync(id)).AvailablePositions();
        }

        [Route("statistics/occuped-positions/{id}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<int[]> GetOccupedPositions(Guid id)
        {
            return (await _repository.FindByIdAsync(id)).OccupedPositions();
        }

        [Route("statistics/percentage-used-space/{id}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<double> GetPercentageUsedSpace(Guid id)
        {
            return (await _repository.FindByIdAsync(id)).PercentUsedSpace();
        }

        [Route("statistics/percentage-available-space/{id}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<double> GetPercentageAvailableSpace(Guid id)
        {
            return (await _repository.FindByIdAsync(id)).PercentAvailableSpace();
        }

        [Route("statistics/{id}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetStatistics(Guid id)
        {
            var rack = await _repository.FindByIdAsync(id);
            try
            {
                var statistics = new
                {
                    TotalEquipments = rack.TotalEquipments(),
                    TotalOccupedSlots = rack.TotalOccupedSlots(),
                    AvailablePositions = rack.AvailablePositions(),
                    OccupedPositions = rack.OccupedPositions(),
                    PercentageUsedSpace = rack.PercentUsedSpace(),
                    PercentageAvailableSpace = rack.PercentAvailableSpace()
                };

                return Ok(statistics);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}