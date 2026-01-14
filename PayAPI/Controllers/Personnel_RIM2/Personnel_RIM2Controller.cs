using Microsoft.AspNetCore.Mvc;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Personnel_RIM2;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.Personnel_RIM2
{
    [Route("api/[controller]")]
    public class Personnel_RIM2Controller : ControllerBase
    {
        private readonly IPersonnel_RIM2 oItem;
        public Personnel_RIM2Controller(IPersonnel_RIM2 xxx)
        {
            oItem = xxx;
        }
        [HttpGet]
        public async Task<List<ClassPersonnel_RIM2>> GetPersonnelAll()
        {
            return await oItem.GetPersonnelAll();
        }
        [HttpGet("{id}")]
        public async Task<List<ClassPersonnel_RIM2>> GetPersonnelRech(string id)
        {
            return await oItem.GetPersonnelRech(id);
        }


        [HttpPost]
        public async Task<Resultat> Post([FromBody] ClassPersonnel_RIM2 item)
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

    }

}
