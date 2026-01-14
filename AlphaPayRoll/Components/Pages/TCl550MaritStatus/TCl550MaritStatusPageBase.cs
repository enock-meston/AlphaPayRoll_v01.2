using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayLibrary.TCl550MaritStatus;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.ParamSec.ViewModel;

namespace AlphaPayRoll.ComponentsPages.TCl550MaritStatus
{
	public class TCl550MaritStatusPageBase : ComponentBase
    {

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }


        [Inject]
        protected ITCl550MaritStatus oTCl550MaritStatusService { set; get; }

        public List<ClassTCl550MaritStatus> oTCl550MaritStatusList { set; get; }


        public ClassTCl550MaritStatus oOneTCl550MaritStatus { set; get; }


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
                modalTitle = "Marital Details";
            }
            if (tPAction == 2)
            {
                modalTitle = "Edit Marital Details";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
            }
            else if (tPAction == 3)
            {
                modalTitle = "Delete Marital Details";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";

                oOneTCl550MaritStatus.LModifBy = 9999;
                oOneTCl550MaritStatus.LModifOn = DateTime.Now;

            }



            if (tPAction == 1)
            {


                modalTitle = "Ajouter Marital Status";

                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";


                iTypeAction = tPAction;
                oOneTCl550MaritStatus = new ClassTCl550MaritStatus();

                oOneTCl550MaritStatus.ID = 0;
                oOneTCl550MaritStatus.CreatBy = 9999;
                oOneTCl550MaritStatus.CreatOn = DateTime.Now;



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

        protected void EditData(ClassTCl550MaritStatus item, int TpAction)
        {

            iTypeAction = TpAction;
            oOneTCl550MaritStatus = item;

            ShowPopUp(iTypeAction);

        }


        Resultat oResultat = new Resultat();

        protected async Task SaveTCl550MaritStatus(ClassTCl550MaritStatus item)
        {



            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Do you really want to Delete this Marital Status ?"))
                    return;
            }


            try
            {


                oOneTCl550MaritStatus.TpMaj = iTypeAction;
                oOneTCl550MaritStatus.UserID = 9999;

                oResultat = new Resultat();

                oResultat = await oTCl550MaritStatusService.GetResutUpdate(item);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
                oTCl550MaritStatusList = await oTCl550MaritStatusService.GetTCl550MaritStatus();

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
        }

    }
}

