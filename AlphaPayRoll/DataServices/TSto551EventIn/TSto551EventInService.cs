using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TSto551EventIn;
using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;

namespace AlphaPayRoll.DataServices.TSto551EventIn
{
    public class TSto551EventInService : ITSto551EventIn
    {

        private readonly HttpClient oHttpClient;

        public TSto551EventInService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }



        public async Task<List<ClassTSto551EventIn>> GetTSto551EventIn()
        {
            return (await oHttpClient.GetJsonAsync<ClassTSto551EventIn[]>($"api/TSto551EventIn/")).ToList();
        }


        public async Task<Resultat> GetResutUpdate(ClassTSto551EventIn item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TSto551EventIn/", item);
        }

       
    }
}

