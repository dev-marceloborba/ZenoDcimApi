using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenoDcimManager.Domain.ServiceOrderContext.Repositories;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/work-order-events")]
    public class WorkOrderEventController : ControllerBase
    {
        private readonly IWorkOrderEventRepository _repository;

        public WorkOrderEventController(IWorkOrderEventRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        [HttpGet]
        public async Task<ActionResult> FindAll()
        {
            var result = await _repository.FindAllAsync();
            return Ok(result);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> FindById(
            [FromRoute] Guid id
        )
        {
            var result = await _repository.FindByIdAsync(id);
            return Ok(result);
        }
    }
}