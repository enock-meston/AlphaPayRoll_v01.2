using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TSL02AgentRet;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.ParamSec.ViewModel;
using AlphaPayRoll.Data;

namespace AlphaPayRoll.Pages.TSL02AgentRet
{
	public class TSL02AgentRetPageBase:ComponentBase
	{

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected SessionService osessionService { get; set; }


        [Inject]
        protected ITSL02AgentRet oTSL02AgentRetService { set; get; }

        public List<ClassTSL02AgentRet> oTSL02AgentRetList { set; get; }


        //Maried Status

        [Inject]
        protected ITCl550MaritStatus oTCl550MaritStatusService { set; get; }

        public List<ClassTCl550MaritStatus> oTCl550MaritStatusList { set; get; }






        public ClassTSL02AgentRet oOneTSL02AgentRet { set; get; }


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
                modalTitle = "AgentRet Details";
            }
            if (tPAction == 2)
            {
                modalTitle = "Edit AgentRet Details";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
            }
            else if (tPAction == 3)
            {
                modalTitle = "Delete AgentRet Details";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";

                oOneTSL02AgentRet.LModifBy = int.Parse(osessionService.UserId);
                oOneTSL02AgentRet.LModifOn = DateTime.Now;

            }



            if (tPAction == 1)
            {


                modalTitle = "Ajouter AgentRet";

                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";


                iTypeAction = tPAction;
                oOneTSL02AgentRet = new ClassTSL02AgentRet();

                oOneTSL02AgentRet.ID = 0;
                oOneTSL02AgentRet.CreatBy = int.Parse(osessionService.UserId);
                oOneTSL02AgentRet.CreatOn = DateTime.Now;



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

        protected void EditData(ClassTSL02AgentRet item, int TpAction)
        {

            iTypeAction = TpAction;
            oOneTSL02AgentRet = item;

            ShowPopUp(iTypeAction);

        }


        Resultat oResultat = new Resultat();

        protected async Task SaveTSL02AgentRet(ClassTSL02AgentRet item)
        {



            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Do you really want to Delete this AgentRet ?"))
                    return;
            }


            try
            {


                oOneTSL02AgentRet.TpMaj = iTypeAction;
                oOneTSL02AgentRet.UserID = int.Parse(osessionService.UserId);

                oResultat = new Resultat();

                oResultat = await oTSL02AgentRetService.GetResutUpdate(item);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
                oTSL02AgentRetList = await oTSL02AgentRetService.GetTSL02AgentRet();

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


            oTCl550MaritStatusList = await oTCl550MaritStatusService.GetTCl550MaritStatus();
            oTSL02AgentRetList = await oTSL02AgentRetService.GetTSL02AgentRet();
        }

    }
}

