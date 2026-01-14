using Microsoft.AspNetCore.Components;
using PayLibrary.CONTRACT_GOMISE;
using PayLibrary.Contrat;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static MudBlazor.CategoryTypes;

namespace AlphaPayRoll.DataServices.Contrat
{
    public class ContratService : IClasContrat
    {
        private readonly HttpClient oHttpClient;

        public ContratService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }

        //public async Task<Resultat> ContractSuspesion(ParamSuspendContract param)
        //{
        //    return await oHttpClient.PostJsonAsync<Resultat>($"api/ContratEmploye/suspending/", param);

        //}

        public async Task<List<TRH04Affectation>> GetAffectionByMatricule(string id)
        {
            return (await oHttpClient.GetJsonAsync<TRH04Affectation[]>($"api/affectation/{id}")).ToList();
        }

        public async Task<List<ClasContrat>> GetContractByMatricule(string id)
        {
            return (await oHttpClient.GetJsonAsync<ClasContrat[]>($"api/ContratEmploye/{id}")).ToList();
        }

        public async Task<Resultat> GetResutUpdate(ClasContrat item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/ContratEmploye/", item);
        }

        public async Task<Resultat> GetResutUpdateAffect(TRH04Affectation item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/Affectation/", item);
        }

        public async Task<Resultat> ValiderAffectation(ParamValidAffectation param)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/Affectation/validateAffectation/", param);

        }

        public async Task<Resultat> ValiderCotrat(ParamValidContrat param)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/ContratEmploye/validate/", param);

        }
    }
}
