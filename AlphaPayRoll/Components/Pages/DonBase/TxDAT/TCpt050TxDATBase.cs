using AlphaPayRoll.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TxDAT;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AlphaPayRoll.Components.Pages.DonBase.TxDAT
{
    public class TCpt050TxDATBase : ComponentBase
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        public ClasSessionStorage osessionService { set; get; }

        [Inject]
        protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }
        [Inject]
        protected ITCpt050TxDAT oTCpt050TxDATService { set; get; }
        public List<TCpt050TxDAT> oTCpt050TxDATList { set; get; }



        public TCpt050TxDAT oOneTCpt050TxDAT { set; get; }
        public bool isLoading { set; get; } = true;


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
                modalTitle = "Tx DAT Detail";
            }
            if (tPAction == 2)
            {
                modalTitle = "Modifier Tx DAT";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Ajouter";

            }
            else if (tPAction == 3)
            {
                modalTitle = "Supprimer Tx DAT";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";


            }
            if (tPAction == 1)
            {

                modalTitle = "Tx DAT";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Save";
                iTypeAction = tPAction;
                oOneTCpt050TxDAT = new TCpt050TxDAT();
            }
            else
            {
            }
            popup = true;
        }
        protected void ClosePopUp()
        {
            popup = false;
            bValidation = false;
        }
        protected async Task EditData(TCpt050TxDAT item, int TpAction)
        {


            iTypeAction = TpAction;
            oOneTCpt050TxDAT = item;
            ShowPopUp(iTypeAction);

        }
        Resultat oResultat = new Resultat();



        protected async Task SaveDocVal(TCpt050TxDAT model)
        {
            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment supprimer ceci ?" + model.ID + "?"))
                    return;
            }

            try
            {
                oOneTCpt050TxDAT.TpMaj = iTypeAction;

                oResultat = await oTCpt050TxDATService.GetUpdateResult(model);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
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
                oTCpt050TxDATList = await oTCpt050TxDATService.GetAllData();
            }
            catch (Exception ex)
            {
                await JSRuntime.InvokeVoidAsync("alert", ex.Message);
            }
        }
    }
}