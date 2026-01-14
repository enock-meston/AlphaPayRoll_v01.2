using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL02AgDimAugmSal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.TSL02AgDimAugmSal
{
    public class TSL02AgDimAugmSalService : ITSL02AgDimAugmSal
    {
        //Install-Package Microsoft.AspNetCore.Blazor.HttpClient -Version 3.2.0-preview3.20168.3
        private readonly HttpClient ohttpClient;

        public TSL02AgDimAugmSalService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }

        public async Task<List<ClassTSL02AgDimAugmSal>> GetTSL02AgDimAugmSal()
        {
            return (await ohttpClient.GetJsonAsync<ClassTSL02AgDimAugmSal[]>($"api/TSL02AgDimAugmSal/")).ToList();
        }

        public async Task<List<ClassTSL02AgDimAugmSal>> GetTSL02AgDimAugmSalByAgent(int id)
        {
            return (await ohttpClient.GetJsonAsync<ClassTSL02AgDimAugmSal[]>($"api/TSL02AgDimAugmSal/{id}")).ToList();
        }

        public async Task<Resultat> GetUpdateResult(ClassTSL02AgDimAugmSal item)
        {
            return await ohttpClient.PostJsonAsync<Resultat>($"api/TSL02AgDimAugmSal/", item);
        }
    }
}
