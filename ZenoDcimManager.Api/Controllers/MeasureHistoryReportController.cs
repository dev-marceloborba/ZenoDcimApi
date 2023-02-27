using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using ZenoDcimManager.Domain.AutomationContext.ViewModels;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using System.Collections.Generic;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using FastReport.Web;
using System.Data;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using FastReport.Export.PdfSimple;

namespace ZenoDcimManager.Api.Controllers
{
    [ApiController]
    [Route("v1/reports/measure-history")]
    public class MeasureHistoryReportController : ControllerBase
    {
        private readonly IMeasureRepository _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MeasureHistoryReportController(IMeasureRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> GenerateTemplate()
        {
            var reportFile = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/reports", "measures_report2.frx");
            var freport = new FastReport.Report();

            var filters = new HistoryFiltersViewModel();
            filters.InitialDate = DateTime.Parse("2023-01-01");
            filters.FinalDate = DateTime.Parse("2023-02-01");
            var originalData = await _repository.FindAllAsync(filters);
            var data = DataWithTagNameOnly(originalData);

            freport.Dictionary.RegisterBusinessObject(data, "measures", 10, true);
            freport.Report.Save(reportFile);

            return Ok("Relatório gerado");
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> DownloadPdf()
        {
            try
            {
                var filters = new HistoryFiltersViewModel();
                filters.InitialDate = DateTime.Parse("2023-01-01");
                filters.FinalDate = DateTime.Parse("2023-02-01");
                var data = await _repository.FindAllAsync(filters);

                if (data is null)
                    return NotFound();

                var webReport = new WebReport();
                webReport.Report.Load(Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/reports", "measures_report.frx"));

                GenerateMeasureDataTableReport(data, webReport);

                webReport.Report.Prepare();
                using MemoryStream stream = new MemoryStream();
                webReport.Report.Export(new PDFSimpleExport(), stream);
                stream.Flush();

                byte[] arrayReport = stream.ToArray();

                return File(arrayReport, "application/zip", "MeasuresReport.pdf");
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("MeasureReport")]
        public async Task<ActionResult> MeasureReport(
            [FromQuery] DateTime initialDate,
            [FromQuery] DateTime finalDate
        )
        {
            var reportFile = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/reports", "measures_report2.frx");
            var freport = new FastReport.Report();

            var originalData = await _repository.FindAllAsync(new HistoryFiltersViewModel
            {
                InitialDate = initialDate,
                FinalDate = finalDate
            });
            var data = DataWithTagNameOnly(originalData);

            freport.Report.Load(reportFile);
            freport.Dictionary.RegisterBusinessObject(data, "measures", 10, true);
            freport.Prepare();
            var pdfExport = new PDFSimpleExport();

            using MemoryStream ms = new MemoryStream();
            pdfExport.Export(freport, ms);
            ms.Flush();
            return File(ms.ToArray(), "application/pdf", "MeasuresReport2.pdf");

        }

        private IEnumerable<Measure> DataWithTagNameOnly(IEnumerable<Measure> originalData)
        {
            var data = new List<Measure>();
            foreach (var measure in originalData)
            {
                var fields = measure.Name.Split("*");
                var tagName = fields[fields.Length - 1].Replace("_", " ");
                data.Add(new Measure
                {
                    Name = tagName,
                    Value = measure.Value,
                    Timestamp = measure.Timestamp
                });
            }

            return data;
        }

        private static void GenerateMeasureDataTableReport(IEnumerable<Measure> measures, WebReport webReport)
        {
            var measuresDataTable = new DataTable();

            measuresDataTable.Columns.Add("Name", typeof(string));
            measuresDataTable.Columns.Add("Value", typeof(double));
            measuresDataTable.Columns.Add("Timestamp", typeof(DateTime));

            foreach (var item in measures)
            {
                var fields = item.Name.Split(".");
                var tagName = fields[fields.Length - 1];
                measuresDataTable.Rows.Add(tagName, item.Value, item.Timestamp);
            }
            webReport.Report.RegisterData(measuresDataTable, "Measures");
        }
    }
}