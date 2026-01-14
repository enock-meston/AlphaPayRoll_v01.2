using Microsoft.AspNetCore.Mvc;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.DonBase
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonBaseNivOneBisController : ControllerBase
    {
        private readonly ITabPrmNivOne oTabPrmNivOne;
        public DonBaseNivOneBisController(ITabPrmNivOne tabPrmNivOne)
        {

            oTabPrmNivOne = tabPrmNivOne;
        }

        [HttpGet("{id}")]
        public async Task<TabPrmNivOne> GetDonBRecord(string id)
        {
            return await oTabPrmNivOne.GetDBRec(id);
        }

        //// POST api/<DonBaseNivOneBisController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<DonBaseNivOneBisController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<DonBaseNivOneBisController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
