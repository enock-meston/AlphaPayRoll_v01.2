using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Permission;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alphabankblazor.DataServices.HumanResource
{
    public class TRH05PermissionService : ITRH05Permission
    {
        private readonly HttpClient ohttpClient;

        public TRH05PermissionService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }
        public async Task<List<TRH05Permission>> GetList(string id)
        {
            return (await ohttpClient.GetJsonAsync<TRH05Permission[]>($"api/TRH05Permission/{id}")).ToList();
        }

        public async Task<List<TRH05Permission>> GetListAll()
        {
            return (await ohttpClient.GetJsonAsync<TRH05Permission[]>($"api/TRH05Permission/")).ToList();
        }

        public async Task<Resultat> GetUpdateResult(TRH05Permission item)
        {
            return await ohttpClient.PostJsonAsync<Resultat>($"api/TRH05Permission/", item);
        }
    }
}
