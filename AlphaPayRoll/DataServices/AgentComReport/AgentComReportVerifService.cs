using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static PayAPI.RepServices.AgentComListPrimeVerifService;

namespace AlphaPayRoll.DataServices.AgentComReport
{
	public class AgentComReportVerifService : IAgentComListPrimeVerifService
    {
        private readonly HttpClient ohttpClient;

        public AgentComReportVerifService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }

        public async Task<byte[]> GenerateListPrimeVerifAsync(string reportName, string reportType)
        {
            return (await ohttpClient.GetByteArrayAsync($"api/AgentComListPrimeVerif/{reportName}/{reportType}"));
        }



    }
}
