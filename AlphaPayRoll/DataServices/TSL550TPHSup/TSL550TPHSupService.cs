using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL550TPHSup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.TSL550TPHSup
{
    public class TSL550TPHSupService : ITSL550TPHSup
    {
        //Install-Package Microsoft.AspNetCore.Blazor.HttpClient -Version 3.2.0-preview3.20168.3
        private readonly HttpClient ohttpClient;

        public TSL550TPHSupService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }

        public async Task<List<ClassTSL550TPHSup>> GetTSL550TPHSup()
        {
            return (await ohttpClient.GetJsonAsync<ClassTSL550TPHSup[]>($"api/TSL550TPHSup/")).ToList();
        }

        public async Task<Resultat> GetUpdateResult(ClassTSL550TPHSup item)
        {
            return await ohttpClient.PostJsonAsync<Resultat>($"api/TSL550TPHSup/", item);
        }
    }
}
