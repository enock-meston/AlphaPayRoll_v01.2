using Microsoft.AspNetCore.Mvc;
using PayLibrary.ReportData;

namespace PayAPI.Controllers.ReportData
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListPayRIPPSController : ControllerBase
    {
        private readonly IListPayRIPPS _listBourse;

        public ListPayRIPPSController(IListPayRIPPS listBourse)
        {
            _listBourse = listBourse;
        }

        [HttpGet]
        public async Task<List<ListPayRIPPS>> GetListPayRIPPS()
        {
            if (ModelState.IsValid)
            {
                return await _listBourse.GetListPayRIPPS();
            }
            else
            {
                return null;
            }
        }
    }
}
