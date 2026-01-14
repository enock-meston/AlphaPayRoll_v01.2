using Microsoft.AspNetCore.Mvc;
using PayLibrary.Depart;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.Depart
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartController : ControllerBase
    {
        private readonly IDepart oItem;
        public DepartController(IDepart xxx)
        {
            oItem = xxx;
        }
        [HttpGet]
        public async Task<List<ClassDepart>> GetDepart()
        {
            return await oItem.GetDepart();
        }

        [HttpGet("{id}")]
        public async Task<List<ClassDepart>> GetDepartByMatricule(string id)
        {
            return await oItem.GetDepartByMatricule(id);
        }



        [HttpPost]
        public async Task<Resultat> Post([FromBody] ClassDepart item)
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
        public async Task<Resultat> ValiderDepart([FromBody] ParamValidDepart param)
        {
            if (ModelState.IsValid)
            {
                return await oItem.ValiderDepart(param);
            }
            else
            {
                return null;
            }

        }
    }
}
