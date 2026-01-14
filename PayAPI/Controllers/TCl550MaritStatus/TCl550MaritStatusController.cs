using Microsoft.AspNetCore.Mvc;
using PayLibrary.TCl550MaritStatus;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.TCl550MaritStatus
{
    [Route("api/[controller]")]
    public class TCl550MaritStatusController : ControllerBase
    {
        private readonly ITCl550MaritStatus oItem;

        public TCl550MaritStatusController(ITCl550MaritStatus xxx)
        {
            oItem = xxx;
        }


        [HttpGet]
        public async Task<List<ClassTCl550MaritStatus>> GetTCl550MaritStatus()
        {
            return await oItem.GetTCl550MaritStatus();
        }



        //[HttpPost]
        //public async Task<Resultat> Post([FromBody] ClassTCl550MaritStatus item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return await oItem.GetResutUpdate(item);
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}
    }
}

