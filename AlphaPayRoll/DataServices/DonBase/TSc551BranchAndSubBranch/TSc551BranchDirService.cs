using Microsoft.AspNetCore.Components;
using PayLibrary.Cl550Branch;
using PayLibrary.ParamDonBase.TSc551BranchAndSubBranch;

namespace AlphaPayRoll.DataServices.DonBase.TSc551BranchAndSubBranch
{
    public class TSc551BranchDirService : ITSc551BranchDir
    {
        private readonly HttpClient oHttpClient;

        public TSc551BranchDirService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }


        public async Task<List<TSc551BranchDir>> GetList()
        {
            return (await oHttpClient.GetJsonAsync<TSc551BranchDir[]>($"api/TSc551BranchDir/")).ToList();
        }
    }
}
