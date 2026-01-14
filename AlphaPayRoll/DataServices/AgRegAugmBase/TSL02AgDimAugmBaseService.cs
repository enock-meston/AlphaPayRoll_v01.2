using Microsoft.AspNetCore.Components;
using PayLibrary.AgRegAugmBase;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL02AgDimAugmSal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.TSL02AgDimAugmSal
{
    public class TSL02AgDimAugmBaseService : ITSL02AgRetPayment
    {
        //Install-Package Microsoft.AspNetCore.Blazor.HttpClient -Version 3.2.0-preview3.20168.3
        private readonly HttpClient ohttpClient;

        public TSL02AgDimAugmBaseService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }

        public async Task<List<TSL02AgRetPayment>> GetTSL02AgRetAugmBase()
        {
            return (await ohttpClient.GetJsonAsync<TSL02AgRetPayment[]>($"api/TSL02AgRetAugmBase/")).ToList();
        }

        public async Task<List<TSL02AgRetPayment>> GetTSL02AgRetAugmBaseByAgent(int id)
        {
            return (await ohttpClient.GetJsonAsync<TSL02AgRetPayment[]>($"api/TSL02AgRetAugmBase/{id}")).ToList();
        }

        public async Task<List<TSL02AgRetPayment>> GetTSL02AgRetAugmBaseByType(int id)
        {
            return (await ohttpClient.GetJsonAsync<TSL02AgRetPayment[]>($"api/TSL02AgRetAugmBaseType/{id}")).ToList();
        }

        public async Task<Resultat> GetUpdateResult(TSL02AgRetPayment item)
        {
            return await ohttpClient.PostJsonAsync<Resultat>($"api/TSL02AgRetAugmBase/", item);
        }
    }
}
