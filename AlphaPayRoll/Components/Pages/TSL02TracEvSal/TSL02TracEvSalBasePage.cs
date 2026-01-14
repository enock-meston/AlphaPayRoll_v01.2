using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.TSL02TracEvSal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaPayRoll.Pages.TSL02TracEvSal
{
    public class TSL02TracEvSalBasePage : ComponentBase
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }
        [Inject]
        protected ITSL02TracEvSal oTSL02TracEvSalService { set; get; }
        public List<ClassTSL02TracEvSal> oTSL02TracEvSalList { set; get; }
        public ClassTSL02TracEvSal oOneTSL02TracEvSal { set; get; }
        public string getRowColor(int i)
        {
            return (i % 2 == 0) ? "table-info" : "table-light";
        }


        //=================================================================================


        protected bool popup = false;


        public string StyleButton { set; get; }
        public string ButtonCaption { set; get; }

        public string modalTitle { set; get; }

        public int iTypeAction { set; get; }

        protected void ShowPopUp(int tPAction)
        {

            if (tPAction == 0)
            {
                modalTitle = "TSL02TracEvSal Details";
            }
            if (tPAction == 2)
            {
                modalTitle = "Edit TSL02TracEvSal Details";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
            }
            else if (tPAction == 3)
            {
                modalTitle = "Delete TSL02TracEvSal Details";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";

                oOneTSL02TracEvSal.LModifBy = 9999;
                oOneTSL02TracEvSal.LModifOn = DateTime.Now;
            }
            if (tPAction == 1)
            {
                modalTitle = "Ajouter TSL02TracEvSal";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
                iTypeAction = tPAction;
                oOneTSL02TracEvSal = new ClassTSL02TracEvSal();
                oOneTSL02TracEvSal.Numero = 0;
                oOneTSL02TracEvSal.CreatBy = 9999;
                oOneTSL02TracEvSal.CreatOn = DateTime.Now;
            }
            else
            {
            }
            popup = true;
        }
        protected void ClosePopUp()
        {
            popup = false;
        }
        protected void EditData(ClassTSL02TracEvSal item, int TpAction)
        {
            iTypeAction = TpAction;
            oOneTSL02TracEvSal = item;
            ShowPopUp(iTypeAction);

        }
        Resultat oResultat = new Resultat();

        protected async Task SaveTSL02TracEvSal(ClassTSL02TracEvSal item)
        {

            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Do you really want to Delete this TSL02TracEvSal ?"))
                    return;
            }
            try
            {
                oOneTSL02TracEvSal.TpMaj = iTypeAction;
                oOneTSL02TracEvSal.UserID = 9999;
                oResultat = new Resultat();

                oResultat = await oTSL02TracEvSalService.GetUpdateResult(item);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
                oTSL02TracEvSalList = await oTSL02TracEvSalService.GetTSL02TracEvSal();
                if (oResultat.Result.Trim().Length < 30)
                {
                    ClosePopUp();
                }
            }
            catch (Exception ex)
            {
                await JSRuntime.InvokeVoidAsync("alert", ex.Message);
            }
            finally
            {

            }
        }
        //=========================================================================================

        protected override async Task OnInitializedAsync()
        {
            oTSL02TracEvSalList = await oTSL02TracEvSalService.GetTSL02TracEvSal();
        }
    }
}
