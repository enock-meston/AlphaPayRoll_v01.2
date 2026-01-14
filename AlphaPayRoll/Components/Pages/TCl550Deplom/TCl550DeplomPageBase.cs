using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayLibrary.TCl550Deplom;
using PayLibrary.TCl550MaritStatus;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AlphaPayRoll.Pages.TCl550Deplom
{
	public class TCl550DeplomPageBase : ComponentBase
	{

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }


        [Inject]
        protected ITCl550Deplom oTCl550DeplomService { set; get; }

        public List<ClassTCl550Deplom> oTCl550DeplomList { set; get; }


        public ClassTCl550Deplom oOneTCl550Deplom { set; get; }


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
                modalTitle = "Deplom Details";
            }
            if (tPAction == 2)
            {
                modalTitle = "Edit Deplom Details";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
            }
            else if (tPAction == 3)
            {
                modalTitle = "Delete Deplom Details";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";

                oOneTCl550Deplom.LModifBy = 9999;
                oOneTCl550Deplom.LModifOn = DateTime.Now;

            }



            if (tPAction == 1)
            {


                modalTitle = "Ajouter Deplom";

                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";


                iTypeAction = tPAction;
                oOneTCl550Deplom = new ClassTCl550Deplom();

                oOneTCl550Deplom.ID = 0;
                oOneTCl550Deplom.CreatBy = 9999;
                oOneTCl550Deplom.CreatOn = DateTime.Now;



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

        protected void EditData(ClassTCl550Deplom item, int TpAction)
        {

            iTypeAction = TpAction;
            oOneTCl550Deplom = item;

            ShowPopUp(iTypeAction);

        }


        //Resultat oResultat = new Resultat();

        //protected async Task SaveTCl550Deplom(ClassTCl550Deplom item)
        //{



        //    if (iTypeAction == 3)
        //    {
        //        if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Do you really want to Delete this Deplom ?"))
        //            return;
        //    }


        //    try
        //    {


        //        oOneTCl550Deplom.TpMaj = iTypeAction;
        //        oOneTCl550Deplom.UserID = 9999;

        //        oResultat = new Resultat();

        //        oResultat = await oTCl550DeplomService.GetResutUpdate(item);
        //        await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
        //        oTCl550DeplomList = await oTCl550DeplomService.GetTCl550Deplom();

        //        if (oResultat.Result.Trim().Length < 30)
        //        {
        //            ClosePopUp();
        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        await JSRuntime.InvokeVoidAsync("alert", ex.Message);
        //    }
        //    finally
        //    {

        //    }
        //}


        //=========================================================================================


        protected override async Task OnInitializedAsync()
        {

            oTCl550DeplomList = await oTCl550DeplomService.GetTCl550Deplom();
        }
    }
}

