using Microsoft.AspNetCore.Mvc;
using PayAPI.RepServices;
using System.Net.Mime;
using System.Threading.Tasks;

namespace PayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListPayRIPPSController : ControllerBase
    {


        private readonly IPayrollListRIPPSService oImplement;
        public ListPayRIPPSController(IPayrollListRIPPSService implement)
        {
            this.oImplement = implement;
        }
        [HttpGet("{reportName}/{reportType}")]
        public async Task<ActionResult> Get(string reportName, string reportType)
        {
            var reportFile = await oImplement.GenerateListRIPPSAsync(reportName, reportType);
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

