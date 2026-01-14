using Microsoft.AspNetCore.Mvc;
using PayLibrary.AgRegAugmBase;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.AgRegAugmBase
{
    [Route("api/[controller]")]
    [ApiController]
    public class TSL02AgRetCotisTypeController : ControllerBase
    {
        private readonly ITSL02AgRetCotis oImplement;
        public TSL02AgRetCotisTypeController(ITSL02AgRetCotis implement)
        {
            this.oImplement = implement;
        }
        [HttpGet]
        public async Task<List<TSL02AgRetCotis>> GetTSL02AgRetCotis()
        {
            return await oImplement.GetTSL02AgRetCotis();
        }
        [HttpGet("{id}")]
        public async Task<List<TSL02AgRetCotis>> GetTSL02AgRetCotisByType(int id)
        {
            return await oImplement.GetTSL02AgRetCotisByType(id);
        }

        [HttpPost]
        public async Task<Resultat> GetUpdateResult([FromBody] TSL02AgRetCotis item)
        {
            if (ModelState.IsValid)
            {
                return await oImplement.GetUpdateResult(item);
            }
            else
            {
                return null;
            }

        }
    }
}

