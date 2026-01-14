
using Microsoft.AspNetCore.Components;
using PayLibrary.TrainingField;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alphabankblazor.DataServices.HumanResource
{
    public class TRH031TrainingFieldService : ITRH031TrainingField
    {
        private readonly HttpClient ohttpClient;

        public TRH031TrainingFieldService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }
        public async Task<List<TRH031TrainingField>> GetListAll()
        {
            return (await ohttpClient.GetJsonAsync<TRH031TrainingField[]>($"api/TRH031TrainingField/")).ToList();
           
        }
    }
}
