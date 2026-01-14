using Microsoft.AspNetCore.Mvc;
using PayLibrary.CONTRACT_GOMISE;
using PayLibrary.Contrat;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.Contrat
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContratEmployeController : ControllerBase
    {
        private readonly IClasContrat oItem;

        public ContratEmployeController(IClasContrat xxx)
        {
            oItem = xxx;
        }


        [HttpGet("{id}")]
        public async Task<List<ClasContrat>> GetContractByMatricule(string id)
        {
            return await oItem.GetContractByMatricule(id);
        }


        [HttpPost]
        public async Task<Resultat> Post([FromBody] ClasContrat item)
        {
            if (ModelState.IsValid)
            {
                return await oItem.GetResutUpdate(item);
            }
            else
            {
                return null;
            }

        }


        [HttpPost("validate")]
        public async Task<Resultat> ValiderCotrat([FromBody] ParamValidContrat param)
        {
            if (ModelState.IsValid)
            {
                return await oItem.ValiderCotrat(param);
            }
            else
            {
                return null;
            }

        }

        //[HttpPost("suspending")]
        //public async Task<Resultat> ContractSuspesion([FromBody] ParamSuspendContract param)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return await oItem.ContractSuspesion(param);
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}




    }
}
