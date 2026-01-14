using Microsoft.AspNetCore.Components;
using PayLibrary.GetHRCounts;
using PayLibrary.Localisation;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.GetHRCounts
{
    public class ClassGetHRCountsService : IClassGetHRCounts
    {
        private readonly HttpClient oHttpClient;

        public ClassGetHRCountsService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }
        public async Task<List<ClassGetHRCounts>> GetHRCountsAsync()
        {
            return (await oHttpClient.GetJsonAsync<ClassGetHRCounts[]>($"api/ClassGetHRCounts")).ToList();

        }

    }
}
