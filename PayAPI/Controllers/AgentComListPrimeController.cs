using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;
using static PayAPI.RepServices.AgentComListPrimeService;

namespace PayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentComListPrimeController : ControllerBase
    {

        private readonly IAgentComListPrimeService oImplement;
        public AgentComListPrimeController(IAgentComListPrimeService implement)
        {
            this.oImplement = implement;
        }
        [HttpGet("{reportName}/{reportType}")]
        public async Task<ActionResult> Get(string reportName, string reportType)
        {
            var reportFile = await oImplement.GenerateListPrimeAsync(reportName, reportType);
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
