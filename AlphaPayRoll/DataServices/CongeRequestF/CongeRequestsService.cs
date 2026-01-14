
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
using PayLibrary.TRH02Agent;

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

  
        


    }
}

