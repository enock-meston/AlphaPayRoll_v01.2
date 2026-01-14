
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.JSInterop;
using System.Globalization;
using AlphaPayRoll.Data;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;

namespace AlphaPayRoll.Components.Pages.Login
{
    public class ChangePswPageBase : ComponentBase
    {


        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected IUserLogin oUserLoginService { set; get; }

        [Inject]
        public NavigationManager NavManager { set; get; }
        public UserLoginDon oUserLogin { set; get; }

        public ClasSessionStorage osessionService { set; get; }

        [Inject]
        protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }




        protected bool popUpModal = true;
        public bool popUpUserInfo = false;
        protected bool AfficherMenu = false;


        
        protected void ShowPopUpModal()
        {
            popUpModal = true;
        }

        protected void ClosePopUpModal()
        {
            osessionService.AfficherLogin=true;
			osessionService.IsLogged=false;
			popUpModal = false;
            //NavManager.NavigateTo("/");
            NavManager.NavigateTo(osessionService.sApp);
        }





        public bool isLogged { set; get; }


        public string NewPsw { set; get; }
        public string ConfirmNewPsw { set; get; }
        
        public string OldPsw { set; get; }


        public async Task ChangePsw()
        {
            Resultat oResult = new Resultat();
            ParamChangPsw oChangeP = new ParamChangPsw();
            oChangeP.NewPsw = NewPsw;
            oChangeP.OldPsw = OldPsw;
            oChangeP.UserID = int.Parse(osessionService.UserId);
            try
            {
                oResult = await oUserLoginService.GetResultChangePsw(oChangeP);
                await JSRuntime.InvokeVoidAsync("alert", oResult.Result);

                osessionService.VraiID = 0;
                osessionService.ClientID = 0;
                osessionService.RoleID = 0;
                osessionService.CashAcctID = 0;
                osessionService.Reponse = "Click on Login button  for connection";
                osessionService.DateJour = DateTime.Today;
                osessionService.JournalName = "";
                osessionService.Branch = "";
                osessionService.IsLogged = false;
                osessionService.UserProfile = "";
                osessionService.UserId = "";
                osessionService.UserName = "";
                osessionService.BranchID = "";
                osessionService.MenuId = "0";
                osessionService.MenuSecId = "0";
                osessionService.MenuName = "";
                osessionService.MenuSecName = "";
                osessionService.DivMessage = "";
                osessionService.CustomerNames = "";
                osessionService.DataChanged = false;
                osessionService.ContratID = 0;
                osessionService.DernSouscriptID = 0;

                popUpModal = false;
				osessionService.AfficherLogin = true;
				//NavManager.NavigateTo("/");
				NavManager.NavigateTo(osessionService.sApp+"/");


            }
                    
            catch(Exception ex)
            {
                await JSRuntime.InvokeVoidAsync("alert", ex.Message);
            }


        }





        protected override async Task OnInitializedAsync()
        {
            //isLogged = false;

            osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");

            oUserLogin = new UserLoginDon();
            popUpModal = true;

        }



    }
}

