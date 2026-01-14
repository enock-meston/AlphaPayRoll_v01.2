using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaAssurance.DataServices.Login
{

    public class UserLoginService:IUserLogin
    {
        private readonly HttpClient oHttpClient;

        public UserLoginService(HttpClient httpClient)
        {
            oHttpClient = httpClient;

        }
        public async Task<UserLoginDon> GetAuthentication(UserLoginParam oUserLoginParam)
        {
        
                return await oHttpClient.PostJsonAsync<UserLoginDon>($"api/UserLogin/", oUserLoginParam);
          
           
        }

        public async Task<Resultat> GetResultChangePsw(ParamChangPsw item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/ChangePsw/", item);
        }
    }
}
