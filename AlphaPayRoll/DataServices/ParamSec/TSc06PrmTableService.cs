
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
    public class TSc06PrmTableService : ITSc06PrmTable
    {

        private readonly HttpClient oHttpClient;

        public TSc06PrmTableService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }

        public async Task<Resultat> GetUpdateResult(TSc06PrmTable item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/PrmTable/", item);
        }

        public async Task<TSc06PrmTable> GetPrmTable(int id)
        {
            return (await oHttpClient.GetJsonAsync<TSc06PrmTable[]>($"api/PrmTable/{id}")).SingleOrDefault();
        }

        public async Task<List<TSc06PrmTable>> GetPrmTableList()
        {
            return (await oHttpClient.GetJsonAsync<TSc06PrmTable[]>($"api/PrmTable/")).ToList();
        }
    }
}
