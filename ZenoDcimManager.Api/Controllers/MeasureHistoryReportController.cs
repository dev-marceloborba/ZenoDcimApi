using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

using System.IO;
using Microsoft.EntityFrameworkCore;
using Razor.Templating.Core;
using iText.Html2pdf;
using System;
using ZenoDcimManager.Domain.AutomationContext.ViewModels;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Api.Pages.Reports;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/reports/measure-history")]
    public class MeasureHistoryReportController : ControllerBase
    {
        private readonly IMeasureRepository _repository;

        public MeasureHistoryReportController(IMeasureRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> DownloadPdf()
        {
            var filters = new HistoryFiltersViewModel();
            filters.InitialDate = DateTime.Parse("2023-01-01");
            filters.FinalDate = DateTime.Parse("2023-02-01");
            var data = await _repository.FindAllAsync(filters);
            var model = new HistoryModel(_repository);
            model.Measures = data;

            var html = await RazorTemplateEngine.RenderAsync("~/Pages/Reports/MeasureHistory.cshtml", model);

            return Ok(html);

            // using (MemoryStream memoryStream = new MemoryStream())
            // {
            //     var pdf = new PdfDocument(new PdfWriter(memoryStream));
            //     var document = new Document(pdf);



            //     var htmlElements = HtmlConverter.ConvertToElements(html);
            //     using (StringReader stringReader = new StringReader(html))
            //     {
            //         // htmlElements.Add(stringReader);
            //     }

            //     document.Close();
            //     Response.ContentType = "application/pdf";
            //     Response.Headers.Add("content-disposition", "attachment;filename=Report.pdf");
            //     await Response.Body.WriteAsync(memoryStream.ToArray(), 0, memoryStream.ToArray().Length);

            // }


        }
    }
}