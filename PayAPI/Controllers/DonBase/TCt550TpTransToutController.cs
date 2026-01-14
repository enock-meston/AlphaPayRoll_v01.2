using Microsoft.AspNetCore.Mvc;
using PayLibrary.TCt550TpTransTout;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayAPI.Controllers.DonBase
{
    [Route("api/[controller]")]
    [ApiController]
    public class TCt550TpTransToutController : ControllerBase
    {
        private readonly ITCt550TpTransTout oImplement;
        public TCt550TpTransToutController(ITCt550TpTransTout TCt550TpTransTout)
        {
            this.oImplement = TCt550TpTransTout;
        }


        [HttpGet]
        public async Task<List<TCt550TpTransTout>> GetAllTrans()
        {
            return await oImplement.GetAllTrans();
        }


        [HttpGet("{id}")]
        public async Task<List<TCt550TpTransTout>> GetTransById(int id)
        {
            return await oImplement.GetTransById(id);
        }



        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TCt550TpTransTout item)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid data" });

            var res = await oImplement.GetUpdateResult(item);

            //var res = await oImplement.GetUpdateResult(item);

            return Ok(res);
        }

    }
}
