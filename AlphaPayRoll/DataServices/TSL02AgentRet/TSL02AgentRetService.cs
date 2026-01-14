using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TSL02AgentRet;
using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;

namespace AlphaPayRoll.DataServices.TSL02AgentRet
{
    public class TSL02AgentRetService : ITSL02AgentRet
    {
        private readonly HttpClient oHttpClient;

        public TSL02AgentRetService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }

        public async Task<List<ClassTSL02AgentRet>> GetTSL02AgentRet()
        {
            return (await oHttpClient.GetJsonAsync<ClassTSL02AgentRet[]>($"api/TSL02AgentRet/")).ToList();
        }


        public async Task<Resultat> GetResutUpdate(ClassTSL02AgentRet item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TSL02AgentRet/", item);
        }

       
    }
}

