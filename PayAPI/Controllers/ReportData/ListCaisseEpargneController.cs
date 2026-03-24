using Microsoft.AspNetCore.Mvc;
using PayLibrary.ReportData;

namespace PayAPI.Controllers.ReportData
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListCaisseEpargneController : ControllerBase
    {
        private readonly IListCaisseEpargne _listBourse;

        public ListCaisseEpargneController(IListCaisseEpargne listBourse)
        {
            _listBourse = listBourse;
        }

        [HttpGet]
        public async Task<List<ListCaisseEpargne>> GetListCaisseEpargne()
        {
            if (ModelState.IsValid)
            {
                return await _listBourse.GetListCaisseEpargne();
            }
            else
            {
                return null;
            }
        }
    }
}
