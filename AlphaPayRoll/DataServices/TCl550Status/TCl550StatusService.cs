using Microsoft.AspNetCore.Components;
using PayLibrary.TCl550Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.TCl550Status
{
    public class TCl550StatusService : ITCl550Status
    {
        private readonly HttpClient oHttpClient;

        public TCl550StatusService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }


        public async Task<List<ClassTCl550Status>> GetTCl550Status()
        {
            return (await oHttpClient.GetJsonAsync<ClassTCl550Status[]>($"api/TCl550Status/")).ToList();
        }
    }
}
