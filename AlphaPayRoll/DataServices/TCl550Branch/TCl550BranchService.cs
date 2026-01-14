using Microsoft.AspNetCore.Components;
using PayLibrary.Cl550Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.TCl550Branch
{
    public class TCl550BranchService : ITCl550Branch
    {
        private readonly HttpClient oHttpClient;

        public TCl550BranchService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }


        public async Task<List<ClassTCl550Branch>> GetT550Branch()
        {
            return (await oHttpClient.GetJsonAsync<ClassTCl550Branch[]>($"api/TCl550Branch/")).ToList();
        }
    }
}




