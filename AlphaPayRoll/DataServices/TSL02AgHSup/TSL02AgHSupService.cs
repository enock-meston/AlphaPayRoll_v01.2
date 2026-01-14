using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL02AgHSup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.TSL02AgHSup
{
    public class TSL02AgHSupService : ITSL02AgHSup
    {
        //Install-Package Microsoft.AspNetCore.Blazor.HttpClient -Version 3.2.0-preview3.20168.3
        private readonly HttpClient ohttpClient;

        public TSL02AgHSupService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }

        public async Task<List<ClassTSL02AgHSup>> GetTSL02AgHSup()
        {
            return (await ohttpClient.GetJsonAsync<ClassTSL02AgHSup[]>($"api/TSL02AgHSup/")).ToList();
        }

        public async Task<List<ClassTSL02AgHSup>> GetTSL02AgHSupByAgent(int id)
        {
            return (await ohttpClient.GetJsonAsync<ClassTSL02AgHSup[]>($"api/TSL02AgHSup/{id}")).ToList();
        }

        public async Task<Resultat> GetUpdateResult(ClassTSL02AgHSup item)
        {
            return await ohttpClient.PostJsonAsync<Resultat>($"api/TSL02AgHSup/", item);
        }
    }
}
