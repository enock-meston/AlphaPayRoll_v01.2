using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL550TpDimAugSal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.TSL550TpDimAugSal
{
    public class TSL550TpDimAugSalService : ITSL550TpDimAugSal
    {
              //Install-Package Microsoft.AspNetCore.Blazor.HttpClient -Version 3.2.0-preview3.20168.3
            private readonly HttpClient ohttpClient;

            public TSL550TpDimAugSalService(HttpClient httpC)
            {
                ohttpClient = httpC;
            }

            public async Task<List<ClassTSL550TpDimAugSal>> GetTSL550TpDimAugSal()
            {
                return (await ohttpClient.GetJsonAsync<ClassTSL550TpDimAugSal[]>($"api/TSL550TpDimAugSal/")).ToList();
            }

            public async Task<Resultat> GetUpdateResult(ClassTSL550TpDimAugSal item)
            {
                return await ohttpClient.PostJsonAsync<Resultat>($"api/TSL550TpDimAugSal/", item);
            }
    }
}