using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TSL03TraitemAv;
using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;

namespace AlphaPayRoll.DataServices.TSL03TraitemAv
{
    public class TSL03TraitemAvService : ITSL03TraitemAv
    {
        private readonly HttpClient oHttpClient;

        public TSL03TraitemAvService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }

        public async Task<List<ClassTSL03TraitemAv>> GetTSL03TraitemAv()
        {
            return (await oHttpClient.GetJsonAsync<ClassTSL03TraitemAv[]>($"api/TSL03TraitemAv/")).ToList();
        }

        public async Task<Resultat> GetResutUpdate(ClassTSL03TraitemAv item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TSL03TraitemAv/", item);
        }

       
    }
}

