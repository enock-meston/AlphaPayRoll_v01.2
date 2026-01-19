using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TRH02Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static MudBlazor.CategoryTypes;

namespace AlphaPayRoll.DataServices.TRH02Agent
{
	public class TRH02AgentService : ITRH02Agent
	{
		private readonly HttpClient oHttpClient;

		public TRH02AgentService(HttpClient httpClient)
		{
			oHttpClient = httpClient;
		}

		public async Task<List<ClassTRH02Agent>> GetAgent()
		{
			return (await oHttpClient.GetJsonAsync<ClassTRH02Agent[]>($"api/TRH02Agent/")).ToList();
		}

		public async  Task<List<ClassTRH02Agent>> GetAgentByMatricule(string id)
		{
			return (await oHttpClient.GetJsonAsync<ClassTRH02Agent[]>($"api/TRH02AgentByMatricule/{id}")).ToList();

		}

		public async Task<List<ClassTRH02Agent>> GetAgentByMatriculeCongeReq(ParamAgentMatricule param)
		{
			return await oHttpClient.PostJsonAsync<List<ClassTRH02Agent>>($"api/TRH02AgentByMatricule/",param);
		}

		public async Task<List<ClassTRH02Agent>> GetAgentByMatriculeXX(ParamAgentMatricule param)
		{
			return await oHttpClient.PostJsonAsync< List<ClassTRH02Agent>>($"api/GetAgentByMatriculeUser/", param);

		}
        public async Task<List<ClassTRH02Agent>> GetAgentByChef(ParamAgentByChef param) // get agent by CHEF			
        {
            return await oHttpClient.PostJsonAsync<List<ClassTRH02Agent>>($"api/TRH02Agent/AgentByChef/", param);

        }

        public async Task<List<ClassTRH02Agent>> GetAgentBySubBranch(string id)
		{
			return (await oHttpClient.GetJsonAsync<ClassTRH02Agent[]>($"api/TRH02Agent/subBranch/{id}")).ToList();

		}

		public async Task<List<ClassTRH02Agent>> GetAgentRech(string id)
		{
			return (await oHttpClient.GetJsonAsync<ClassTRH02Agent[]>($"api/TRH02Agent/{id}")).ToList();
		}

		public Task<Resultat> GetCalculerSalaire(ClassTRH02Agent item)
		{
			throw new NotImplementedException();
		}

		public async Task<Resultat> GetResutMajSalaire(ClassTRH02Agent item)
		{
			return await oHttpClient.PostJsonAsync<Resultat>($"api/MajDonSalaire/", item);
		}

		public async  Task<Resultat> GetResutUpdate(ClassTRH02Agent item)
		{
			return await oHttpClient.PostJsonAsync<Resultat>($"api/TRH02Agent/", item);
		}

		public async Task<Resultat> GetUpdateDon(ClasParamMajDon item)
		{
			return await oHttpClient.PostJsonAsync<Resultat>($"api/MajDonAgent/", item);
			
		}

        public async Task<Resultat> ValidePlanningConge(ParamAgentMatricule param)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TRH02Agent/validePlanningConge/", param);
        }
    }
}

