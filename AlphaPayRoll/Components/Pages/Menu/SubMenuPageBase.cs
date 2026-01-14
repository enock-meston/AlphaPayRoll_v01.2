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
using Microsoft.JSInterop;
using PayLibrary.InterfParamSec;

namespace AlphaPayRoll.Components.Pages.Menu
{
    public class SubMenuPageBase:ComponentBase
    {
        [Inject]
        protected SessionService osessionService { set; get; }

        [Inject]
        protected ITSc551SubMenu oSubMenuService { set; get; }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        protected List<TSc551SubMenu> oSubMenuList { set; get; }
        protected TSc551SubMenu oSubMenuOne { set; get; }

        //[Inject]
        //protected ITransECparJournal oTransService { set; get; }




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

        public void CentraliserAsync()
        {

            //isLoading = true;

            //if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment centraliser les transactions ?"))
            //    return;
           
            //Resultat oResult = new Resultat();
            //try
            //{
            //    oResult = await oTransService.GetResultCentralis();
            //    isLoading = false;
            //    await JSRuntime.InvokeVoidAsync("alert", oResult.Result);
                
            //}
            //catch (Exception x)
            //{
            //    isLoading = false;
            //    await JSRuntime.InvokeVoidAsync("alert", x.Message);
            //}
            //finally
            //{
                
            //}



        }
        protected override async Task OnInitializedAsync()
            {
                isLoading = true;
                if (osessionService.IsLogged)
                {
                    //int longProfil;
                    //int longMenuID;

                    //sProfileId = osessionService.RoleID.ToString();
                    //sMenuDynId = osessionService.MenuId;

                    //longProfil = sProfileId.Length;
                    //longMenuID = sMenuDynId.Length;

                
                    //sParam = "0000000001-0000001002";

                    //sProfileId = ("0000000000"+ sProfileId).Substring(longProfil, 10);
                    //sMenuDynId = ("0000000000"+ sMenuDynId).Substring(longMenuID, 10);

                    //sParam = sProfileId + "-" + sMenuDynId;

   

                    oSubMenuList = await oSubMenuService.GetSubMenuList();

                if (oSubMenuList.Count > 0)
                {
                    osessionService.MenuSecName = oSubMenuList[0].Descript;
                    osessionService.MenuSecId = oSubMenuList[0].ID.ToString();
                }
                    

                isLoading = false;

                }
            }



    }
}

