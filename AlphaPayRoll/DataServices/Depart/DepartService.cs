using Microsoft.AspNetCore.Components;
using PayLibrary.Depart;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.Depart
{
    public class DepartService : IDepart
    {
        private readonly HttpClient oHttpClient;

        public DepartService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }
        public async Task<List<ClassDepart>> GetDepart()
        {
            return (await oHttpClient.GetJsonAsync<ClassDepart[]>($"api/Depart/")).ToList();
        }

        public async Task<List<ClassDepart>> GetDepartByMatricule(string id)
        {
            return (await oHttpClient.GetJsonAsync<ClassDepart[]>($"api/Depart/{id}")).ToList();
        }


        public async Task<Resultat> GetResutUpdate(ClassDepart item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/Depart/", item);
        }

        public async Task<Resultat> ValiderDepart(ParamValidDepart param)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/Depart/validate/", param);

        }
    }
}
