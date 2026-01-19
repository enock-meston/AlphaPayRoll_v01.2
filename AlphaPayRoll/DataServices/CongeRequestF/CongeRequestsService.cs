
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PayLibrary.CongeRequestF;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TRH02Agent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static MudBlazor.CategoryTypes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CongeRequest.DataService.CongeRequestF
{
    public class CongeRequestsService : ITHRCongCircRequest
    {
        private readonly HttpClient ohttpClient;
        public CongeRequestsService(HttpClient httpClient)
        {
            ohttpClient = httpClient;

        }
        public async Task<List<THRCongCircRequest>> GetAllCongeRequests()
        {
            return (await ohttpClient.GetFromJsonAsync<THRCongCircRequest[]>("api/AllCongeRequest/")).ToList();


        }

        public async Task<List<THRCongCircRequest>> GetAllCongeRequestsByMatricule(string id)
        {
            return (await ohttpClient.GetFromJsonAsync<THRCongCircRequest[]>("api/AllCongeRequest/" + id)).ToList();

        }

        //public async Task<ClassTRH02Agent> GetAllCongeRequestsByMatriculeXX(ParamAgentMatricule param)
        //{
        //    return await ohttpClient.PostJsonAsync<ClassTRH02Agent>($"api/AllCongeRequest/agent/", param);

        //}

        public async Task<Resultat> GetUpdateResult(THRCongCircRequest item)
        {
            return await ohttpClient.PostJsonAsync<Resultat>($"api/AllCongeRequest/", item);
        }

        public async Task<Resultat> ValideCongeRequest(ParamMatricule param, int id)
        {
            return await ohttpClient.PostJsonAsync<Resultat>($"api/AllCongeRequest/valideConge/{id}", param);
        }
    }
}

