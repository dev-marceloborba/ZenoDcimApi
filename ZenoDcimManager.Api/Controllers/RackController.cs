using System;
using System.Collections.Generic;
using System.Linq;
using ZenoDcimManager.Domain.ActiveContext.Commands;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Domain.ActiveContext.Handlers;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Infra.Contexts;
using ZenoDcimManager.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
        public async Task<ICommandResult> CreateRack(
            [FromBody] CreateRackCommand command,
            [FromServices] RackHandler handler
        )
        {
            return (ICommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<Rack>> GetAllRacks()
        {
            return await _repository.List();
        }

        [Route("statistics/total-equipments/{id}")]
        [HttpGet]
        public async Task<int> GetTotalEquipments(
            string id
        )
        {
            var Id = Guid.Parse(id);
            var rack = await _repository.FindById(Id);
            return rack.TotalEquipments();
        }

        [Route("statistics/total-occuped-slots/{id}")]
        [HttpGet]
        public async Task<int> GetTotalOccupedSlots(string id)
        {
            var Id = Guid.Parse(id);
            var rack = await _repository.FindById(Id);
            return rack.TotalOccupedSlots();
        }

        [Route("statistics/available-positions/{id}")]
        [HttpGet]
        public async Task<int[]> GetAvailablePositions(string id)
        {
            var Id = Guid.Parse(id);
            var rack = await _repository.FindById(Id);
            return rack.AvailablePositions();
        }

        [Route("statistics/occuped-positions/{id}")]
        [HttpGet]
        public async Task<int[]> GetOccupedPositions(string id)
        {
            var Id = Guid.Parse(id);
            var rack = await _repository.FindById(Id);
            return rack.OccupedPositions();
        }

        [Route("statistics/percentage-used-space/{id}")]
        [HttpGet]
        public async Task<double> GetPercentageUsedSpace(string id)
        {
            var Id = Guid.Parse(id);
            var rack = await _repository.FindById(Id);
            return rack.PercentUsedSpace();
        }

        [Route("statistics/percentage-available-space/{id}")]
        [HttpGet]
        public async Task<double> GetPercentageAvailableSpace(string id)
        {
            var Id = Guid.Parse(id);
            var rack = await _repository.FindById(Id);
            return rack.PercentAvailableSpace();
        }
    }
}