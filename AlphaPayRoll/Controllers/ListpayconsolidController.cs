using AlphaPayRoll.ReportService;
using AspNetCore.Reporting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayLibrary.ListePaie;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Security.Permissions;
using System.Security;

namespace AlphaPayRoll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListpayconsolidController : ControllerBase
    {
        private readonly IWebHostEnvironment oWebHostEnvironment;

        ClasListePayConsolidService oListePayConsolidService = new ClasListePayConsolidService();
        LstPaieConsolid oLstPaieConsolid;

        private readonly HttpClient oHttpClient;

        public ListpayconsolidController(IWebHostEnvironment webHostEnvironment, HttpClient httpClient)
        {
            oWebHostEnvironment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            oHttpClient = httpClient;
        }

        [HttpGet]
        [Route("rptListPayConsolid")]
        public IActionResult rptListPayConsolid( int id)
        {


            oLstPaieConsolid =new LstPaieConsolid();

            var dt = new DataTable();
            dt = oListePayConsolidService.GetListePayConsolidInfo(id);


            string mimetype = "";
            int extension = 1;

            var path = $"{this.oWebHostEnvironment.WebRootPath}\\Reports\\rptListPayConsolid.rdlc";

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("param", "Blazor RDLC Report");
           

            LocalReport localReport = new LocalReport(path);
            

            localReport.AddDataSource("dsetListPay", dt);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimetype);
            

            return File(result.MainStream, "application/pdf");



        }



    }
}
