using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TSL03TraitemAv;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.ParamSec.ViewModel;
using AlphaPayRoll.Data;

namespace AlphaPayRoll.Pages.TSL03TraitemAv
{
	public class TSL03TraitemAvPageBase:ComponentBase
	{
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected SessionService osessionService { get; set; }

        [Inject]
        protected ITSL03TraitemAv oTSL03TraitemAvService { set; get; }

        public List<ClassTSL03TraitemAv> oTSL03TraitemAvList { set; get; }


        //Maried Status

        [Inject]
        protected ITCl550MaritStatus oTCl550MaritStatusService { set; get; }

        public List<ClassTCl550MaritStatus> oTCl550MaritStatusList { set; get; }






        public ClassTSL03TraitemAv oOneTSL03TraitemAv { set; get; }


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
                modalTitle = "TraitemAv Details";
            }
            if (tPAction == 2)
            {
                modalTitle = "Edit TraitemAv Details";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
            }
            else if (tPAction == 3)
            {
                modalTitle = "Delete TraitemAv Details";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";

                oOneTSL03TraitemAv.LModifBy = int.Parse(osessionService.UserId);
                oOneTSL03TraitemAv.LModifOn = DateTime.Now;

            }



            if (tPAction == 1)
            {


                modalTitle = "Ajouter TraitemAv";

                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";


                iTypeAction = tPAction;
                oOneTSL03TraitemAv = new ClassTSL03TraitemAv();

                oOneTSL03TraitemAv.ID = 0;
                oOneTSL03TraitemAv.CreatBy = int.Parse(osessionService.UserId);
                oOneTSL03TraitemAv.CreatOn = DateTime.Now;



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

        protected void EditData(ClassTSL03TraitemAv item, int TpAction)
        {

            iTypeAction = TpAction;
            oOneTSL03TraitemAv = item;

            ShowPopUp(iTypeAction);

        }


        Resultat oResultat = new Resultat();

        protected async Task SaveTSL03TraitemAv(ClassTSL03TraitemAv item)
        {



            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Do you really want to Delete this TraitemAv ?"))
                    return;
            }


            try
            {


                oOneTSL03TraitemAv.TpMaj = iTypeAction;
                oOneTSL03TraitemAv.UserID = int.Parse(osessionService.UserId);

                oResultat = new Resultat();

                oResultat = await oTSL03TraitemAvService.GetResutUpdate(item);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
                oTSL03TraitemAvList = await oTSL03TraitemAvService.GetTSL03TraitemAv();

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
            oTSL03TraitemAvList = await oTSL03TraitemAvService.GetTSL03TraitemAv();
        }

    }
}

