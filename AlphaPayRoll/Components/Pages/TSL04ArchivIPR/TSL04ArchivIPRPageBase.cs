using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TSL04ArchivIPR;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.ParamSec.ViewModel;
using AlphaPayRoll.Data;

namespace AlphaPayRoll.Pages.TSL04ArchivIPR
{
	public class TSL04ArchivIPRPageBase:ComponentBase
	{
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }


        [Inject]
        protected SessionService osessionService { get; set; }

        [Inject]
        protected ITSL04ArchivIPR oTSL04ArchivIPRService { set; get; }

        public List<ClassTSL04ArchivIPR> oTSL04ArchivIPRList { set; get; }


        //Maried Status

        [Inject]
        protected ITCl550MaritStatus oTCl550MaritStatusService { set; get; }

        public List<ClassTCl550MaritStatus> oTCl550MaritStatusList { set; get; }






        public ClassTSL04ArchivIPR oOneTSL04ArchivIPR { set; get; }


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
                modalTitle = "ArchivIPR Details";
            }
            if (tPAction == 2)
            {
                modalTitle = "Edit ArchivIPR Details";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
            }
            else if (tPAction == 3)
            {
                modalTitle = "Delete ArchivIPR Details";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";

                oOneTSL04ArchivIPR.LModifBy = osessionService.UserId;
                oOneTSL04ArchivIPR.LModifOn = DateTime.Now;

            }



            if (tPAction == 1)
            {


                modalTitle = "Ajouter ArchivINSS";

                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";


                iTypeAction = tPAction;
                oOneTSL04ArchivIPR = new ClassTSL04ArchivIPR();

                oOneTSL04ArchivIPR.ID = 0;
                oOneTSL04ArchivIPR.CreatBy = osessionService.UserId;
                oOneTSL04ArchivIPR.CreatOn = DateTime.Now;



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

        protected void EditData(ClassTSL04ArchivIPR item, int TpAction)
        {

            iTypeAction = TpAction;
            oOneTSL04ArchivIPR = item;

            ShowPopUp(iTypeAction);

        }


        Resultat oResultat = new Resultat();

        protected async Task SaveTSL04ArchivIPR(ClassTSL04ArchivIPR item)
        {



            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Do you really want to Delete this ArchivIPR ?"))
                    return;
            }


            try
            {


                oOneTSL04ArchivIPR.TpMaj = iTypeAction;
                oOneTSL04ArchivIPR.UserID = osessionService.UserId;

                oResultat = new Resultat();

                oResultat = await oTSL04ArchivIPRService.GetResutUpdate(item);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
                oTSL04ArchivIPRList = await oTSL04ArchivIPRService.GetTSL04ArchivIPR();

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
            oTSL04ArchivIPRList = await oTSL04ArchivIPRService.GetTSL04ArchivIPR();
        }

    }
}

