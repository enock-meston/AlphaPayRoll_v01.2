using AlphaPayRoll.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.AgRegAugmBase;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL02AgDimAugmSal;
using PayLibrary.TSL550TpDimAugSal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaPayRoll.Components.Pages.AgRegAugmBaseType
{
    public class TSL02AgDimAugmBaseTypePageBase : ComponentBase
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected SessionService osessionService { get; set; }


        [Inject]
        protected ITSL02AgRetPayment oTSL02AgDimAugmSalService { set; get; }
        public List<TSL02AgRetPayment> oTSL02AgDimAugmSalList { set; get; }
        public TSL02AgRetPayment oOneTSL02AgDimAugmSal { set; get; }


        [Inject]
        public ITabPrmNivOne oDonBaseService { set; get; }
        public List<TabPrmNivOne> oTSL550TpRetRembList { set; get; }

        //[Inject]
        //public ITabPrmNivOne oDonBaseService { set; get; }

        //public List<TabPrmNivOne> oTSL550TpDimAugSalList { set; get; }


        //[Inject]
        //protected ITSL550TpDimAugSal oTSL550TpDimAugSalService { set; get; }
        //public List<ClassTSL550TpDimAugSal> oTSL550TpDimAugSalList { set; get; }



        [Parameter]
        public int paramAgentId { set; get; }

        [Parameter]
        public string paramNomAgent { set; get; }

        public string getRowColor(int i)
        {
            return (i % 2 == 0) ? "table-info" : "table-light";
        }


        //=================================================================================

        public string CurrencyFormat { set; get; } = "###,##0";
        protected bool popup = false;


        public string StyleButton { set; get; }
        public string ButtonCaption { set; get; }

        public string modalTitle { set; get; }

        public int iTypeAction { set; get; }

        protected void ShowPopUp(int tPAction)
        {

            if (tPAction == 0)
            {
                modalTitle = "Retenues permanentes";
            }
            if (tPAction == 2)
            {
                modalTitle = "Retenues permanentes";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
            }
            else if (tPAction == 3)
            {
                modalTitle = "Retenues permanentes";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";

                oOneTSL02AgDimAugmSal.LModifBy = osessionService.UserId;
                oOneTSL02AgDimAugmSal.LModifOn = DateTime.Now;
            }
            if (tPAction == 1)
            {
                modalTitle = "Retenues permanentes";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
                iTypeAction = tPAction;
                oOneTSL02AgDimAugmSal = new TSL02AgRetPayment();
                oOneTSL02AgDimAugmSal.ID = 0;
                oOneTSL02AgDimAugmSal.AgentId = paramAgentId;

                oOneTSL02AgDimAugmSal.EnVig = true;
                oOneTSL02AgDimAugmSal.CreatBy = osessionService.UserId;
                oOneTSL02AgDimAugmSal.CreatOn = DateTime.Now;


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
        protected void EditData(TSL02AgRetPayment item, int TpAction)
        {
            iTypeAction = TpAction;
            oOneTSL02AgDimAugmSal = item;
            ShowPopUp(iTypeAction);

        }
        Resultat oResultat = new Resultat();


        public int pTpRetenueID = 0;
        public async Task TpRetenueHasChanged(int Value)
        {
            pTpRetenueID = Value;
            oTSL02AgDimAugmSalList = await oTSL02AgDimAugmSalService.GetTSL02AgRetAugmBaseByType(pTpRetenueID);

        }

        protected async Task SaveTSL02AgDimAugmSal(TSL02AgRetPayment item)
        {

            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Do you really want to Delete this TSL02AgDimAugmSal ?"))
                    return;
            }
            try
            {
                oOneTSL02AgDimAugmSal.TpMaj = iTypeAction;
                oOneTSL02AgDimAugmSal.UserID = osessionService.UserId;
                oResultat = new Resultat();

                oResultat = await oTSL02AgDimAugmSalService.GetUpdateResult(item);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
				oTSL02AgDimAugmSalList = await oTSL02AgDimAugmSalService.GetTSL02AgRetAugmBaseByType(pTpRetenueID);
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
            oOneTSL02AgDimAugmSal = new TSL02AgRetPayment();
            oTSL550TpRetRembList = (await oDonBaseService.GetDBListName("TSL550TpRetRemb")).ToList();


        }
    }
}
