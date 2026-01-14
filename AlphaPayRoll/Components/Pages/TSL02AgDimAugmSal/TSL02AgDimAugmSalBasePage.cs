using AlphaPayRoll.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.AgRegAugmBase;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TSL02AgDimAugmSal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaPayRoll.Pages.TSL02AgDimAugmSal
{
    public class TSL02AgDimAugmSalBasePage : ComponentBase
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected SessionService osessionService { get; set; }

        [Inject]
        protected ITSL02AgDimAugmSal oTSL02AgDimAugmSalService { set; get; }
        public List<ClassTSL02AgDimAugmSal> oTSL02AgDimAugmSalList { set; get; }
        public ClassTSL02AgDimAugmSal oOneTSL02AgDimAugmSal { set; get; }



        [Inject]
        public ITabPrmNivOne oDonBaseService { set; get; }

        public List<TabPrmNivOne> oTSL550TpDimAugSalList { set; get; }

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

                oOneTSL02AgDimAugmSal.LModifBy = int.Parse(osessionService.UserId);
                oOneTSL02AgDimAugmSal.LModifOn = DateTime.Now;
            }
            if (tPAction == 1)
            {
                modalTitle = "Retenues permanentes";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
                iTypeAction = tPAction;
                oOneTSL02AgDimAugmSal = new ClassTSL02AgDimAugmSal();
                oOneTSL02AgDimAugmSal.ID = 0;
                oOneTSL02AgDimAugmSal.AgentId = paramAgentId;
                oOneTSL02AgDimAugmSal.CreatBy = int.Parse(osessionService.UserId);
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
        protected void EditData(ClassTSL02AgDimAugmSal item, int TpAction)
        {
            iTypeAction = TpAction;
            oOneTSL02AgDimAugmSal = item;
            ShowPopUp(iTypeAction);

        }
        Resultat oResultat = new Resultat();

        protected async Task SaveTSL02AgDimAugmSal(ClassTSL02AgDimAugmSal item)
        {

            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Do you really want to Delete this TSL02AgDimAugmSal ?"))
                    return;
            }
            try
            {
                oOneTSL02AgDimAugmSal.TpMaj = iTypeAction;
                oOneTSL02AgDimAugmSal.UserID = int.Parse(osessionService.UserId);
                oResultat = new Resultat();

                oResultat = await oTSL02AgDimAugmSalService.GetUpdateResult(item);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
                oTSL02AgDimAugmSalList = await oTSL02AgDimAugmSalService.GetTSL02AgDimAugmSalByAgent(paramAgentId);
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
            oTSL550TpDimAugSalList = (await oDonBaseService.GetDBListName("TSL550TpDimAugSal")).ToList();
           
            oTSL02AgDimAugmSalList = await oTSL02AgDimAugmSalService.GetTSL02AgDimAugmSalByAgent(paramAgentId);
        }
    }
}
