using Microsoft.AspNetCore.Mvc;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PayAPI.Controllers.ParamSec
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLogin oUserLogin;
        public UserLoginController(IUserLogin userLogin)
        {
            oUserLogin = userLogin;
        }

        [HttpPost]

        public async Task<UserLoginDon> Post([FromBody] UserLoginParam oUserLoginParam)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return await oUserLogin.GetAuthentication(oUserLoginParam);
                }
                catch (Exception ex)
                {
                    UserLoginDon oUser = new UserLoginDon();
                    oUser.Reponse = ex.Message;
                    return oUser;
                }

            }
            else
            {
                return null;
            }

        }


        //public async Task<UserLoginDon> GetAuthentication(UserLoginParam oUserLoginParam)
        //{
        //    return await oUserLogin.GetAuthentication(oUserLoginParam);
        //}




    }
}
