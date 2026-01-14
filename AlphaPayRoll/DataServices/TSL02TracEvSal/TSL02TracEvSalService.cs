using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL02TracEvSal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.TSL02TracEvSal
{
    public class TSL02TracEvSalService : ITSL02TracEvSal
    {
        //Install-Package Microsoft.AspNetCore.Blazor.HttpClient -Version 3.2.0-preview3.20168.3
        private readonly HttpClient ohttpClient;

        public TSL02TracEvSalService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }

        public async Task<List<ClassTSL02TracEvSal>> GetTSL02TracEvSal()
        {
            return (await ohttpClient.GetJsonAsync<ClassTSL02TracEvSal[]>($"api/TSL02TracEvSal/")).ToList();
        }

        public async Task<Resultat> GetUpdateResult(ClassTSL02TracEvSal item)
        {
            return await ohttpClient.PostJsonAsync<Resultat>($"api/TSL02TracEvSal/", item);
        }
    }
}
