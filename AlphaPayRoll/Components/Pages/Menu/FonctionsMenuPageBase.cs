using AlphaPayRoll.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaPayRoll.Components.Pages.Menu
{
    public class FonctionsMenuPageBase:ComponentBase
    {


        [Inject]
        protected SessionService osessionService { set; get; }

        [Inject]
        protected ITSc551SubMenu oSubMenuService { set; get; }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        protected List<TSc551SubMenu> oSubMenuList { set; get; }
        protected TSc551SubMenu oSubMenuOne { set; get; }

        [Parameter]
        public string id { get; set; }  
 
        public string sProfileId;
        public string sMenuDynId;

        public string sParam { set; get; }
        public bool isLoading { set; get; } = false;


        public string getRowColor(int i)
        {
            return (i % 2 == 0) ? "table-info" : "table-light";
        }


        public string MenuDescript { set; get; }


        public void NomMenu(TSc551SubMenu item)
        {
            string MenuSecondaire = item.Descript;

            osessionService.MenuSecName = item.Descript;
            osessionService.MenuSecId = item.ID.ToString();
        }

        protected override async Task OnInitializedAsync()
        {
            isLoading = true;
            if (osessionService.IsLogged)
            {
 
                oSubMenuList = await oSubMenuService.GetFonctionMenu();



                if (oSubMenuList.Count > 0)
                {
                    if (id== "Salaire")
                    {
                        oSubMenuList=oSubMenuList.Where(row=>row.CodeModule== "1").ToList();

                    }
                    osessionService.MenuSecName = oSubMenuList[0].Descript;
                    osessionService.MenuSecId = oSubMenuList[0].ID.ToString();
                }


                isLoading = false;

            }
        }



    }
}

