using Microsoft.AspNetCore.Mvc;
using PayLibrary.IReport;
using PayLibrary.Report;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.Report
{
    [Route("api/[controller]")]
    [ApiController]
    public class TVeh99RapportController : ControllerBase
    {
        private readonly ITVeh99Rapport oImplement;
        public TVeh99RapportController(ITVeh99Rapport implement)
        {
            this.oImplement = implement;
        }


        [HttpGet]
        public async Task<List<TVeh99Rapport>> GetTout()
        {
            return await oImplement.GetTout();
        }

        [HttpGet("{id}")]
        public async Task<List<TVeh99Rapport>> GetList(string id)
        {
            return await oImplement.GetList(id);
        }



    }
}
