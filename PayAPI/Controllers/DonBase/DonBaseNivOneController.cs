using Microsoft.AspNetCore.Mvc;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.DonBase
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonBaseNivOneController : ControllerBase
    {
        private readonly ITabPrmNivOne oTabPrmNivOne;
        public DonBaseNivOneController(ITabPrmNivOne tabPrmNivOne)
        {

            oTabPrmNivOne = tabPrmNivOne;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<TabPrmNivOne>> GetListDon(int id)
        {
            return await oTabPrmNivOne.GetDBList(id);
        }


        [HttpPost]
        public async Task<Resultat> MajDonBaseNivOne([FromBody] TabPrmNivOne pTabPrmNivOne)

        {



            if (ModelState.IsValid) return await oTabPrmNivOne.MajDonBaseNivOne(pTabPrmNivOne);
            return null;


        }



    }
}
