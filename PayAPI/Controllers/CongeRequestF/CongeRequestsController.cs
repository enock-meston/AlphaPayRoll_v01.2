using Microsoft.AspNetCore.Mvc;
using PayLibrary.CongeRequestF;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PayAPI.Controllers.CongeRequestF
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllCongeRequestController : ControllerBase
    {
        private readonly ITHRCongCircRequest _congeRequests;


        public AllCongeRequestController(ITHRCongCircRequest congeRequests)
        {
            _congeRequests = congeRequests;

        }


        [HttpGet]
        public async Task<List<THRCongCircRequest>> GetAllCongeRequests()
        {
            return await _congeRequests.GetAllCongeRequests();
        }

        [HttpGet("{id}")]
        public async Task<List<THRCongCircRequest>> GetAllCongeRequestsByMatricule(string id)
        {
            return await _congeRequests.GetAllCongeRequestsByMatricule(id);
        }


        [HttpPost]
        public async Task<Resultat> GetUpdateResult([FromBody] THRCongCircRequest item)
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
