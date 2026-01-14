using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.PlanningConge;
using System.Collections.Generic;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.PlanningCongeFord
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanningCongeController : ControllerBase
    {
        // GET: api/<IPlanningCongeAllController>
        private readonly ITHRPlanningConge oImplement;
        public PlanningCongeController(ITHRPlanningConge implement)
        {
            this.oImplement = implement;
        }

        [HttpGet]
        public async Task<List<THRPlanningConge>> GetPlanningCongeAll()
        {
            return await oImplement.GetAllPlanningConge();
        }

        [HttpGet("SBranch/{id}")]
        public async Task<List<THRPlanningConge>> GetPlanningCongeBySBranch(int id)
        {
            return await oImplement.GetPlanningCongeBySBranch(id);
        }
        [HttpGet("Matricule/{id}")]
        public async Task<List<THRPlanningConge>> GetPlanningCongeByMatricule(string id)
        {
            return await oImplement.GetPlanningCongeByMatricule(id);
        }

        [HttpPost("NumTranche")]
        public async Task<Resultat> GetNumTranche([FromBody] ParamNumTranche item)
        {
            if (ModelState.IsValid)
            {
                return await oImplement.GetNumTranche(item);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public async Task<Resultat> UpdatePlanningConge([FromBody] THRPlanningConge item)
        {
            if (ModelState.IsValid)
            {
                return await oImplement.UpdatePlanningConge(item);
            }
            else
            {
                return null;
            }

        }

    }
}


