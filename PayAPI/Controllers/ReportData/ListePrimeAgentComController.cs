using Microsoft.AspNetCore.Mvc;
using PayLibrary.ReportData;

namespace PayAPI.Controllers.ReportData
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListePrimeAgentComController : ControllerBase
    {

        private readonly IListePrimeAgentCom _listPrimeLife;

        public ListePrimeAgentComController(IListePrimeAgentCom listPrimeLife)
        {
            _listPrimeLife = listPrimeLife;
        }

        [HttpGet]
        public async Task<List<ListePrimeAgentCom>> GetListePrimeAgentCom()
        {
            if (ModelState.IsValid)
            {
                return await _listPrimeLife.GetListePrimeAgentCom();
            }
            else
            {
                return null;
            }
        }
    }
}
