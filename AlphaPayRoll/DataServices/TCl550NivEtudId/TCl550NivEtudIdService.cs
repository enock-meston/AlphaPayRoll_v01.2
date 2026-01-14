using Microsoft.AspNetCore.Components;
using PayLibrary.TCl550NivEtudId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.TCl550NivEtudId
{
    public class TCl550NivEtudIdService : ITCl550NivEtudId
    {
        private readonly HttpClient oHttpClient;

        public TCl550NivEtudIdService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }


        public async Task<List<ClassTCl550NivEtudId>> GetTCl550NivEtudId()
        {
            return (await oHttpClient.GetJsonAsync<ClassTCl550NivEtudId[]>($"api/TCl550NivEtudId/")).ToList();
        }
    }
}
