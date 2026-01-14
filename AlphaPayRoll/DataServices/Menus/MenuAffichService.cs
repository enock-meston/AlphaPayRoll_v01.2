using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec.ViewModel;


namespace AlphaPayRoll.DataServices.Menus
{
    public class MenuAffichService : IMenuAffichage
    {

        private readonly HttpClient oHttpClient;

        public MenuAffichService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }

        //public async Task<List<MenuAffichage>> GetFonctionMenu()
        //{
        //    return (await oHttpClient.GetJsonAsync<MenuAffichage[]>($"api/MenuAffichageList/")).ToList();
        //}

        public async Task<List<MenuAffichage>> GetMenuFonctList(string id)
        {
            return (await oHttpClient.GetJsonAsync<MenuAffichage[]>($"api/MenuAffichageList/{id}")).ToList();
        }

        public async Task<MenuAffichage> GetMenuFonctOne(int id)
        {
            return await oHttpClient.GetJsonAsync<MenuAffichage>($"api/MenuAffichageOne/{id}");
        }
    }
}
