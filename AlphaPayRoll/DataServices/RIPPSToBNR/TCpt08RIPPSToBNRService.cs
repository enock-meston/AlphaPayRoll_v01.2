using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.RIPPSToBNR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.RIPPSToBNR
{
    public class TCpt08RIPPSToBNRService : ITCpt08RIPPSToBNR
    {
        private readonly HttpClient oHttpClient;

        public TCpt08RIPPSToBNRService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }


        public async Task<Resultat> GetResutUpdate(TCpt08RIPPSToBNR item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TCpt08RIPPSToBNR/", item);
        }

        public async Task<List<TCpt08RIPPSToBNR>> GetRIPPSToBNR()
        {
            return (await oHttpClient.GetJsonAsync<TCpt08RIPPSToBNR[]>($"api/TVeh99Rapport/")).ToList();
        }
    }
}
