using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;
using static PayAPI.RepServices.AgentComSubBranchService;

namespace PayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentComSubBranchSitController : ControllerBase
    {


        private readonly IAgentComListSubBranchService oImplement;
        public AgentComSubBranchSitController(IAgentComListSubBranchService implement)
        {
            this.oImplement = implement;
        }
        [HttpGet("{reportName}/{reportType}/{Periode}")]
        public async Task<ActionResult> Get(string reportName, string reportType, int Periode)
        {
            var reportFile = await oImplement.GenerateListSubBranchAsync(reportName, reportType, Periode);
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

