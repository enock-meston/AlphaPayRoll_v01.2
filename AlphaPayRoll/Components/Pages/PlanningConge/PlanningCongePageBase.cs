using AlphaPayRoll.Data;
using AlphaPayRoll.DataServices.Contrat;
using AlphaPayRoll.DataServices.DonBase;
using AlphaPayRoll.DataServices.TCl550Fonction;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.Cl550Branch;
using PayLibrary.CongeRequestF;
using PayLibrary.CONTRACT_GOMISE;
using PayLibrary.Contrat;
using PayLibrary.InterfParamSec;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.PlanningConge;
using PayLibrary.TCl550Fonction;
using PayLibrary.TRH02Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AlphaPayRoll.Components.Pages.PlanningConge
{
    public class PlanningCongePageBase : Microsoft.AspNetCore.Components.ComponentBase
    {


        [Inject]
        public NavigationManager NavMager { get; set; }

        [Inject]
        public ITHRPlanningConge oPlanningCongeService { get; set; }

        public List<THRPlanningConge> oPlanningCongeList { get; set; }

        public List<TpConge> TpCongeList { get; set; } = new List<TpConge>();
        public List<THRPlanningConge> PlanningList { get; set; } = new List<THRPlanningConge>();
        public List<StatReq> StatusList { get; set; } = new List<StatReq>();

        public THRPlanningConge oOneActiveCongeRequest { get; set; }
        public THRPlanningConge OneCongeRequest { get; set; } = new THRPlanningConge();
        public Resultat oResult { get; set; }

        [Inject]
        protected ITCl550Branch oTCl550BranchService { set; get; }
        public List<ClassTCl550Branch> oTCl550BranchList { set; get; }
        public List<TSc551SubBranch> oTCl550SubBranchList2 { set; get; }
        [Inject]
        protected ITSc551SubBranch oTCl550SubBranchService { set; get; }
        public List<TSc551SubBranch> oTCl550SubBranchList { set; get; }
        [Inject]
        public ITabPrmNivOne oDonBaseService { set; get; }
        [Inject]
        protected ITSc551User oTCl550UserService { set; get; }
        public List<TSc551User> oTCl550UserList { set; get; }
        public List<TSc551User> oTCl550UserListSearch { set; get; }

        [Inject]
        protected ITCl550Fonction oTCl550FonctionService { set; get; }
        public List<ClassTCl550Fonction> oTCl550FonctionList { set; get; }
        
        public List<ClassTRH02Agent> oTRH02SelectAgentList { get; set; } = new List<ClassTRH02Agent>();
        public string sSelectedPerson { get; set; }
        public int sSelectedPersonChef { get; set; }

        public string TestMes { get; set; } = "";

        [Inject]
        protected IClasContrat oContratService { set; get; }

        private int pTypeAction = 0;

        [Parameter]
        public string id { get; set; }

        public int currentCount = 0;
        public bool isLoading { set; get; } = true;

        public bool popup { get; set; } = false;
        public int iTypeAction { get; set; }
        public bool showAddRequestForm = false;

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        //[Inject]
        //protected SessionService osessionService { get; set; }

        public ClasSessionStorage osessionService { set; get; }

        [Inject]
        protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }


        [Inject]
        protected ITRH02Agent oTRH02AgentService { set; get; }
        public List<ClassTRH02Agent> oTRH02AgentList { set; get; }
        public ClassTRH02Agent oOneTRH02Agent { set; get; }
        public List<TabPrmNivOne> oTPR550Exercice { set; get; }
        [Inject]
        private ITabPrmNivOne oTabPrmNivOneService { set; get; }
        public List<TabPrmNivOne> oContractStatusList { set; get; }


        public List<ClasContrat> oContratList { set; get; }

        public bool AgentSelected { set; get; } = false;

        public int AgentID { set; get; }
        public decimal SalaireBase { set; get; }
        public string sNomAgent { set; get; }
        public string sNomPrenom { set; get; }
        public string sMatricule { set; get; }

        public int Day_CongRetard { set; get; }
        public int Day_CongCurrentYear { set; get; }
        public int Day_CongPris { set; get; }
        public int Day_CongRest { set; get; }

        public bool aValidePlanning { set; get; } = true;

        public bool bHRApprovMois { get; set; } = true;
        //public bool bDgApprov { get; set; } = true;
        public bool bChefApprov { get; set; } = true;
        public bool bEmployee { get; set; } = false;

        public void DonAgentSuite(THRPlanningConge pConge)
        {
            //var agent = oTRH02AgentList?.FirstOrDefault(a => a.Matricule == pConge.MATRICULE);

            //if (agent != null)
            //{
            //    DonAgentSuite(agent);
            //}
        }

        public void DonAgentSuite(ClassTRH02Agent pAgent)
        {
            AgentID = pAgent.AgentId;
            SalaireBase = pAgent.SalBase;
            AgentSelected = true;
            sNomAgent = pAgent.Nom.Trim() + " " + pAgent.Prenom.Trim();
        }
        public void BackToAgent()
        {
            AgentSelected = false;

        }

        public string getRowColor(int i)
        {
            return (i % 2 == 0) ? "table-info" : "table-light";
        }


        protected void EditData(THRPlanningConge item, int TpAction)
        {
            iTypeAction = TpAction;
            oOneActiveCongeRequest = item;

            if (TpAction == 2 || TpAction == 0) // Edit or View
            {
                OneCongeRequest = new THRPlanningConge
                {
                    ID = item.ID,
                    Matricule = item.Matricule,
                    SBranchID = item.SBranchID,
                    CreatOn = item.CreatOn,
                    CreatBy = item.CreatBy,
                    LModifBy = item.LModifBy,
                    LModifOn = item.LModifOn,
                    UserID = int.Parse(osessionService.UserId),
                    TpMaj = TpAction

                };

                if (!string.IsNullOrEmpty(item.SBranchID) && item.SBranchID.Length >= 3)
                {
                    //pBranchID = item.SBranchID.Substring(0, 3);
                    //pSubBranchID = item.SBranchID;
                    // Load sub-branches for the selected branch
                    oTCl550SubBranchList = oTCl550SubBranchList2
                        .Where(row => row.CodeBranch.Trim() == pBranchID.Trim())
                        .ToList();
                }
            }

            ShowPopUp(TpAction);
        }

        Resultat oResultat = new Resultat();

      
        public void IncrementCount()
        {
            currentCount++;
        }


        public string modalTitle { get; set; }
        public string StyleButton { get; set; }
        public string ButtonCaption { get; set; }

        protected async Task ShowPopUp(int tPAction)
        {
            if (osessionService.RoleID == 3)
            {
                bHRApprovMois = false;
            }
            

            if (osessionService.RoleID == 2)
            {
                bChefApprov = false;
            }

            if (tPAction == 0)
            {
                modalTitle = "Planifier congé ";
                StyleButton = "";
                ButtonCaption = "";
            }
            else if (tPAction == 2)
            {
                modalTitle = " Planifier congé";
                StyleButton = "btn btn-sm btn-primary";
                ButtonCaption = "Sauvegarder";
                //oOneActiveCongeRequest.NumTranche = iNumTranche;
                
            }
            else if (tPAction == 3)
            {
                modalTitle = "Supprimer Planifier congé";
                StyleButton = "btn btn-sm btn-danger";                                                                                           
                ButtonCaption = "Supprimer";

                oOneActiveCongeRequest.LModifBy = int.Parse(osessionService.UserId);
                oOneActiveCongeRequest.LModifOn = DateTime.Now;
                
            }
            else if (tPAction == 1) // Add new
            {

                if (iNumTranche==0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Impossible d ajouter une nouvelle tranche(Max 3)");
                    return;
                }

                bDisableChefDirect = true;
                bDisableHR = true;
                //bDisableDG = true;

                modalTitle = "Ajouter Planifier Congé";
                StyleButton = "btn btn-sm btn-primary";
                ButtonCaption = "Sauvegarder";

                iTypeAction = tPAction;

                pSubBranchID = osessionService.BranchID;

                pBranchID = pSubBranchID.Substring(0,2);

                //await JSRuntime.InvokeVoidAsync("alert", pSubBranchID);
                //await JSRuntime.InvokeVoidAsync("alert", pBranchID);
                oOneActiveCongeRequest = new THRPlanningConge();


                oOneActiveCongeRequest.ID = 0;
                oOneActiveCongeRequest.Matricule = sMatricule;
                oOneActiveCongeRequest.TpMaj = 1;
                oOneActiveCongeRequest.UserID = int.Parse(osessionService.UserId);
                oOneActiveCongeRequest.CreatOn = DateTime.Now;
                oOneActiveCongeRequest.LModifOn = DateTime.Now;
                oOneActiveCongeRequest.CreatBy = int.Parse(osessionService.UserId);
                oOneActiveCongeRequest.Exercice = sExerciceID;
                oOneActiveCongeRequest.NumTranche = iNumTranche;
                oOneActiveCongeRequest.SBranchID = osessionService.BranchID;
                if (iNumTranche == 3) {
                    oOneActiveCongeRequest.ProposNbreJour = @ResteCongeTranche;
                        }
            }

            // For Edit and View modes, populate the branch and sub-branch dropdowns
            if (tPAction == 0 || tPAction == 2)
            {
                if (!string.IsNullOrEmpty(oOneActiveCongeRequest.SBranchID) &&
                    oOneActiveCongeRequest.SBranchID.Length >= 3)
                {
                    pSubBranchID = oOneActiveCongeRequest.SBranchID;
                    pBranchID = oOneActiveCongeRequest.SBranchID.Substring(0, 2); // Get first 3 characters

                    // Load sub-branches for the selected branch
                    oTCl550SubBranchList = oTCl550SubBranchList2
                        .Where(row => row.CodeBranch.Trim() == pBranchID.Trim())
                        .ToList();
                }
            }

            popup = true;
        }

        

        protected void ClosePopUp()
        {
            popup = false;
        }

        public async Task GoBack()
        {

            string sChemin = osessionService.sApp + "/GcongeIndex";

            NavMager.NavigateTo(sChemin, true);
        }
        public string pBranchID = "";
        public string pSubBranchID = "";

        public void BranchChanged(string Value)
        {
            pBranchID = Value;
            oTCl550SubBranchList = oTCl550SubBranchList2.Where(row => row.CodeBranch.Trim() == pBranchID.Trim()).ToList();
        }

        public void SubBranchChanged(string Value)
        {
            pSubBranchID = Value;
            oOneActiveCongeRequest.SBranchID = pSubBranchID;
        }


        public async Task SaveData(THRPlanningConge item)
        {
            try
            {
                 
              if (iTypeAction == 3)
                {
                    bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm",
                        "Voulez-vous vraiment supprimer cette demande de congé?");
                    if (!confirmed)
                        return;
                }
                else if (oOneActiveCongeRequest.ProposMois == "")
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Le Propos Mois est obligatoire");
                    return;
                }
                else if (oOneActiveCongeRequest.SBranchID == null)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Le Guiche obligatoire");
                    return;
                }
                else if (oOneActiveCongeRequest.ProposNbreJour == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Le Propos Nbre Jour est obligatoire");
                    return;
                }

                

                // Use oOneActiveCongeRequest instead of item or OneCongeRequest
                oOneActiveCongeRequest.TpMaj = iTypeAction;
                oOneActiveCongeRequest.UserID = int.Parse(osessionService.UserId);
                //if (Day_CongRest < oOneActiveCongeRequest.ProposNbreJour)
                //{
                //    await JSRuntime.InvokeVoidAsync("alert", "Le nombre de jours proposés ne doit pas être supérieur au nombre de jours restants.");
                //}
                if (iTypeAction == 2)
                {
                    oOneActiveCongeRequest.LModifBy = int.Parse(osessionService.UserId);
                    oOneActiveCongeRequest.LModifOn = DateTime.Now;
                    //oOneActiveCongeRequest.NumTranche = iNumTranche;
                    //await JSRuntime.InvokeVoidAsync("alert", iNumTranche);


                }
                else if (iTypeAction == 1) // For new records
                {
                    oOneActiveCongeRequest.CreatBy = int.Parse(osessionService.UserId);
                    oOneActiveCongeRequest.CreatOn = DateTime.Now;
                    oOneActiveCongeRequest.LModifOn = DateTime.Now;
                    oOneActiveCongeRequest.NumTranche = iNumTranche;
                }

                // Pass oOneActiveCongeRequest instead of OneCongeRequest
                oResult = await oPlanningCongeService.UpdatePlanningConge(oOneActiveCongeRequest);

                if (oResult != null && !string.IsNullOrEmpty(oResult.Result))
                {
                    await JSRuntime.InvokeVoidAsync("alert", oResult.Result);
                    searchByMatricule();
                }

                // Refresh the list
                oPlanningCongeList = await oPlanningCongeService.GetAllPlanningConge();

                // Filter by matricule if search was performed
                if (!string.IsNullOrWhiteSpace(sMatricule))
                {
                    oPlanningCongeList = oPlanningCongeList.Where(a => a.Matricule == sMatricule).ToList();
                }

                // Close popup if successful
                if (oResult != null && oResult.Result.Contains("success", StringComparison.OrdinalIgnoreCase) ||
                    oResult.Result.Contains("Successfully", StringComparison.OrdinalIgnoreCase) ||
                    oResult.Result.Contains("Updated", StringComparison.OrdinalIgnoreCase) ||
                    oResult.Result.Contains("Deleted", StringComparison.OrdinalIgnoreCase))
                {
                    ClosePopUp();
                }

                StateHasChanged();

                TotalCongeTranche = 0;
                foreach (var otranche in oPlanningCongeList)
                {
                    TotalCongeTranche = TotalCongeTranche + otranche.ProposNbreJour;

                }
                ResteCongeTranche = Day_CongCurrentYear - TotalCongeTranche;



            }
            catch (Exception ex)
            {
                await JSRuntime.InvokeVoidAsync("alert", $"Erreur: {ex.Message}");
            }
        }


        public async Task searchByMatricule()
        {
            if (string.IsNullOrWhiteSpace(sMatricule))
            {
                await JSRuntime.InvokeVoidAsync("alert", "Veuillez entrer un matricule.");
                return;
            }
            //==========================
            var param = new ParamNumTranche
            {
                Matricule = sMatricule
            };
           
            var resultNumTranche = await oPlanningCongeService.GetNumTranche(param);
            
            //==========================
            try
            {
                isLoading = true;
                StateHasChanged();
                oTRH02AgentList = await oTRH02AgentService.GetAgentByMatricule(sMatricule);
                // iyi list iri kwa affectinga nuko ba agent bari kwishakisha
                if (osessionService.RoleID != 1)
                {
                    oTRH02AgentList = oTRH02AgentList.Where(a => a.validPlanning == true).ToList(); // 
                }

                if (oTRH02AgentList != null && oTRH02AgentList.Count > 0)
                {
                    sNomPrenom = oTRH02AgentList[0].Nom.Trim() + " " + oTRH02AgentList[0].Prenom.Trim();
                    aValidePlanning = oTRH02AgentList[0].validPlanning;
                    //day conge
                    ///Day_CongRetard = oTRH02AgentList[0].CongRetard;
                    
                    Day_CongCurrentYear = oTRH02AgentList[0].CongCurrentYear+ oTRH02AgentList[0].CongRetard;
                    //Day_CongPris = oTRH02AgentList[0].CongPris;
                    //Day_CongRest = oTRH02AgentList[0].CongRest;

                    // end day conge
                    if (osessionService.RoleID == 2 || osessionService.RoleID == 3)
                    {
                        int.TryParse(resultNumTranche.Result, out int tranche);
                        
                            iNumTranche = tranche;
                        
                        oPlanningCongeList = await oPlanningCongeService.GetAllPlanningConge();
                        bDisableChefDirect = false;
                        if (osessionService.RoleID == 1)
                        {
                            aValidePlanning = false;
                            oPlanningCongeList = oPlanningCongeList.Where(a => (a.Matricule == sMatricule)).ToList();
                            //await JSRuntime.InvokeVoidAsync("alert","1");
                            return;
                        }

                       

                        if (osessionService.RoleID == 2)
                        {
                            aValidePlanning = false;
                            oPlanningCongeList = oPlanningCongeList.Where(a => (a.Matricule == sMatricule)).ToList();
                        //await JSRuntime.InvokeVoidAsync("alert", "2");
                          }

                        // check if chef status is yes and show data to HR
                        if (osessionService.RoleID == 3)
                        {
                            aValidePlanning = false;
                            oPlanningCongeList = oPlanningCongeList.Where(a => (a.Matricule == sMatricule && a.StatusChefD == "Yes")).ToList();
                            //await JSRuntime.InvokeVoidAsync("alert","1");
                            //return;
                        }

                        bAddDisabled = false;
                        aValidePlanning = false;
                        return;

                    }

                    if (osessionService.RoleID == 1)
                    {
                        int.TryParse(resultNumTranche.Result, out int tranche);
                        
                            iNumTranche = tranche;
                       
                            oPlanningCongeList = await oPlanningCongeService.GetAllPlanningConge();
                            bDisableChefDirect = false;
                            oPlanningCongeList = oPlanningCongeList.Where(a => (a.Matricule == sMatricule)).ToList();
                            
                        
                        bAddDisabled = false;
                        return;

                    }
                    else
                    {
                       
                        if (int.TryParse(resultNumTranche.Result, out int tranche))
                        {
                            iNumTranche = tranche;
                        }
                        else
                        {
                            //await JSRuntime.InvokeVoidAsync("alert", "Me: " + resultNumTranche.Result);
                            oPlanningCongeList = await oPlanningCongeService.GetAllPlanningConge();
                            bDisableChefDirect = false;
                            oPlanningCongeList = oPlanningCongeList.Where(a => (a.Matricule == sMatricule)).ToList();
                            //await JSRuntime.InvokeVoidAsync("alert", "3");
                            StateHasChanged();
                            return;

                        }
                        bAddDisabled = false;
                    }
    
                }
                else
                {
                    bAddDisabled = true;
                    await JSRuntime.InvokeVoidAsync("alert",
                        $"Aucun agent trouvé avec le matricule: {sMatricule}");
                    oPlanningCongeList = new List<THRPlanningConge>();
                }


                //oPlanningCongeList = await oPlanningCongeService.GetAllPlanningConge();

                //// Filter by matricule if search was performed
                //if (!string.IsNullOrWhiteSpace(sMatricule))
                //{
                //    oPlanningCongeList = oPlanningCongeList.Where(a => a.Matricule == sMatricule).ToList();
                //}


                TotalCongeTranche = 0;
                foreach (var otranche in oPlanningCongeList)
                {
                    TotalCongeTranche = TotalCongeTranche + otranche.ProposNbreJour;

                }
                ResteCongeTranche = Day_CongCurrentYear - TotalCongeTranche;


            }
            catch (Exception ex)
            {
                await JSRuntime.InvokeVoidAsync("alert", $"Erreur lors de la recherche: {ex.Message}");
            }
            finally
            {
                isLoading = false;
                StateHasChanged();
            }
        }

        public async Task searchByAgentChef(int value)
        {
            string pSubBranchID = "001";
            //await JSRuntime.InvokeVoidAsync("alert", pSubBranchID);
            sSelectedPersonChef = value;
            //await JSRuntime.InvokeVoidAsync("alert", sSelectedPersonChef);
            //  ndaza  gufata value ya SIEGE nyikoreshe shaka aba USER baba Chef
            oTCl550UserListSearch = await oTCl550UserService.GetList();
            oTCl550UserListSearch = oTCl550UserListSearch
                                    .Where(row => row.RoleID == 2 && row.BranchID.ToString("D3") == pSubBranchID)
                                    .ToList();
            //==================

            //sSelectedPerson = string.Empty;

            var param = new ParamAgentByChef
            {
                ChefID = int.Parse(osessionService.UserId),
                SBranch = pSubBranchID,
                RoleID = osessionService.RoleID
            };

            oTRH02SelectAgentList = await oTRH02AgentService.GetAgentByChef(param);

            oTRH02SelectAgentList = oTRH02SelectAgentList.Where(a => a.validPlanning == true && a.ChefID== sSelectedPersonChef).ToList();
            //==================

            //sSelectedPersonChef = 0;
            StateHasChanged();
        }

        public async Task BranchRechercherPersonal(string value)
        {
            pBranchID = value;

            // Filter sub-branches based on selected branch
            oTCl550SubBranchList = oTCl550SubBranchList2
                .Where(row => row.CodeBranch.Trim() == pBranchID.Trim())
                .ToList();


            if (oTCl550SubBranchList.Count == 1)
            {
                pSubBranchID = oTCl550SubBranchList[0].ID;

                var param = new ParamAgentByChef
                {
                    ChefID = int.Parse(osessionService.UserId),
                    SBranch = pSubBranchID,
                    RoleID = osessionService.RoleID
                };

                oTRH02SelectAgentList = await oTRH02AgentService.GetAgentByChef(param);
                oTRH02SelectAgentList = oTRH02SelectAgentList.Where(a => a.validPlanning == true).ToList();

                //========

                oTCl550UserListSearch = await oTCl550UserService.GetList();
                oTCl550UserListSearch = oTCl550UserListSearch
                                        .Where(row => row.RoleID == 2 && row.BranchID.ToString("D3") == pSubBranchID)
                                        .ToList();
                StateHasChanged();
            }


            pSubBranchID = string.Empty;
            sSelectedPerson = string.Empty;

            StateHasChanged();
        }

        public async Task SubBranchRechercherPersonal(string value)
        {
            pSubBranchID = value;
            sSelectedPerson = string.Empty;

            var param = new ParamAgentByChef
            {
                ChefID = int.Parse(osessionService.UserId),
                SBranch = pSubBranchID,
                RoleID = osessionService.RoleID
            };
            
            oTRH02SelectAgentList = await oTRH02AgentService.GetAgentByChef(param);

            oTRH02SelectAgentList = oTRH02SelectAgentList.Where(a => a.validPlanning == true).ToList();

            StateHasChanged();
        }

        public async Task SelectedPersonal(string value)
        {
            sSelectedPerson = value;

            if (!string.IsNullOrEmpty(value))
            {
                // Find the selected agent
                var selectedAgent = oTRH02SelectAgentList?.FirstOrDefault(a => a.AgentId.ToString() == value);
                //oTRH02SelectAgentList = oTRH02SelectAgentList.Where(a => a.validPlanning == true).ToList();

                if (selectedAgent != null)
                {
                    // Auto-fill the matricule and trigger search
                    sMatricule = selectedAgent.Matricule;
                    await searchByMatricule();
                    StateHasChanged();
                }
            StateHasChanged();
            }
        }

        public async Task ValidePlanningonge()
        {
            bool confirm = await JSRuntime.InvokeAsync<bool>(
                "confirm",
                "Are you sure you want to validate this planning?"
            );

            if (!confirm)
                return;

            var param = new ParamAgentMatricule
            {
                Matricule = sMatricule
            };

            var result = await oTRH02AgentService.ValidePlanningConge(param);
            if (result != null && !string.IsNullOrEmpty(result.Result))
            {
                await JSRuntime.InvokeVoidAsync("alert", result.Result);
            }

            searchByMatricule();
        }

        public bool bAddDisabled { get; set; } = true;


        public bool bDisableChefDirect { get; set; } = true;
        public bool bDisableHR { get; set; } = true;
        public bool bDisplayChefDir { get; set; } = false;
        public bool bDisplayHR { get; set; } = false;
        public string sExerciceID { get; set; } 
        public int iNumTranche { get; set; } = 0;


        public int TotalCongeTranche { get; set; } = 0;
        public int ResteCongeTranche { get; set; } = 0;

        protected override async Task OnInitializedAsync()
        {
            osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");

            try
            {
                oOneTRH02Agent = new ClassTRH02Agent();
                if (osessionService.RoleID == 1)
                {
                    oTRH02AgentList = await oTRH02AgentService.GetAgentByMatricule(osessionService.Matricule);
                    oTRH02AgentList= oTRH02AgentList.Where(a => a.validPlanning ==true).ToList(); 
                    bEmployee = true;
                    sMatricule = osessionService.Matricule;
                }

                oTCl550BranchList = await oTCl550BranchService.GetT550Branch();
                oTCl550SubBranchList2 = await oTCl550SubBranchService.GetList();
                oTPR550Exercice = (await oTabPrmNivOneService.GetDBListName("TPR550Exercice")).ToList();
                oTCl550BranchList = await oTCl550BranchService.GetT550Branch();
                oTCl550UserList = await oTCl550UserService.GetList();
                oTCl550FonctionList = await oTCl550FonctionService.GetTCl550Fonction();
                oTCl550SubBranchList = oTCl550SubBranchList2;
                oTPR550Exercice = oTPR550Exercice.Where(x => x.Enab == true).ToList();

                if (oTPR550Exercice.Count > 0)
                {
                    sExerciceID= oTPR550Exercice[0].RICode; 
                }


                oTCl550UserListSearch = await oTCl550UserService.GetList();
                oTCl550UserListSearch = oTCl550UserListSearch
                                        .Where(x => x.RoleID == 2)
                                        .ToList();


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