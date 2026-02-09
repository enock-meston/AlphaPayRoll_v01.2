using Microsoft.AspNetCore.Components;
using PayLibrary.Cl550Branch;
using PayLibrary.ParamDonBase.TSc551BranchAndSubBranch;

namespace AlphaPayRoll.DataServices.DonBase.TSc551BranchAndSubBranch
{
    public class TSc551SubBranchDirService : ITSc551SubBranchDir
    {
        private readonly HttpClient oHttpClient;

        public TSc551SubBranchDirService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }


        public async Task<List<TSc551SubBranchDir>> GetList()
        {
            return (await oHttpClient.GetJsonAsync<TSc551SubBranchDir[]>($"api/TSc551SubBranchDir/")).ToList();
        }
    }
}
