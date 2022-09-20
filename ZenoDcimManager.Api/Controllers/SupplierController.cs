using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenoDcimManager.Domain.ServiceOrderContext.Commands;
using ZenoDcimManager.Domain.ServiceOrderContext.Entities;
using ZenoDcimManager.Domain.ServiceOrderContext.Repositories;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/suppliers")]
    public class SupplierController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult> CreateAsync(
            [FromBody] CreateSupplierCommand command,
            [FromServices] ISupplierRepository repository
        )
        {
            var supplier = new Supplier
            {
                Company = command.Company,
                Email = command.Email,
                Phone = command.Phone,
                Responsible = command.Responsible
            };

            await repository.CreateAsync(supplier);
            await repository.Commit();

            return Ok(new CommandResult(true, "Fornecedor criado com sucesso", supplier));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateAsync(
            [FromRoute] Guid id,
            [FromBody] CreateSupplierCommand command,
            [FromServices] ISupplierRepository repository)
        {
            var supplier = await repository.FindByIdAsync(id);

            supplier.Company = command.Company;
            supplier.Email = command.Email;
            supplier.Phone = command.Phone;
            supplier.Responsible = command.Responsible;

            repository.Update(supplier);
            await repository.Commit();

            return Ok(new CommandResult(true, "Fornecedor atualizado com sucesso", supplier));
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> FindAllAsync(
            [FromServices] ISupplierRepository repository
        )
        {
            var result = await repository.FindAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("${id}")]
        public async Task<ActionResult> FindById(
            [FromRoute] Guid id,
            [FromServices] ISupplierRepository repository
        )
        {
            var result = await repository.FindByIdAsync(id);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(
            [FromRoute] Guid id,
            [FromServices] ISupplierRepository repository)
        {
            var supplier = new Supplier();
            supplier.SetId(id);

            repository.Delete(supplier);
            await repository.Commit();

            return Ok(new CommandResult(true, "Fornecedor excluído com sucesso", supplier));
        }
    }
}