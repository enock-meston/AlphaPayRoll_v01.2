using Microsoft.AspNetCore.Mvc;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.ParamDonBase
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarantByProductController : ControllerBase
    {
        private readonly ITGAs55Garantie oImplement;
        public GarantByProductController(ITGAs55Garantie implement)
        {
            this.oImplement = implement;
        }


        [HttpGet("{id}")]
        public async Task<List<TGAs55Garantie>> GetGarantieProdList(int id)
        {
            return await oImplement.GetGarantieProdList(id);
        }


    }
}
