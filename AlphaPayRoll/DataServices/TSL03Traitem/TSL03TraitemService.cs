using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TSL03Traitem;
using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;

namespace AlphaPayRoll.DataServices.TSL03Traitem
{
    public class TSL03TraitemService : ITSL03Traitem
    {

        private readonly HttpClient oHttpClient;

        public TSL03TraitemService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }


        public async Task<List<ClassTSL03Traitem>> GetTSL03Traitem()
        {
            return (await oHttpClient.GetJsonAsync<ClassTSL03Traitem[]>($"api/TSL03Traitem/")).ToList();
        }

        public async Task<List<ClassTSL03Traitem>> GetTSL03TraitemByAgent(int id)
        {
            return (await oHttpClient.GetJsonAsync<ClassTSL03Traitem[]>($"api/TSL03Traitem/{id}")).ToList();
        }


        public async Task<Resultat> GetResutUpdate(ClassTSL03Traitem item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TSL03Traitem/", item);
        }


    }
}

