
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.ReportSalaire
{
    public class ListePayByBranchService : IListPayByBranchService
    {

        private readonly HttpClient ohttpClient;

        public ListePayByBranchService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }

        public async Task<byte[]> GenerateRepListPayAsync(string reportName, string reportType, string BrancLocID)
        {
            return (await ohttpClient.GetByteArrayAsync($"api/ListPayByBranch/{reportName}/{reportType}/{BrancLocID}"));
        }


    }
}
