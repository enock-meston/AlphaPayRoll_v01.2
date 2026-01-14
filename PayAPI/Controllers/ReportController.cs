using Microsoft.AspNetCore.Mvc;
using PayAPI.RepServices;
using System.Net.Mime;
using System.Threading.Tasks;

namespace RIMReportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        private readonly IReportingService oImplement;
        public ReportController(IReportingService implement)
        {
            this.oImplement = implement;
        }
        [HttpGet("{reportName}/{reportType}/{id}")]
        public async Task<ActionResult> Get(string reportName, string reportType, string id)
        {
            var reportFile = await oImplement.GenerateRDLCReportAsync(reportName, reportType, id);
            return File(reportFile, MediaTypeNames.Application.Octet, GetReportName(reportName, reportType));
        }
        private string GetReportName(string reportName, string reportType)
        {



            var outputFileName = reportName + ".pdf";
            switch (reportType.ToUpper())
            {
                default:
                case "PDF":
                    outputFileName = reportName + ".pdf";
                    break;
                case "XLS":
                    outputFileName = reportName + ".xls";
                    break;
                case "WORD":
                    outputFileName = reportName + ".doc";
                    break;
            }



            return outputFileName;
        }

    }
}
