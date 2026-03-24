using Microsoft.AspNetCore.Mvc;
using PayLibrary.ReportData;

namespace PayAPI.Controllers.ReportData
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListBourseController : ControllerBase
    {
        private readonly IListBourse _listBourse;

        public ListBourseController(IListBourse listBourse)
        {
            _listBourse = listBourse;
        }

        [HttpGet]
        public async Task<List<ListBourse>> GetListBourse()
        {
            if (ModelState.IsValid)
            {
                return await _listBourse.GetListBourse();
            }
            else
            {
                return null;
            }
        }
    }
}
