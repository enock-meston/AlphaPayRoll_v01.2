using AlphaPayRoll.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.General;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec;
using PayLibrary.TCt550TpTransTout;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AlphaPayRoll.Components.Pages.DonBase
{
    public class TCt550TpTransToutBase : ComponentBase
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        public ClasSessionStorage osessionService { set; get; }

        [Inject]
        protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }

        [Inject]
        protected ITCt550TpTransTout oTCt550TpTransToutService { set; get; }
        public List<TCt550TpTransTout> oTCt550TpTransToutList { set; get; }

        public List<TSc551User> oTCl550UserList { set; get; }
        [Inject]
        protected ITSc551User oTCl550UserService { set; get; }
        

        public TCt550TpTransTout oOneTCt550TpTransTout { set; get; }
        public bool isLoading { set; get; } = true;

       
        public DateTime? CreatOn { get; set; }
        public int LModifBy { get; set; }
        public DateTime? LModifOn { get; set; }
        public int TpJournalID { get; set; }
        public decimal TxRetrait { get; set; }
        public int RoleValidation { get; set; }


        public string getRowColor(int i)
        {
            return (i % 2 == 0) ? "table-info" : "table-light";
        }



        protected bool popup = false;


        public string StyleButton { set; get; }
        public string ButtonCaption { set; get; }

        public string modalTitle { set; get; }

        public int iTypeAction { set; get; }

        public bool bValidation { set; get; } = false;

        protected void ShowPopUp(int tPAction)
        {


            if (tPAction == 0)
            {
                modalTitle = "Transaction Detail";
            }
            if (tPAction == 2)
            {
                modalTitle = "Modifier Transaction";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Save";

            }
            else if (tPAction == 3)
            {
                modalTitle = "Supprimer Transaction";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";


            }
            if (tPAction == 1)
            {

                modalTitle = "New Transaction";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Save";
                iTypeAction = tPAction;
                oOneTCt550TpTransTout = new TCt550TpTransTout();

                oOneTCt550TpTransTout.CreatBy = int.Parse(osessionService.UserId);
                oOneTCt550TpTransTout.CreatOn = DateTime.Now;
                oOneTCt550TpTransTout.LModifOn = DateTime.Now;
            }
          
            popup = true;
        }
        protected void ClosePopUp()
        {
            popup = false;
            bValidation = false;
        }
        protected async Task EditData(TCt550TpTransTout item, int TpAction)
        {


            iTypeAction = TpAction;
            oOneTCt550TpTransTout = item;
            ShowPopUp(iTypeAction);

        }
        Resultat oResultat = new Resultat();



        protected async Task SaveDocVal(TCt550TpTransTout model)
        {
            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment supprimer " + model.Descript + "?"))
                    return;
            }

            try
            {
                oOneTCt550TpTransTout.TpMaj = iTypeAction;
                oResultat = await oTCt550TpTransToutService.GetUpdateResult(model);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
                oTCl550UserList = await oTCl550UserService.GetList();
                if (oResultat.Result.Trim().Length < 30)
                {
                    ClosePopUp();
                    StateHasChanged();
                }
            }
            catch (Exception ex)
            {
                await JSRuntime.InvokeVoidAsync("alert", ex.Message);
            }
            finally
            {
                isLoading = false;
            }



        }
        protected override async Task OnInitializedAsync()
        {
            osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");
            try
            {
                oTCt550TpTransToutList = await oTCt550TpTransToutService.GetAllTrans();
                oTCl550UserList = await oTCl550UserService.GetList();
            }
            catch (Exception ex)
            {
                await JSRuntime.InvokeVoidAsync("alert", ex.Message);
            }
            finally
            {
                isLoading = false;
            }

        }
    }
}


