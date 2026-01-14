using Microsoft.AspNetCore.Mvc;
using PayLibrary.TxDAT;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PayAPI.Controllers.TxDAT
{
    [Route("api/[controller]")]
    [ApiController]
    public class TCpt050TxDATController : ControllerBase
    {
        private readonly ITCpt050TxDAT oImplement;
        public TCpt050TxDATController(ITCpt050TxDAT TCpt050TxDAT)
        {
            this.oImplement = TCpt050TxDAT;
        }


        [HttpGet]
        public async Task<List<TCpt050TxDAT>> GetAllData()
        {
            return await oImplement.GetAllData();
        }


        [HttpGet("{id}")]
        public async Task<List<TCpt050TxDAT>> GetDataById(int id)
        {
            return await oImplement.GetDataById(id);
        }



        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TCpt050TxDAT item)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Invalid data" });

            var res = await oImplement.GetUpdateResult(item);

            //var res = await oImplement.GetUpdateResult(item);

            return Ok(res);
        }
    }
}
