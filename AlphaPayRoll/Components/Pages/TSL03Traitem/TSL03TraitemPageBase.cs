using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TSL03Traitem;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.ParamSec.ViewModel;
using AlphaPayRoll.Data;

namespace AlphaPayRoll.Pages.TSL03Traitem
{
	public class TSL03TraitemPageBase:ComponentBase
	{
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected SessionService osessionService { get; set; }

        [Inject]
        protected ITSL03Traitem oTSL03TraitemService { set; get; }

        public List<ClassTSL03Traitem> oTSL03TraitemList { set; get; }


        //Maried Status

        [Inject]
        protected ITCl550MaritStatus oTCl550MaritStatusService { set; get; }

        public List<ClassTCl550MaritStatus> oTCl550MaritStatusList { set; get; }


        [Parameter]
        public int paramAgentId { set; get; }


        [Parameter]
        public string id { set; get; }
        public ClassTSL03Traitem oOneTSL03Traitem { set; get; }


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
                modalTitle = "Traitem Details";
            }
            if (tPAction == 2)
            {
                modalTitle = "Edit Traitem Details";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
            }
            else if (tPAction == 3)
            {
                modalTitle = "Delete Traitem Details";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";

                oOneTSL03Traitem.LModifBy = int.Parse(osessionService.UserId);
                oOneTSL03Traitem.LModifOn = DateTime.Now;

            }



            if (tPAction == 1)
            {


                modalTitle = "Ajouter Traitem";

                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";


                iTypeAction = tPAction;
                oOneTSL03Traitem = new ClassTSL03Traitem();

                oOneTSL03Traitem.ID = 0;
                oOneTSL03Traitem.CreatBy = int.Parse(osessionService.UserId);
                oOneTSL03Traitem.CreatOn = DateTime.Now;



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

        protected void EditData(ClassTSL03Traitem item, int TpAction)
        {

            iTypeAction = TpAction;
            oOneTSL03Traitem = item;

            ShowPopUp(iTypeAction);

        }


        Resultat oResultat = new Resultat();

        protected async Task SaveTSL03Traitem(ClassTSL03Traitem item)
        {



            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Do you really want to Delete this Traitem ?"))
                    return;
            }


            try
            {


                oOneTSL03Traitem.TpMaj = iTypeAction;
                oOneTSL03Traitem.UserID = int.Parse(osessionService.UserId);

                oResultat = new Resultat();

                oResultat = await oTSL03TraitemService.GetResutUpdate(item);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
                oTSL03TraitemList = await oTSL03TraitemService.GetTSL03Traitem();

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

        public string CurrencyFormat { set; get; } = "###,##0";
        protected override async Task OnInitializedAsync()
        {
            oTCl550MaritStatusList = await oTCl550MaritStatusService.GetTCl550MaritStatus();
            oTSL03TraitemList = await oTSL03TraitemService.GetTSL03TraitemByAgent(paramAgentId);
        }


    }
}

