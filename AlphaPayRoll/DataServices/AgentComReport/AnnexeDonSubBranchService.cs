using System.Net.Http;
using System.Threading.Tasks;
using static PayAPI.RepServices.AgentComSubBranchService;

namespace AlphaPayRoll.DataServices.AgentComReport
{
    public class AnnexeDonSubBranchService : IAgentComListSubBranchService
    {
        private readonly HttpClient ohttpClient;

        public AnnexeDonSubBranchService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }
        public async Task<byte[]> GenerateListSubBranchAsync(string reportName, string reportType, int Periode)
        {
            return (await ohttpClient.GetByteArrayAsync($"api/AgentComSubBranchSit/{reportName}/{reportType}/{Periode}"));
        }
    }
}
