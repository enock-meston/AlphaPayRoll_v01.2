using Microsoft.AspNetCore.Mvc;
using PayLibrary.ReportData;

namespace PayAPI.Controllers.ReportData
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListPrimeLifeController : ControllerBase
    {
        private readonly IListPrimeLife _listPrimeLife;

        public ListPrimeLifeController(IListPrimeLife listPrimeLife)
        {
            _listPrimeLife = listPrimeLife;
        }

        [HttpGet]
        public async Task<List<ListPrimeLife>> GetListPrimeLife()
        {
            if (ModelState.IsValid)
            {
                return await _listPrimeLife.GetListPrimeLife();
            }
            else
            {
                return null;
            }
        }
    }
}
