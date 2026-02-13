
using Microsoft.AspNetCore.Components.Web;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Components;
using PayLibrary.CongeRequestF;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http.Json;
using PayLibrary.ParamSec.ViewModel;
using System.Linq;
using PayLibrary.CongCircRequest;

namespace CongeRequest.DataService.CongeRequestF
{
    public class THRCongCircRequestService : ITHRCongCircRequestNew
    {
        private readonly HttpClient ohttpClient;
        public THRCongCircRequestService(HttpClient httpClient)
        {
            ohttpClient = httpClient;

        }
        public async Task<List<THRCongCircRequestNew>> GetAllCongeCircRequests()
        {
            return (await ohttpClient.GetFromJsonAsync<THRCongCircRequestNew[]>("api/THRCongCircRequest/")).ToList();

        }
        public async Task<Resultat> GetUpdateResult(THRCongCircRequestNew item)
        {
            return await ohttpClient.PostJsonAsync<Resultat>($"api/THRCongCircRequest/", item);
           
        }

        public async Task<Resultat> ValideCongeRequest(ParamMatricule param, int id)
        {
            return await ohttpClient.PostJsonAsync<Resultat>($"api/THRCongCircRequest/valideCongeCir/{id}", param);
        }
    }
}

