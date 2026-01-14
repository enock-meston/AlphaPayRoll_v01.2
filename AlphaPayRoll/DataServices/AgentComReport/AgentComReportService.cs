using Microsoft.AspNetCore.Components;
using PayLibrary.AgRegAugmBase;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static PayAPI.RepServices.AgentComListPrimeService;

namespace AlphaPayRoll.DataServices.AgentComReport
{
    public class AgentComReportService: IAgentComListPrimeService
    {
        private readonly HttpClient ohttpClient;

        public AgentComReportService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }

        public async Task<byte[]> GenerateListPrimeAsync(string reportName, string reportType)
        {
            return (await ohttpClient.GetByteArrayAsync($"api/AgentComListPrime/{reportName}/{reportType}"));
        }

 

    }
}
