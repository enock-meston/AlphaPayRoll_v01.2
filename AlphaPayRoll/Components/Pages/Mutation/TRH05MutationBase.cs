using AlphaPayRoll.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.Cl550Branch;
using PayLibrary.CONTRACT_GOMISE;
using PayLibrary.Contrat;
using PayLibrary.InterfParamSec;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.Localisation;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TCl550Fonction;
using PayLibrary.TRH02Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AlphaPayRoll.Components.Pages.Mutation
{
    public class TRH05MutationBase : ComponentBase
    {

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        //[Inject]
        //protected SessionService osessionService { get; set; }
        public ClasSessionStorage osessionService { set; get; }

        [Inject]
        protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }

        [Inject]
        protected IClasContrat oContratService { set; get; }


        [Inject]
        protected ITCl550Branch oTCl550BranchService { set; get; }
        [Inject]
        protected ITCl550Branch oTCl550BranchServiceTwo { set; get; }

        public List<ClassTCl550Branch> oTCl550BranchList { set; get; }
        public List<ClassTCl550Branch> oTCl550BranchListTwo { set; get; }



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
        [Inject]
        protected ITSc551SubBranch oTCl550SubBranchServiceTwo { set; get; }
        public List<TSc551SubBranch> oTCl550SubBranchList { set; get; }
        public List<TSc551SubBranch> oTCl550SubBranchListTwo { set; get; }

        [Inject]
        private ITabPrmNivOne oTabPrmNivOneService { set; get; }
        public List<TabPrmNivOne> TRH550CategContratList { set; get; }
        public List<TabPrmNivOne> TRH550TypeSalaireList { set; get; }

        public List<TabPrmNivOne> TRH550StatusContratList { set; get; }


        [Parameter]
        public string id { set; get; }
        public TRH05Mutation oOneMutation { set; get; }

        public List<TRH05Mutation> oTRH05MutationList { set; get; }
        [Inject]
        protected ITRH05Mutation oTRH05MutationService { set; get; }



        [Inject]
        public ITabPrmNivOne oDonBaseService { set; get; }

        public List<TabPrmNivOne> oContractStatusList { set; get; }
        // Add these new properties
        public List<TSc551SubBranch> oTCl550SubBranchListFiltered { set; get; }
        public List<TSc551SubBranch> oTCl550SubBranchListFilteredTwo { set; get; }

        // Original list to keep the full data
        private List<TSc551SubBranch> oTCl550SubBranchListOriginal { set; get; }
        private List<TSc551SubBranch> oTCl550SubBranchListTwoOriginal { set; get; }

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

        
        protected async Task ShowPopUp(int tPAction)
        {
            if (tPAction == 0)
            {
                modalTitle = " Mutation ";
            }


            if (tPAction != 1)
            {
                pSubBranchID = oOneMutation.SBranchFromID;
                pBranchID = pSubBranchID.Substring(0, 2);

                pSubBranchIDTo = oOneMutation.SBranchToID;
                pBranchIDTo = pSubBranchIDTo.Substring(0, 2);
            }

            if (tPAction == 2)
            {
                modalTitle = "Modifeir Mutation Details";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
            }
            else if (tPAction == 3)
            {
                modalTitle = "Supprimer Mutation Detail";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";
                oOneMutation.LModifBy = int.Parse(osessionService.UserId);
                oOneMutation.LModifOn = DateTime.Now;
                oOneMutation.Matricule = sMatricule;
            }

            if (tPAction == 1)
            {
                modalTitle = "Ajouter Mutation";
                StyleButton = "btn btn-sm btn-primary";
                ButtonCaption = "Ajouter";
                iTypeAction = tPAction;

                if (oOneMutation == null || string.IsNullOrEmpty(oOneMutation.Matricule))
                {
                    oOneMutation = new TRH05Mutation();
                    oOneMutation.ID = 0;
                    oOneMutation.Matricule = sMatricule;
                    oOneMutation.CreatBy = int.Parse(osessionService.UserId);
                    oOneMutation.CreatOn = DateTime.Now;
                    oOneMutation.FunctionID = 0;
                    oOneMutation.StatusID = 1;
                    oOneMutation.DateMut = DateTime.Today;
                    oTCl550SubBranchListFiltered = new List<TSc551SubBranch>();
                    oTCl550SubBranchListFilteredTwo = new List<TSc551SubBranch>();
                }
            }

            popup = true;
        }

        public bool AgentSelected { set; get; } = false;

        public int AgentID { set; get; }
        public decimal SalaireBase { set; get; }
        public string sNomAgent { set; get; }

        
        public void BackToAgent()
        {
            AgentSelected = false;

        }

        protected void ClosePopUp()
        {
            popup = false;
        }

        protected async Task ValidateData(int id)
        {
            try
            {
                var param = new ParamValidMutation
                {
                    ID = id,
                    UserID = int.Parse(osessionService.UserId)
                };
                //await JSRuntime.InvokeVoidAsync("alert", $"ID: {param.ID}, UserID: {param.UserID}");

             
                var result = await oTRH05MutationService.ValiderMutation(param);
                await JSRuntime.InvokeVoidAsync("alert", "Message" + result.Result);
                
                oContratList = await oContratService.GetContractByMatricule(sMatricule);
                oTRH02AgentList = await oTRH02AgentService.GetAgentByMatricule(sMatricule);

                if (oTRH02AgentList.Count > 0)
                {
                    sNomPrenom = oTRH02AgentList[0].Nom.Trim() + " " + oTRH02AgentList[0].Prenom.Trim();
                    oTRH05MutationList = await oTRH05MutationService.GetList(sMatricule);


                }

            }
            catch (Exception ex)
            {
                await JSRuntime.InvokeVoidAsync("alert", $"An error occurred: {ex.Message}");
                Console.WriteLine($"Error in ValidateData: {ex}");
            }
        }

        protected void EditData(TRH05Mutation item, int TpAction)
        {

            iTypeAction = TpAction;
            oOneMutation = item;

            ShowPopUp(iTypeAction);

        }



        Resultat oResultat = new Resultat();

        protected async Task SaveMutation(TRH05Mutation item)
        {



            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment supprimer ceci ??"))
                    return;
            }
            else if (oOneMutation.RaisonMut == "" || oOneMutation.RaisonMut == null)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Raison est obligatoire");
                return;
            }
            else if (oOneMutation.SBranchToID == null || oOneMutation.SBranchToID == "0")
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Guichet de destination est obligatoire");
                return;
            }
            else if (oOneMutation.SBranchFromID == null || oOneMutation.SBranchFromID == "0")
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Guichet d’origine est obligatoire");
                return;
            }
            else if (oOneMutation.FunctionID == 0 )
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Fonction est obligatoire");
                return;
            }




            try
            {


                oOneMutation.TpMaj = iTypeAction;
                //oOneMutation.UserId = osessionService.UserId;
                oResultat = new Resultat();

                oResultat = await oTRH05MutationService.GetUpdateResult(item);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
                //oContratList = await oContratService.GetContractByMatricule(id);
                oTRH05MutationList = await oTRH05MutationService.GetListAll();

                oTRH02AgentList = await oTRH02AgentService.GetAgentByMatricule(sMatricule);

                if (oTRH02AgentList.Count > 0)
                {
                    sNomPrenom = oTRH02AgentList[0].Nom.Trim() + " " + oTRH02AgentList[0].Prenom.Trim();
                    oTRH05MutationList = await oTRH05MutationService.GetList(sMatricule);

                }


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

        public void DonAgentSuite(ClasContrat pContrat)
        {
            var agent = oTRH02AgentList?.FirstOrDefault(a => a.Matricule == pContrat.MATRICULE);

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

        public string CurrencyFormat { set; get; } = "###,##0";

        public string sNomRecherche { set; get; }


        public string TypeAffichage { set; get; }
        public void ParamAgent()
        {
            TypeAffichage = "AgentUniquement";
        }

        public string sNomPrenom { set; get; }


        public async Task GoBack()
        {
            await JSRuntime.InvokeVoidAsync("history.back");
        }


        public string pBranchID = "";
        public string pSubBranchID = "";

        public void BranchChanged(string Value)
        {
            pBranchID = Value;
            //pSubBranchID = "0"; // Reset SubBranch selection
            //oOneMutation.SBranchFromID = "0";

            if (!string.IsNullOrEmpty(pBranchID) && pBranchID != "0")
            {
                oTCl550SubBranchListFiltered = oTCl550SubBranchListOriginal
                    .Where(row => row.CodeBranch.Trim() == pBranchID.Trim())
                    .ToList();
            }
            else
            {
                oTCl550SubBranchListFiltered = new List<TSc551SubBranch>();
            }
        }

        public void SubBranchChanged(string Value)
        {
            pSubBranchID = Value;
            oOneMutation.SBranchFromID = pSubBranchID;
        }

        public string pBranchIDTo = "";
        public string pSubBranchIDTo = "";

        public void BranchChangedTo(string Value)
        {
            pBranchIDTo = Value;
            //pSubBranchIDTo = "0"; // Reset SubBranch selection
            //oOneMutation.SBranchToID = "0";

            if (!string.IsNullOrEmpty(pBranchIDTo) && pBranchIDTo != "0")
            {
                oTCl550SubBranchListFilteredTwo = oTCl550SubBranchListTwoOriginal
                    .Where(row => row.CodeBranch.Trim() == pBranchIDTo.Trim())
                    .ToList();
            }
            else
            {
                oTCl550SubBranchListFilteredTwo = new List<TSc551SubBranch>();
            }
        }

        public void SubBranchChangedTo(string Value)
        {
            pSubBranchIDTo = Value;
            oOneMutation.SBranchToID = pSubBranchIDTo;
        }

        public string sMatricule { set; get; }


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
                    oTRH05MutationList = await oTRH05MutationService.GetList(sMatricule);
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

        //end of search by metricule

        public bool bAddDisabled { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");

            try
            {
                oTCl550FonctionList = await oTCl550FonctionService.GetTCl550Fonction();
                oTCl550UserList = await oTCl550UserService.GetList();

                oTCl550BranchList = await oTCl550BranchService.GetT550Branch();
                oTCl550SubBranchList = await oTCl550SubBranchService.GetList();
                oTCl550SubBranchListOriginal = oTCl550SubBranchList.ToList(); // Store original
                oTCl550SubBranchListFiltered = new List<TSc551SubBranch>(); // Initialize empty

                oTCl550BranchListTwo = await oTCl550BranchServiceTwo.GetT550Branch();
                oTCl550SubBranchListTwo = await oTCl550SubBranchServiceTwo.GetList();
                oTCl550SubBranchListTwoOriginal = oTCl550SubBranchListTwo.ToList(); // Store original
                oTCl550SubBranchListFilteredTwo = new List<TSc551SubBranch>(); // Initialize empty


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
