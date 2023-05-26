using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZenoDcimManager.Domain.AutomationContext.Commands;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.ViewModels;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("v1/measures")]
    public class MeasuresController : ControllerBase
    {
        private readonly IMeasureRepository _repository;
        private readonly ILogger<MeasuresController> _logger;

        public MeasuresController(IMeasureRepository repository, ILogger<MeasuresController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> FindAllAsync(
            [FromQuery] DateTime initialDate,
            [FromQuery] DateTime finalDate)
        {
            var filter = new HistoryFiltersViewModel
            {
                InitialDate = initialDate,
                FinalDate = finalDate
            };

            var result = await _repository.FindAllAsync(filter);
            var output = new List<MeasureHistoryOutput>();
            foreach (var measure in result)
            {
                var normalizedName = measure.Name.Replace("_", " ");
                var fields = normalizedName.Split("*");
                output.Add(new MeasureHistoryOutput
                {
                    Site = fields[0],
                    Building = fields[1],
                    Floor = fields[2],
                    Room = fields[3],
                    Equipment = fields[4],
                    Parameter = fields[5],
                    Value = measure.Value,
                    Timestamp = measure.Timestamp
                });
            }
            return Ok(output);
        }

        [HttpGet]
        [Route("by-parameter")]
        public async Task<IActionResult> FindByParameterAsync(
           [FromQuery] string parameter,
           [FromQuery] DateTime initialDate,
           [FromQuery] DateTime finalDate)
        {
            var filter = new HistoryFiltersViewModel
            {
                InitialDate = initialDate,
                FinalDate = finalDate
            };

            var result = await _repository.FindByParameterAsync(parameter, filter);
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateMeasureCommand command)
        {
            try
            {
                var measure = new Measure
                {
                    Name = command.Pathname,
                    Value = command.Value,
                    Timestamp = DateTime.UtcNow,
                };
                await _repository.CreateAsync(measure);
                await _repository.Commit();
            }
            catch
            {
                _logger.LogError("Erro ao registrar parâmetro no histórico");
            }

            return Ok();
        }

        [HttpPost]
        [Route("multiple")]
        public async Task<IActionResult> CreateMultipleAsync(
            [FromBody] List<CreateMeasureCommand> command)
        {
            List<Measure> measures = new List<Measure>();
            foreach (var item in command)
            {
                measures.Add(new Measure
                {
                    Name = item.Pathname,
                    Value = item.Value,
                    Timestamp = DateTime.UtcNow,
                });
            }
            await _repository.CreateMultipleAsync(measures);
            await _repository.Commit();
            return Ok();
        }

        [HttpPost]
        [Route("statistics")]
        public async Task<ActionResult> GetStatistics(
            [FromBody] StaisticsParameterFilterViewModel viewModel,
            [FromQuery] DateTime initialDate,
            [FromQuery] DateTime finalDate
            )
        {
            var result = await _repository.GetMeasureStatistics(new CreateMeasureViewModel
            {
                Name = viewModel.Name,
                InitialDate = initialDate,
                FinalDate = finalDate
            });
            return Ok(result);
        }
    }
}