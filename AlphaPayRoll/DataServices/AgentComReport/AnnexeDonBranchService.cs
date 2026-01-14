using System.Net.Http;
using System.Threading.Tasks;
using static PayAPI.RepServices.AgentComBranchService;

namespace AlphaPayRoll.DataServices.AgentComReport
{
    public class AnnexeDonBranchService: IAgentComListBranchService
    {


        private readonly HttpClient ohttpClient;

        public AnnexeDonBranchService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }

        public async Task<byte[]> GenerateListBranchAsync(string reportName, string reportType, int Periode)
        {
            return (await ohttpClient.GetByteArrayAsync($"api/AgentComBranchSit/{reportName}/{reportType}/{Periode}"));
        }

 



    }
}
