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
    public class SubMenuSevice : ITSc551SubMenu
    {

        private readonly HttpClient oHttpClient;

        public SubMenuSevice(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }

        public async Task<TSc551SubMenu> GetSubMenu(int id)
        {
            return await oHttpClient.GetJsonAsync<TSc551SubMenu>($"api/SubMenuOne/{id}");
        }
        public async Task<List<TSc551SubMenu>> GetListAll()
        {
            return (await oHttpClient.GetJsonAsync<TSc551SubMenu[]>($"api/SubMenu/")).ToList();
        }

        public async Task<List<TSc551SubMenu>> GetSubMenuList()
        {
            return (await oHttpClient.GetJsonAsync<TSc551SubMenu[]>($"api/SubMenu/")).ToList();
        }

        public async Task<Resultat> GetUpdateResult(TSc551SubMenu item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/SubMenu/", item);
        }

        public async Task<List<TSc551SubMenu>> GetFonctionMenu()
        {
            return (await oHttpClient.GetJsonAsync<TSc551SubMenu[]>($"api/SubMenuFonction/")).ToList();
        }
    }
}
