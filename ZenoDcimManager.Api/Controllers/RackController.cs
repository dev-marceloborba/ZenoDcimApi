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

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("/v1/racks")]
    public class RackController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public ICommandResult CreateRack(
            [FromBody] CreateRackCommand command,
            [FromServices] RackHandler handler
        )
        {
            return (CommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Rack> GetAllRacks(
            [FromServices] IRackRepository repository
        )
        {
            return repository.List();
        }

        [Route("/statistics/total-equipments/{id}")]
        [HttpGet]
        public int GetTotalEquipments(
            string id,
            [FromServices] IRackRepository repository
        )
        {
            var Id = Guid.Parse(id);
            var rack = repository.FindById(Id);
            return rack.TotalEquipments();
        }

        [Route("/statistics/total-occuped-slots/{id}")]
        [HttpGet]
        public int GetTotalOccupedSlots(
            string id,
            [FromServices] IRackRepository repository
        )
        {
            var Id = Guid.Parse(id);
            var rack = repository.FindById(Id);
            return rack.TotalOccupedSlots();
        }

        [Route("/statistics/available-positions/{id}")]
        [HttpGet]
        public int[] GetAvailablePositions(
            string id,
            [FromServices] IRackRepository repository
        )
        {
            var Id = Guid.Parse(id);
            var rack = repository.FindById(Id);
            return rack.AvailablePositions();
        }

        [Route("/statistics/occuped-positions/{id}")]
        [HttpGet]
        public int[] GetOccupedPositions(
            string id,
            [FromServices] IRackRepository repository
        )
        {
            var Id = Guid.Parse(id);
            var rack = repository.FindById(Id);
            return rack.OccupedPositions();
        }

        [Route("/statistics/percentage-used-space/{id}")]
        [HttpGet]
        public double GetPercentageUsedSpace(
            string id,
            [FromServices] IRackRepository repository
        )
        {
            var Id = Guid.Parse(id);
            var rack = repository.FindById(Id);
            return rack.PercentUsedSpace();
        }

        [Route("/statistics/percentage-available-space/{id}")]
        [HttpGet]
        public double GetPercentageAvailableSpace(
            string id,
            [FromServices] IRackRepository repository
        )
        {
            var Id = Guid.Parse(id);
            var rack = repository.FindById(Id);
            return rack.PercentAvailableSpace();
        }
    }
}