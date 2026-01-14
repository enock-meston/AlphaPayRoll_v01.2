

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
    public class TSc550RoleService : ITSc550Role
    {

        private readonly HttpClient oHttpClient;

        public TSc550RoleService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }

        public async Task<Resultat> GetUpdateResult(TSc550Role item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/Role/", item);
        }

        public async Task<List<TSc550Role>> GetList(int id)
        {
            return (await oHttpClient.GetJsonAsync<TSc550Role[]>($"api/Role/{id}")).ToList();
        }
    }
}
