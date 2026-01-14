using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TSL04ArchivINSS;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.ParamSec.ViewModel;
using AlphaPayRoll.Data;

namespace AlphaPayRoll.Pages.TSL04ArchivINSS
{
	public class TSL04ArchivINSSPageBase:ComponentBase
	{
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected SessionService osessionService { get; set; }

        [Inject]
        protected ITSL04ArchivINSS oTSL04ArchivINSSService { set; get; }

        public List<ClassTSL04ArchivINSS> oTSL04ArchivINSSList { set; get; }


        //Maried Status

        [Inject]
        protected ITCl550MaritStatus oTCl550MaritStatusService { set; get; }

        public List<ClassTCl550MaritStatus> oTCl550MaritStatusList { set; get; }






        public ClassTSL04ArchivINSS oOneTSL04ArchivINSS { set; get; }


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
                modalTitle = "ArchivINSS Details";
            }
            if (tPAction == 2)
            {
                modalTitle = "Edit ArchivINSS Details";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
            }
            else if (tPAction == 3)
            {
                modalTitle = "Delete ArchivINSS Details";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";

                oOneTSL04ArchivINSS.LModifBy = osessionService.UserId;
                oOneTSL04ArchivINSS.LModifOn = DateTime.Now;

            }



            if (tPAction == 1)
            {


                modalTitle = "Ajouter ArchivINSS";

                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";


                iTypeAction = tPAction;
                oOneTSL04ArchivINSS = new ClassTSL04ArchivINSS();

                oOneTSL04ArchivINSS.ID = 0;
                oOneTSL04ArchivINSS.CreatBy = osessionService.UserId;
                oOneTSL04ArchivINSS.CreatOn = DateTime.Now;



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

        protected void EditData(ClassTSL04ArchivINSS item, int TpAction)
        {

            iTypeAction = TpAction;
            oOneTSL04ArchivINSS = item;

            ShowPopUp(iTypeAction);

        }


        Resultat oResultat = new Resultat();

        protected async Task SaveTSL04ArchivINSS(ClassTSL04ArchivINSS item)
        {



            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Do you really want to Delete this ArchivINSS ?"))
                    return;
            }


            try
            {


                oOneTSL04ArchivINSS.TpMaj = iTypeAction;
                oOneTSL04ArchivINSS.UserID = osessionService.UserId;

                oResultat = new Resultat();

                oResultat = await oTSL04ArchivINSSService.GetResutUpdate(item);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
                oTSL04ArchivINSSList = await oTSL04ArchivINSSService.GetTSL04ArchivINSS();

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
            oTSL04ArchivINSSList = await oTSL04ArchivINSSService.GetTSL04ArchivINSS();
        }

    }
}

