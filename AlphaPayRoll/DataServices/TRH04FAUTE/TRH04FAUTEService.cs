using Microsoft.AspNetCore.Components;
using PayLibrary.Faute;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alphabankblazor.DataServices.HumanResource
{
    public class TRH04FAUTEService : ITRH04FAUTE
    {
        private readonly HttpClient ohttpClient;

        public TRH04FAUTEService(HttpClient httpC)
        {
            ohttpClient = httpC;
        }
        public async Task<List<TRH04FAUTE>> GetList(string id)
        {
            return (await ohttpClient.GetJsonAsync<TRH04FAUTE[]>($"api/TRH04FAUTE/{id}")).ToList();
        }

        public async Task<List<TRH04FAUTE>> GetListAll()
        {
            return (await ohttpClient.GetJsonAsync<TRH04FAUTE[]>($"api/TRH04FAUTE/")).ToList();
        }

        public async Task<Resultat> GetUpdateResult(TRH04FAUTE item)
        {
            return await ohttpClient.PostJsonAsync<Resultat>($"api/TRH04FAUTE/", item);
        }
    }
    }
