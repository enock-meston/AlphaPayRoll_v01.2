using Microsoft.AspNetCore.Components;
using PayLibrary.Exercice;
using PayLibrary.ParamSec;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.Exercice
{
    public class ExerciceService: ITSL550Exercice
    {

        private readonly HttpClient oHttpClient;
        public ExerciceService(HttpClient httpClient)
        {

            oHttpClient = httpClient;
        }

        public async Task<List<TSL550Exercice>> GetExerciceAll()
        {
            return (await oHttpClient.GetJsonAsync<TSL550Exercice[]>($"api/Exercice/")).ToList();
        }
    }
}
