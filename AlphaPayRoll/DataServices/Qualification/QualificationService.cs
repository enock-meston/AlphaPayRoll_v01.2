using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Qualification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.Qualification
{
    public class QualificationService: IQualification
    {
        private readonly HttpClient oHttpClient;

        public QualificationService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }

        public async Task<List<ClassQualification>> GetQualification()
        {
            return (await oHttpClient.GetJsonAsync<ClassQualification[]>($"api/Qualification/")).ToList();
        }

        public async Task<List<ClassQualification>> GetQualificationRech(string id)
        {
            return (await oHttpClient.GetJsonAsync<ClassQualification[]>($"api/Qualification/{id}")).ToList();
        }
        public async Task<Resultat> GetResutUpdate(ClassQualification item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/Qualification/", item);
        }

    }
}
