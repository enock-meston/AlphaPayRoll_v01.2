using Microsoft.AspNetCore.Mvc;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.ParamSec
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangePswController : ControllerBase
    {
        private readonly IUserLogin oUserLogin;
        public ChangePswController(IUserLogin userLogin)
        {
            oUserLogin = userLogin;
        }

        [HttpPost]
        public async Task<Resultat> GetResultChangePsw(ParamChangPsw item)
        {
            return await oUserLogin.GetResultChangePsw(item);
        }




    }
}
