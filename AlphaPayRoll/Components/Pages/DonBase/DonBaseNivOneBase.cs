using AlphaPayRoll.Shared;
using AlphaPayRoll.DataServices.DonBase;
using PayLibrary.ParamDonBase;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.ParamSec;
using Microsoft.JSInterop;
using AlphaPayRoll.Data;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.InterfParamSec;

namespace AlphaPayRoll.Components.Pages.DonBase
{
    public class DonBaseNivOneBase :ComponentBase
    {

   
        [Inject]
        protected SessionService osessionService { set; get; }
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        private ITabPrmNivOne oTabPrmNivOneService { set; get; }
        public List<TabPrmNivOne> oTabPrmNivOneList { set; get; }


        protected TabPrmNivOne oTabPrmNivOneInsert = new TabPrmNivOne();

        [Inject]
        public ITSc551User oTSc551UserService { set; get; }
        public List<TSc551User> oTSc551UserList { set; get; }



        [Parameter]
        public string id { set; get; }

        //protected string pID { set; get; } 
        //protected string pOrderNum { set; get; }
        //protected string pCreatBy { set; get; } 
        //protected string pModifBy { set; get; } 
        //protected string pCreatOn { set; get; } 

        //protected string pModifOn { set; get; }

        protected bool popup = false;


        public string StyleButton { set; get; }
        public string ButtonCaption { set; get; }

        public string modalTitle { set; get; }

        protected void ShowPopUp(int tPAction)
        {

            if (tPAction == 0)
            {
                modalTitle = "Détails paramétrage";
            }
            if (tPAction == 2)
            {
                modalTitle = "Modifier paramétrage";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
            }
            else if (tPAction == 3)
            {
                modalTitle = "Supprimer paramétrage";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";

                oTabPrmNivOneInsert.LModifBy = osessionService.UserId;
                oTabPrmNivOneInsert.LModifOn = DateTime.Now;

            }



            if (tPAction == 1)
            {


                modalTitle = "Ajouter paramétrage";

                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";


                iTypeAction = tPAction;
                oTabPrmNivOneInsert = new TabPrmNivOne();
                oTabPrmNivOneInsert.Enab = true;
                oTabPrmNivOneInsert.CreatBy = osessionService.UserId;
                oTabPrmNivOneInsert.ID = 0;
                oTabPrmNivOneInsert.OrdNum = 0;
                oTabPrmNivOneInsert.CreatOn = DateTime.Now;



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

        protected void InserTableNivOne()
        {

            oTabPrmNivOneInsert = new TabPrmNivOne();

            oTabPrmNivOneInsert.UserID = osessionService.UserId;
            oTabPrmNivOneInsert.CodeObj = int.Parse(id);
            oTabPrmNivOneInsert.TpMaj = 1;

            oTabPrmNivOneList.Add(oTabPrmNivOneInsert);


        }

        public int iTypeAction { set; get; }





        protected void EditTableNivOne(TabPrmNivOne ModifTableNivOne, int TpAction)
        {

            iTypeAction = TpAction;
            oTabPrmNivOneInsert = ModifTableNivOne;



            ShowPopUp(iTypeAction);
        }


        public Resultat oResultat { set; get; }

        protected async Task TableNivOneSave(TabPrmNivOne ModifTableNivOne)
        {



            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment supprimer cet enregistrement ?"))
                    return;
            }


            try
            {

                oTabPrmNivOneInsert.CodeObj = int.Parse(id);
                oTabPrmNivOneInsert.TpMaj = iTypeAction;
                oTabPrmNivOneInsert.UserID = osessionService.UserId;

                oResultat = new Resultat();

                oResultat = await oTabPrmNivOneService.MajDonBaseNivOne(ModifTableNivOne);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
                oTabPrmNivOneList = (await oTabPrmNivOneService.GetDBList(int.Parse(id))).ToList();


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






            //oTabPrmNivOneInsert.UserID = osessionService.UserId;
            //oTabPrmNivOneInsert.CodeObj = int.Parse(id);
            //oTabPrmNivOneInsert.TpMaj = iTypeAction;


            //ModifTableNivOne.ID = Int16.Parse(pID);
            //ModifTableNivOne.OrdNum = Int16.Parse(pOrderNum);
            //ModifTableNivOne.CreatBy = Int16.Parse(pCreatBy);
            //ModifTableNivOne.CreatOn = DateTime.Parse(pCreatOn);
            //ModifTableNivOne.LModifBy = Int16.Parse(pCreatBy);
            //ModifTableNivOne.LModifOn = DateTime.Parse(pCreatOn);


            //if (iTypeAction == 2)
            //{
            //    ModifTableNivOne.LModifBy = Int16.Parse(pModifBy);
            //    ModifTableNivOne.LModifOn = DateTime.Parse(pModifOn);
            //}


            //await oTabPrmNivOneService.MajDonBaseNivOne(ModifTableNivOne);
            //ClosePopUp();
            //int codeTable = int.Parse(id);
            //oTabPrmNivOneList = (await oTabPrmNivOneService.GetDBList(codeTable)).ToList();
        }



        public string getRowColor(int i)
        {
            return (i % 2 == 0) ? "table-info" : "table-light";
        }

        //public static string sNomDonBase { set; get; }

        public bool isLoading { set; get; }
        protected override async Task OnInitializedAsync()
        {



            isLoading = true;
            //if (osessionService.IsLogged)
            //{
                try
                {


                    isLoading = false;

                    iTypeAction = 0;
                    oTabPrmNivOneInsert.ID = 0;
                    int codeTable = int.Parse(id);


                    oTSc551UserList = await oTSc551UserService.GetList();

                    oTabPrmNivOneList = (await oTabPrmNivOneService.GetDBList(codeTable)).ToList();

                    //if (oTabPrmNivOneList.Count > 0)
                    //{
                    //    sNomDonBase = oTabPrmNivOneList[0].NomParent;
                    //}

                }
                catch (Exception ex)
                {
                    await JSRuntime.InvokeVoidAsync("alert", ex.Message);
                }
                finally
                {
                    isLoading = false;
                }
            //}
  





        }





    }
}

