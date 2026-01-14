using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;


namespace AlphaPayRoll.DataServices.Menus
{
    public class MenuDynamService : ITSc04MenuDynam
    {
        private readonly HttpClient oHttpClient;
        public MenuDynamService(HttpClient httpClient)
        {

            oHttpClient = httpClient;
        }
        //public  async Task<TSc04MenuDynam> GetMenuDynam(string Param)
        //{

        //    return await oHttpClient.GetJsonAsync<TSc04MenuDynam>("api/MenuDynamOne/{Param}");
        //}

        public async Task<List<TSc04MenuDynam>> GetMenuDynamList()
        {
           
            return (await oHttpClient.GetJsonAsync<TSc04MenuDynam[]>($"api/MenuDynam/")).ToList();
        }

        public async Task<Resultat> GetUpdateResult(TSc04MenuDynam item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/MenuDynam/", item);
        }
    }
}
