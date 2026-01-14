using AlphaPayRoll.DataServices.Menus;
using PayLibrary.ParamSec.ViewModel;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaPayRoll.Shared;
using PayLibrary.ParamSec;
using AlphaPayRoll.Data;
using PayLibrary.InterfParamSec;

namespace AlphaPayRoll.Components.Pages.Menu
{
    public class DBLevOnePageBase : ComponentBase
    {
        [Inject]
        protected SessionService osessionService { set; get; }
        
        [Inject]
        protected IMenuAffichage oMenuAffichService { set; get; }

        protected List<MenuAffichage> oMenuAffichageList { set; get; }
        protected MenuAffichage oMenuAffichageOne { set; get; }


        public string sProfileId;
        public string sMenuDynId;

        public string getRowColor(int i)
        {
            return (i % 2 == 0) ? "table-info" : "table-light";
        }

        protected override async Task OnInitializedAsync()
        {

            if(osessionService.IsLogged)
            { 
                int longProfil;
                int longMenuID;

                //sProfileId = osessionService.UserProfile;
                sProfileId = osessionService.RoleID.ToString();
                sMenuDynId = osessionService.MenuId;

                longProfil = sProfileId.Length;
                longMenuID = sMenuDynId.Length;

                string sParam;
                //sParam = "0000000001-0000001002";
               
                sProfileId = ("0000000000" + sProfileId).Substring(longProfil, 10);
                sMenuDynId = ("0000000000" + sMenuDynId).Substring(longMenuID, 10);

                sParam = sProfileId + "-" + sMenuDynId;

                if (int.Parse(sMenuDynId) < 500)
                {
                    sParam = "000000000000000000000";
                }

                    oMenuAffichageList =await oMenuAffichService.GetMenuFonctList(sParam);
                    
            }
        }
    }


}
