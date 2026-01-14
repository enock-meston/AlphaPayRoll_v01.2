using AlphaPayRoll.Data;
using AlphaPayRoll.DataServices.Contrat;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.Contrat;
using PayLibrary.InterfParamSec;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TRH02Agent;
using PayLibrary.TypeCongCircons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaPayRoll.Components.Pages.Settings.TypeCongCircons
{
    public class TRH051TypeCongCirconsBase : ComponentBase
    {

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }
        public ClasSessionStorage osessionService { set; get; }

        [Inject]
        protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }

        [Inject]
        protected ITRH051TypeCongCircons oTRH051TypeCongCirconsService { set; get; }

        public List<TRH051TypeCongCircons> oTRH051TypeCongCirconsList { set; get; }


        [Inject]
        protected ITSc551User oTCl550UserService { set; get; }
        public List<TSc551User> oTCl550UserList { set; get; }



        [Inject]
        private ITabPrmNivOne oTabPrmNivOneService { set; get; }
        public List<TabPrmNivOne> oTCl550MotifDepart { set; get; }

        [Inject]
        protected ITRH02Agent oTRH02AgentService { set; get; }
        public List<ClassTRH02Agent> oTRH02AgentList { set; get; }

        [Parameter]
        public string id { set; get; }
        public TRH051TypeCongCircons oOneTRH051TypeCongCircons { set; get; }


        public string getRowColor(int i)
        {
            return (i % 2 == 0) ? "table-info" : "table-light";
        }


        //=================================================================================
        public bool isLoading { set; get; } = true;

        protected bool popup = false;


        public string StyleButton { set; get; }
        public string ButtonCaption { set; get; }

        public string modalTitle { set; get; }

        public int iTypeAction { set; get; }

        protected void ShowPopUp(int tPAction)
        {

            if (tPAction == 0)
            {
                modalTitle = " Type Congé Circonstance Detail";
            }
            if (tPAction == 2)
            {
                modalTitle = "Modifier  Type Congé Circonstance Detail";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
            }
            else if (tPAction == 3)
            {
                modalTitle = "Supprimer  Type Congé Circonstance Detail";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";
                if (oOneTRH051TypeCongCircons.LModifOn < new DateTime(1753, 1, 1))
                    oOneTRH051TypeCongCircons.LModifOn = DateTime.Now;
                oOneTRH051TypeCongCircons.LModifBy = int.Parse(osessionService.UserId);


            }



            if (tPAction == 1)
            {

                modalTitle = "Ajouter Type Conge Circonstance";

                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";

                iTypeAction = tPAction;
                oOneTRH051TypeCongCircons = new TRH051TypeCongCircons();

                oOneTRH051TypeCongCircons.ID = 0;
                oOneTRH051TypeCongCircons.CreatBy = int.Parse(osessionService.UserId);
                oOneTRH051TypeCongCircons.CreatOn = DateTime.Now;
                oOneTRH051TypeCongCircons.LModifOn = DateTime.Now;

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


        protected void EditData(TRH051TypeCongCircons item, int TpAction)
        {

            iTypeAction = TpAction;
            oOneTRH051TypeCongCircons = item;

            ShowPopUp(iTypeAction);

        }


        Resultat oResultat = new Resultat();

        protected async Task SaveDepart(TRH051TypeCongCircons item)
        {

            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment supprimer ceci ?Type?"))
                    return;
            }
           
            try
            {

                oOneTRH051TypeCongCircons.TpMaj = iTypeAction;
                oOneTRH051TypeCongCircons.UserID = int.Parse(osessionService.UserId);
                oResultat = new Resultat();

                oResultat = await oTRH051TypeCongCirconsService.UpdateTRH051TypeCongCircons(oOneTRH051TypeCongCircons);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);


                oTRH051TypeCongCirconsList = await oTRH051TypeCongCirconsService.GetTRH051TypeCongCircons();

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
                isLoading = false;
            }
        }

        public string CurrencyFormat { set; get; } = "###,##0";


        public string TypeAffichage { set; get; }
        public void ParamAgent()
        {
            TypeAffichage = "AgentUniquement";
        }


        public async Task GoBack()
        {
            await JSRuntime.InvokeVoidAsync("history.back");
        }


        protected override async Task OnInitializedAsync()
        {
            osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");

            try
            {
                oOneTRH051TypeCongCircons = new TRH051TypeCongCircons();
                oTRH051TypeCongCirconsList = await oTRH051TypeCongCirconsService.GetTRH051TypeCongCircons();

                oTCl550UserList = await oTCl550UserService.GetList();
            }
            catch (Exception ex)
            {
                await JSRuntime.InvokeVoidAsync("alert", ex.Message);

            }
            finally
            {
                isLoading = false;
            }
        }
    }
}
