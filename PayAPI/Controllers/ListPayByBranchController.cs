using Microsoft.AspNetCore.Mvc;
using PayAPI.RepServices;
using System.Net.Mime;
using System.Threading.Tasks;

namespace PayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListPayByBranchController : ControllerBase
    {


        private readonly IListPayByBranchService oImplement;
        public ListPayByBranchController(IListPayByBranchService implement)
        {
            this.oImplement = implement;
        }
        [HttpGet("{reportName}/{reportType}/{BrancLocID}")]
        public async Task<ActionResult> Get(string reportName, string reportType, string BrancLocID)
        {
            var reportFile = await oImplement.GenerateRepListPayAsync(reportName, reportType, BrancLocID);
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

