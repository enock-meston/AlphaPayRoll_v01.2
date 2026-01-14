
using Microsoft.AspNetCore.Components;
using PayLibrary.IReport;
using PayLibrary.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaAssurance.DataServices.Report
{
    public class TVeh99RapportService : ITVeh99Rapport
    {
        private readonly HttpClient oHttpClient;

        public TVeh99RapportService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }
        public async Task<List<TVeh99Rapport>> GetList(string id)
        {
            return (await oHttpClient.GetJsonAsync<TVeh99Rapport[]>($"api/TVeh99Rapport/{id}")).ToList();
        }

        public async Task<List<TVeh99Rapport>> GetTout()
        {
            return (await oHttpClient.GetJsonAsync<TVeh99Rapport[]>($"api/TVeh99Rapport/")).ToList();
        }
    }
}
