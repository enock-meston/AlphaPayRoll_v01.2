
using Alphabankblazor.DataServices.HumanResource;
using AlphaPayRoll.Data;
using AlphaPayRoll.DataServices.Contrat;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.Cl550Branch;
using PayLibrary.CONTRACT_GOMISE;
using PayLibrary.Faute;
using PayLibrary.FauteTRH055;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Saction;
using PayLibrary.TCl550Fonction;
using PayLibrary.TRH02Agent;
using PayLibrary.TypeSaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaPayRoll.Components.Pages.Saction
{
    public class TRH05SactionPageBase : ComponentBase
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        //[Inject]
        //protected SessionService osessionService { set; get; }

        public ClasSessionStorage osessionService { set; get; }

        [Inject]
        protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }
        [Inject]
        protected ITSc551SubBranch oSubBranchService { set; get; }
        public List<TSc551SubBranch> SubBranch { set; get; }


        [Inject]
        protected ITCl550Branch oBranchService { set; get; }
        public List<TSc550Branch> oBranch { set; get; }


        [Inject]
        public ITSc551User oTSc551UserService { set; get; }

        public List<TSc551User> oTSc551UserList { set; get; }

        [Inject]
        protected ITRH05Saction oTRH05SactionService { set; get; }
        public List<TRH05Saction> oTRH05SactionList { set; get; }

        public TRH05Saction oOneAmount { set; get; }

        [Inject]
        protected ITRH055FAUTE oTRH055FAUTEService { set; get; }
        public List<TRH055FAUTE> oTRH055FAUTEList { set; get; }

        [Inject]
        protected ITRH051TypeSaction oTRH051TypeSactionService { set; get; }
        public List<TRH051TypeSaction> oTRH051TypeSactionList { set; get; }


        [Inject]
        protected ITCl550Branch oTCl550BranchService { set; get; }
        public List<ClassTCl550Branch> oTCl550BranchList { set; get; }



        [Inject]
        protected ITSc551User oTCl550UserService { set; get; }
        public List<TSc551User> oTCl550UserList { set; get; }


        [Inject]
        protected ITCl550Fonction oTCl550FonctionService { set; get; }
        public List<ClassTCl550Fonction> oTCl550FonctionList { set; get; }

        public List<ClasContrat> oContratList { set; get; }

        [Inject]
        protected ITRH02Agent oTRH02AgentService { set; get; }
        public List<ClassTRH02Agent> oTRH02AgentList { set; get; }
        public ClassTRH02Agent oOneTRH02Agent { set; get; }


        [Inject]
        protected ITSc551SubBranch oTCl550SubBranchService { set; get; }
        public List<TSc551SubBranch> oTCl550SubBranchList { set; get; }
        public List<TSc551SubBranch> oTCl550SubBranchList2 { set; get; }


        // foute

        [Inject]
        protected ITRH04FAUTE oTRH04FAUTEService { set; get; }
        public List<TRH04FAUTE> oTRH04FAUTEList { set; get; }


        public string getRowColor(int i)
        {
            return (i % 2 == 0) ? "table-info" : "table-light";
        }
        public bool isLoading { set; get; } = true;

        //=================================================================================

        protected bool popup = false;


        public string StyleButton { set; get; }
        public string ButtonCaption { set; get; }

        public string modalTitle { set; get; }

        public int iTypeAction { set; get; }

        public bool bValidation { set; get; } = false;
        public string sCodeBranch { set; get; }
        protected void ShowPopUp(int tPAction)
        {

            if (tPAction == 0)
            {
                modalTitle = "Sanction Detail";
            }
            else if (tPAction == 2)
            {
                modalTitle = "Modification Sanction Detail";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Save";
            }

            if (tPAction == 1)
            {
                modalTitle = "Ajouter";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Ajouter";
                iTypeAction = tPAction;

                oOneAmount.LModifBy = 9999;
                oOneAmount.LModifOn = DateTime.Now;
                oOneAmount.CreatOn = DateTime.Now;
                oOneAmount.DateDebut = DateTime.Now;
                oOneAmount.DateFin = DateTime.Now;
                oOneAmount.Matricule = sMatricule;
                oOneAmount.CreatBy = int.Parse(osessionService.UserId);


            }
            else if (tPAction == 3)
            {
                modalTitle = "Supprimer Sanction Detail";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";

                oOneAmount.LModifBy = int.Parse(osessionService.UserId);
                oOneAmount.LModifOn = DateTime.Now;
                oOneAmount.CreatOn = DateTime.Now;
                oOneAmount.Matricule = sMatricule;
                oOneAmount.CreatBy = int.Parse(osessionService.UserId);
            }
            else
            {
            }
            popup = true;
        }
        public bool AgentSelected { set; get; } = false;

        public int AgentID { set; get; }
        public decimal SalaireBase { set; get; }
        public string sNomAgent { set; get; }
        public string sMatricule { set; get; }
        public string sNomPrenom { set; get; }

        public void BackToAgent()
        {
            AgentSelected = false;

        }
        public async Task GoBack()
        {
            await JSRuntime.InvokeVoidAsync("history.back");
        }
        protected void ClosePopUp()
        {
            popup = false;
            bValidation = false;
        }

        public bool popupTrans { set; get; }

        protected void ClosePopUpTrans()
        {
            popupTrans = false;

        }

        protected void ShowPopUpTrans()
        {


            popupTrans = true;

        }

        protected void EditData(TRH05Saction item, int TpAction)
        {
            iTypeAction = TpAction;
            oOneAmount = item;
            ShowPopUp(iTypeAction);

        }
        Resultat oResultat = new Resultat();


        public void DonAgentSuite(TRH05Saction pSaction)
        {
            var agent = oTRH02AgentList?.FirstOrDefault(a => a.Matricule == pSaction.Matricule);

            if (agent != null)
            {
                DonAgentSuite(agent);
            }
        }

        public void DonAgentSuite(ClassTRH02Agent pAgent)
        {
            AgentID = pAgent.AgentId;
            SalaireBase = pAgent.SalBase;
            AgentSelected = true;
            sNomAgent = pAgent.Nom.Trim() + " " + pAgent.Prenom.Trim();
        }


        protected async Task SaveDocVal(TRH05Saction item)
        {
            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to DELETE  this item ?"))
                    return;
            }
            else if (oOneAmount.Raisons == "")
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Raisons est obligatoire");
                return;
            }
            else if (oOneAmount.FauteID == 0)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Faute est obligatoire");
                return;
            }
            else if (oOneAmount.TpSanctRecID == 0)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Type Sanction Rec est obligatoire");
                return;
            }
            else if (oOneAmount.TpSanctPrevID == 0)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Type Sanction Prev. est obligatoire");
                return;
            }
            else if (oOneAmount.DecidPar == "")
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Decid Par est obligatoire");
                return;
            }



            //item.CreatBy = osessionService.UserId;
            item.TpMaj = iTypeAction;
            oResultat = new Resultat();



            oResultat = await oTRH05SactionService.GetUpdateResult(item);
            await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
            //oHr_ApplicationList = await oHr_ApplicationService.GetList(sClientId);
            oTRH05SactionList = await oTRH05SactionService.GetListAll();
            ClosePopUp();


        }
        public int sClientId { set; get; } = 0;

        public async Task searchByMatricule()
        {
            //var matricule = oOneTRH02Agent?.Matricule;
            if (string.IsNullOrWhiteSpace(sMatricule))
            {
                await JSRuntime.InvokeVoidAsync("alert", "Please enter a Matricule.");
                return;
            }

            try
            {
                isLoading = true;

                // First, search for the agent
                oTRH02AgentList = await oTRH02AgentService.GetAgentByMatricule(sMatricule);

                if (oTRH02AgentList.Count > 0)
                {
                    sNomPrenom = oTRH02AgentList[0].Nom.Trim() + " " + oTRH02AgentList[0].Prenom.Trim();
                    oTRH04FAUTEList = await oTRH04FAUTEService.GetList(sMatricule);

                    oTRH05SactionList = await oTRH05SactionService.GetList(sMatricule);
                    bAddDisabled = false;
                }
                else

                {
                    bAddDisabled = true;
                    await JSRuntime.InvokeVoidAsync("alert", $"No agent found with matricule: {sMatricule}");
                }

            }
            catch (Exception ex)
            {
                await JSRuntime.InvokeVoidAsync("alert", $"Error during search: {ex.Message}");
            }
            finally
            {
                isLoading = false;
                //StateHasChanged();
            }
        }

        public bool bAddDisabled { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");

            try
            {

                 oTSc551UserList = await oTSc551UserService.GetList();

                //oTRH05SactionList = await oTRH05SactionService.GetListAll();

                oOneAmount = new TRH05Saction();

                oTRH055FAUTEList = await oTRH055FAUTEService.GetListAll();

                oTRH051TypeSactionList = await oTRH051TypeSactionService.GetListAll();

               
                oOneTRH02Agent = new ClassTRH02Agent();
                //oTRH02AgentList = await oTRH02AgentService.GetAgentByMatricule("RIM00002");


                oTCl550BranchList = await oTCl550BranchService.GetT550Branch();
                oTCl550SubBranchList2 = await oTCl550SubBranchService.GetList();

                oTCl550BranchList = await oTCl550BranchService.GetT550Branch();
                oTCl550UserList = await oTCl550UserService.GetList();
                oTCl550FonctionList = await oTCl550FonctionService.GetTCl550Fonction();

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
