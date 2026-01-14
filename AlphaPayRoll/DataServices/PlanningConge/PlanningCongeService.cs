
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.PlanningConge;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace HRProject.DataService.PlanningCongeFord
{
    public class PlanningCongeService : ITHRPlanningConge
    {
        private readonly HttpClient ohttpClient;
        public PlanningCongeService(HttpClient httpClient)
        {
            ohttpClient = httpClient;

        }

        public async Task<List<THRPlanningConge>> GetAllPlanningConge()
        {
            return (await ohttpClient.GetJsonAsync<THRPlanningConge[]>("api/PlanningConge/")).ToList();
        }

        

        public async Task<List<THRPlanningConge>> GetPlanningCongeByMatricule(string id)
        {
            return (await ohttpClient.GetFromJsonAsync<THRPlanningConge[]>($"api/PlanningConge/Matricule/{id}")).ToList();

        }

        public async Task<List<THRPlanningConge>> GetPlanningCongeBySBranch(int SBranch)
        {
            return (await ohttpClient.GetFromJsonAsync<THRPlanningConge[]>($"api/PlanningConge/SBranch/{SBranch}")).ToList();

        }

        public async Task<Resultat> UpdatePlanningConge(THRPlanningConge item)
        {
            return await ohttpClient.PostJsonAsync<Resultat>($"api/PlanningConge/", item);
        }

        public async Task<Resultat> GetNumTranche(ParamNumTranche item)
        {
            return await ohttpClient.PostJsonAsync<Resultat>($"api/PlanningConge/NumTranche/", item);
        }

        //public async Task<Resultat> InsertPlanningConge(PlanningConge item)
        //{
        //    return await ohttpClient.PostAsJsonAsync($"api/PlanningConge/Insert", item)
        //                             .Result.Content.ReadFromJsonAsync<Resultat>();
        //}
    }
}
