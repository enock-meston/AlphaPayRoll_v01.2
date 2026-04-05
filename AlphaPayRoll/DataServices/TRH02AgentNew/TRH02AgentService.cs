using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TRH02AgentNew;
using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;

namespace AlphaPayRoll.DataServices.TRH02AgentNew
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
            return (await oHttpClient.GetJsonAsync<ClassTRH02Agent[]>($"api/TRH02AgentNew/")).ToList();
        }

        public async  Task<List<ClassTRH02Agent>> GetAgentByMatricule(string id)
        {
            return (await oHttpClient.GetJsonAsync<ClassTRH02Agent[]>($"api/TRH02AgentNew/TRH02AgentByMatricule/{id}")).ToList();

        }

        public async Task<List<ClassTRH02Agent>> GetAgentRech(string id)
		{
			return (await oHttpClient.GetJsonAsync<ClassTRH02Agent[]>($"api/TRH02AgentNew/{id}")).ToList();
		}

        public Task<Resultat> GetCalculerSalaire(ClassTRH02Agent item)
        {
            throw new NotImplementedException();
        }

        public async Task<Resultat> GetResutMajSalaire(ClassTRH02Agent item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TRH02AgentNew/MajDonSalaire/", item);
        }

        public async  Task<Resultat> GetResutUpdate(ClassTRH02Agent item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TRH02AgentNew/", item);
        }

        public async Task<Resultat> GetUpdateDon(ClasParamMajDon item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TRH02AgentNew/MajDonAgent/", item);
            
        }

       
    }
}

