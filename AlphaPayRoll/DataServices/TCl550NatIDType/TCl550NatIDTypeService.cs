using Microsoft.AspNetCore.Components;
using PayLibrary.TCl550NatIDType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.TCl550NatIDType
{
    public class TCl550NatIDTypeService: ITCl550NatIDType
    {
        private readonly HttpClient oHttpClient;

        public TCl550NatIDTypeService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }


        public async Task<List<ClassTCl550NatIDType>> GetIdType()
        {
            return (await oHttpClient.GetJsonAsync<ClassTCl550NatIDType[]>($"api/TCl550NatIDType/")).ToList();
        }
    }
}
