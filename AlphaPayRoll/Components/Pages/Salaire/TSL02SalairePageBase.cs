 using AlphaPayRoll.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.Cl550Branch;
using PayLibrary.CONTRACT_GOMISE;
using PayLibrary.Contrat;
using PayLibrary.InterfParamSec;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.Salaire;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TCl550Fonction;
using PayLibrary.TRH02Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaPayRoll.Components.Pages.Salaire
{
    public class TSL02SalairePageBase : ComponentBase
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
        public TSL02Salaire oOneSalaire { set; get; }

        public List<TSL02Salaire> oTSL02SalaireList { set; get; }
        [Inject]
        protected ITSL02Salaire oTSL02SalaireService { set; get; }



        [Inject]
        public ITabPrmNivOne oDonBaseService { set; get; }

        public List<TabPrmNivOne> oContractStatusList { set; get; }

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
                modalTitle = " Salaire Detail";
            }

            if (tPAction == 2)
            {
                modalTitle = "Modifier Salaire Detail";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
            }
            else if (tPAction == 3)
            {
                modalTitle = "Supprimer Salaire Detail";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";
                oOneSalaire.LModifBy = int.Parse(osessionService.UserId);
                oOneSalaire.LModifOn = DateTime.Now;
                oOneSalaire.Matricule = sMatricule;
            }

            // Handle GuichetID population for both view (0) and edit (2) modes
            if (tPAction == 0 || tPAction == 2)
            {
                // Convert GuichetID (int?) to string safely
                string guichetStr = "0"+oOneSalaire.GuichetID?.ToString();
                //await JSRuntime.InvokeVoidAsync("alert", guichetStr);

                // Check it is not null and has at least 2 characters
                if (!string.IsNullOrEmpty(guichetStr) && guichetStr.Length >= 2)
                {
                    // Extract branch (first 2 characters)
                    pBranchIDTo = guichetStr.Substring(0, 2);

                    // Full value for sub-branch// nda na
                    pSubBranchIDTo = guichetStr;

                    // Load sub-branches for the selected branch
                    oTCl550SubBranchListTwo = oTCl550SubBranchListTwoOriginal
                        .Where(row => row.CodeBranch != null && row.CodeBranch.Trim() == pBranchIDTo.Trim())
                        .ToList();
                } 
                else
                {
                    // Reset to defaults if no valid GuichetID
                    //pBranchIDTo = "0";
                    //pSubBranchIDTo = "0";
                    oTCl550SubBranchListTwo = new List<TSc551SubBranch>();
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

      
        protected void EditData(TSL02Salaire item, int TpAction)
        {

            iTypeAction = TpAction;
            oOneSalaire = item;

            ShowPopUp(iTypeAction);

        }



        Resultat oResultat = new Resultat();

        protected async Task SaveSalaire(TSL02Salaire item)
        {



            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment supprimer ceci ??"))
                    return;
            }



            try
            {


                oOneSalaire.TpMaj = iTypeAction;
                //oOneSalaire.UserId = osessionService.UserId;

                oResultat = new Resultat();

                oResultat = await oTSL02SalaireService.GetUpdateResult(item);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
                //oContratList = await oContratService.GetContractByMatricule(id);
                oTSL02SalaireList = await oTSL02SalaireService.GetSalaireAll();
   
                oTRH02AgentList = await oTRH02AgentService.GetAgentByMatricule(sMatricule);

                if (oTRH02AgentList.Count > 0)
                {
                    sNomPrenom = oTRH02AgentList[0].Nom.Trim() + " " + oTRH02AgentList[0].Prenom.Trim();
                    oTSL02SalaireList = await oTSL02SalaireService.GetSalaire(sMatricule);

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

        // Keep original lists intact
        private List<TSc551SubBranch> oTCl550SubBranchListOriginal = new List<TSc551SubBranch>();

        public void BranchChanged(string Value)
        {
            pBranchID = Value;
            oOneSalaire.BranchCpteID = pBranchID;

            // Filter sub-branches based on selected branch
            if (!string.IsNullOrEmpty(pBranchID) && pBranchID != "0")
            {
                oTCl550SubBranchList = oTCl550SubBranchListOriginal
                    .Where(row => row.CodeBranch != null && row.CodeBranch.Trim() == pBranchID.Trim())
                    .ToList();
            }
            else
            {
                oTCl550SubBranchList = new List<TSc551SubBranch>();
            }

            // Reset sub-branch selection
            pSubBranchID = "0";
            oOneSalaire.SBranchCpteID = "0";

            StateHasChanged();
        }

        public void SubBranchChanged(string Value)
        {
            pSubBranchID = Value;
            oOneSalaire.SBranchCpteID = pSubBranchID;
            StateHasChanged();
        }

         public string pBranchIDTo = "0";
        public string pSubBranchIDTo = "0";

        // Keep original lists intact for second set
        private List<TSc551SubBranch> oTCl550SubBranchListTwoOriginal = new List<TSc551SubBranch>();

        public void BranchChangedTo(string Value)
        {
            pBranchIDTo = Value;
            oOneSalaire.GuichetID = string.IsNullOrEmpty(pBranchIDTo) ? (int?)null : int.Parse(pBranchIDTo); ;

            // Filter sub-branches based on selected branch
            if (!string.IsNullOrEmpty(pBranchIDTo) && pBranchIDTo != "0")
            {
                oTCl550SubBranchListTwo = oTCl550SubBranchListTwoOriginal
                    .Where(row => row.CodeBranch != null && row.CodeBranch.Trim() == pBranchIDTo.Trim())
                    .ToList();
            }
            else
            {
                oTCl550SubBranchListTwo = new List<TSc551SubBranch>();
            }

            // Reset sub-branch selection
            pSubBranchIDTo = "0";
            oOneSalaire.BanqPaySalaire = 0;

            StateHasChanged();
        }

        public void SubBranchChangedTo(string Value)
        {
            pSubBranchIDTo = Value;
            oOneSalaire.BanqPaySalaire = Convert.ToInt32(pSubBranchIDTo);
            StateHasChanged();
        }

        //=================================================================================

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
                    oTSL02SalaireList = await oTSL02SalaireService.GetSalaire(sMatricule);

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
            try
            {
                
                oTCl550FonctionList = await oTCl550FonctionService.GetTCl550Fonction();

                oTCl550BranchList = await oTCl550BranchService.GetT550Branch();
                oTCl550SubBranchList = await oTCl550SubBranchService.GetList();
                oTCl550SubBranchListOriginal = oTCl550SubBranchList.ToList(); 
                oTCl550BranchListTwo = await oTCl550BranchServiceTwo.GetT550Branch();
                oTCl550SubBranchListTwo = await oTCl550SubBranchServiceTwo.GetList(); // UNCOMMENT THIS
                oTCl550SubBranchListTwoOriginal = oTCl550SubBranchListTwo.ToList(); // UNCOMMENT THIS
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
