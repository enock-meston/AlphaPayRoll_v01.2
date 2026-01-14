using Microsoft.AspNetCore.Components;
using PayLibrary.GetHRCounts;
using PayLibrary.GetUserCounts;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.GetUserCounts
{
    public class ClassGetAgentCountsService : IClassGetAgentCounts
    {
        private readonly HttpClient oHttpClient;

        public ClassGetAgentCountsService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }
        public async Task<List<ClassGetAgentCounts>> GetAgentCountsAsync(string id)
        {
            var result = await oHttpClient.GetFromJsonAsync<ClassGetAgentCounts[]>($"api/ClassGetAgentCounts/{id}");
            return result?.ToList() ?? new List<ClassGetAgentCounts>();

        }
    }
}
