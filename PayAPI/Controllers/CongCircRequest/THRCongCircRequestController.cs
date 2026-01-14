using Microsoft.AspNetCore.Mvc;
using PayLibrary.CongCircRequest;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.CongCircRequest
{
    [Route("api/[controller]")]
    [ApiController]
    public class THRCongCircRequestController : ControllerBase
    {
        private readonly ITHRCongCircRequestNew _congeRequests;

        public THRCongCircRequestController(ITHRCongCircRequestNew congeRequests)
        {
            _congeRequests = congeRequests;

        }


        [HttpGet]
        public async Task<List<THRCongCircRequestNew>> GetAllCongeCircRequests()
        {
            return await _congeRequests.GetAllCongeCircRequests();
        }


        [HttpPost]
        public async Task<Resultat> GetUpdateResult([FromBody] THRCongCircRequestNew item)
        {
            if (ModelState.IsValid)
            {
                return await _congeRequests.GetUpdateResult(item);
            }
            else
            {
                return null;
            }
        }


    }
}
