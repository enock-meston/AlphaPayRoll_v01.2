using AlphaPayRoll.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL550TpDimAugSal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaPayRoll.Pages.TSL550TpDimAugSal
{
    public class TSL550TpDimAugSalPageBase : ComponentBase
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected SessionService osessionService { get; set; }

        [Inject]
        protected ITSL550TpDimAugSal oTSL550TpDimAugSalService { set; get; }
        public List<ClassTSL550TpDimAugSal> oTSL550TpDimAugSalList { set; get; }
        public ClassTSL550TpDimAugSal oOneTSL550TpDimAugSal { set; get; }
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
                modalTitle = "Type retenues/augment.";
            }
            if (tPAction == 2)
            {
                modalTitle = "Type retenues/augment.";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
            }
            else if (tPAction == 3)
            {
                modalTitle = "Type retenues/augment.";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";

                oOneTSL550TpDimAugSal.LModifBy = int.Parse(osessionService.UserId);
                oOneTSL550TpDimAugSal.LModifOn = DateTime.Now;
            }
            if (tPAction == 1)
            {
                modalTitle = "Type retenues/augment.";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
                iTypeAction = tPAction;
                oOneTSL550TpDimAugSal = new ClassTSL550TpDimAugSal();
                oOneTSL550TpDimAugSal.ID = 0;
                oOneTSL550TpDimAugSal.CreatBy = int.Parse(osessionService.UserId);
                oOneTSL550TpDimAugSal.CreatOn = DateTime.Now;
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
        protected void EditData(ClassTSL550TpDimAugSal item, int TpAction)
        {
            iTypeAction = TpAction;
            oOneTSL550TpDimAugSal = item;
            ShowPopUp(iTypeAction);

        }
        Resultat oResultat = new Resultat();

        protected async Task SaveTSL550TpDimAugSal(ClassTSL550TpDimAugSal item)
        {

            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Do you really want to Delete this TSL550TpDimAugSal ?"))
                    return;
            }
            try
            {
                oOneTSL550TpDimAugSal.TpMaj = iTypeAction;
                oOneTSL550TpDimAugSal.UserID = int.Parse(osessionService.UserId);
                oResultat = new Resultat();

                oResultat = await oTSL550TpDimAugSalService.GetUpdateResult(item);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
                oTSL550TpDimAugSalList = await oTSL550TpDimAugSalService.GetTSL550TpDimAugSal();
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
            oTSL550TpDimAugSalList = await oTSL550TpDimAugSalService.GetTSL550TpDimAugSal();
        }
    }
}
