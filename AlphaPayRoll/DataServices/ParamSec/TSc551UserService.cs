
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaAssurance.DataServices.ParamSec
{
    public class TSc551UserService : ITSc551User
    {

        private readonly HttpClient oHttpClient;

        public TSc551UserService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }

        public async Task<Resultat> GetUpdateResult(TSc551User item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/User/", item);
        }

        public async Task<List<TSc551User>> GetList()
        {
            return (await oHttpClient.GetJsonAsync<TSc551User[]>($"api/User/")).ToList();
        }
    }
}
