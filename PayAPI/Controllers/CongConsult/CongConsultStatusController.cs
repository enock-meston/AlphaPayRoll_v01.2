using Microsoft.AspNetCore.Mvc;
using PayLibrary.CongCircRequest;
using PayLibrary.CongConsult;
using PayLibrary.CongeRequestF;

namespace PayAPI.Controllers.CongConsult
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongConsultStatusController
    {
        private readonly ICongConsultStatus _congeStatus;

        public CongConsultStatusController(ICongConsultStatus congeStatus)
        {
            _congeStatus = congeStatus;
        }

        [HttpPost]
        public async Task<List<CongConsultStatus>> GetAllCongeConsultStatus([FromBody] ParamConsultConge param)
        {
            return await _congeStatus.GetAllCongeConsultStatus(param);
        }
    }
}
