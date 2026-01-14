using Microsoft.AspNetCore.Components;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.ParamSec
{
    public class TCl550SubBranchService : ITSc551SubBranch
    {
        private readonly HttpClient oHttpClient;

        public TCl550SubBranchService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }
        public async Task<List<TSc551SubBranch>> GetList()
        {
            return (await oHttpClient.GetJsonAsync<TSc551SubBranch[]>($"api/TSc551SubBranch/")).ToList();

        }
    }
}
