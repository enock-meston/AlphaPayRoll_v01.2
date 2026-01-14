using Microsoft.AspNetCore.Mvc;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.DonBase
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonBaseNivOneNomController : ControllerBase
    {

        private readonly ITabPrmNivOne oTabPrmNivOne;
        public DonBaseNivOneNomController(ITabPrmNivOne tabPrmNivOne)
        {

            oTabPrmNivOne = tabPrmNivOne;
        }

        [HttpGet("{id}")]
        public async Task<List<TabPrmNivOne>> GetListDonNom(string id)
        {
            return (await oTabPrmNivOne.GetDBListName(id)).ToList();
        }

    }
}
