using AlphaPayRoll.Data;
using AlphaPayRoll.DataServices.Contrat;
using AlphaPayRoll.DataServices.DonBase;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Microsoft.Reporting.Map.WebForms.BingMaps;
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



namespace AlphaPayRoll.Components.Pages.CongeRequestF
{
    public class THRCongCircRequestBase : ComponentBase
    {


        [Inject]
        public NavigationManager NavMager { get; set; }


        [Inject]
        public ITHRCongCircRequest oCongeRequestsService { get; set; }

        public List<THRCongCircRequest> oCongeRequestsList { get; set; }

        public List<TpConge> TpCongeList { get; set; } = new List<TpConge>();
        public List<THRPlanningConge> PlanningList { get; set; } = new List<THRPlanningConge>();
        public List<StatReq> StatusList { get; set; } = new List<StatReq>();
        public List<TabPrmNivOne> oTPR550Exercice { set; get; }
        [Inject]
        private ITabPrmNivOne oTabPrmNivOneService { set; get; }
        public THRCongCircRequest oOneActiveCongeRequest { get; set; }
        public THRCongCircRequest OneCongeRequest { get; set; } = new THRCongCircRequest();
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


        [Inject]
        protected ITCl550Fonction oTCl550FonctionService { set; get; }
        public List<ClassTCl550Fonction> oTCl550FonctionList { set; get; }

        public string TestMes { get; set; } = "";

        [Inject]
        protected IClasContrat oContratService { set; get; }

        private int pTypeAction = 0;

        [Parameter]
        public int id { get; set; }

        public int currentCount = 0;
        public bool isLoading { set; get; } = true;

        public bool popup { get; set; } = false;
        public int iTypeAction { get; set; }
        public bool showAddRequestForm = false;

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }


        public ClasSessionStorage osessionService { set; get; }

        [Inject]
        protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }
        public List<ClassTRH02Agent> oTRH02SelectAgentList { get; set; } = new List<ClassTRH02Agent>();
        public string sSelectedPerson { get; set; }

        [Inject]
        protected ITRH02Agent oTRH02AgentService { set; get; }
        public List<ClassTRH02Agent> oTRH02AgentList { set; get; }
        public ClassTRH02Agent oOneTRH02Agent { set; get; }

        public List<TabPrmNivOne> TRH550StatusContratList { set; get; }
        public List<TabPrmNivOne> oCongeList { set; get; }


        public List<ClasContrat> oContratList { set; get; }


        [Inject]
        public ITHRPlanningConge oPlanningCongeService { get; set; }

        public List<THRPlanningConge> oPlanningCongeList { get; set; }


        public bool AgentSelected { set; get; } = false;

        public int AgentID { set; get; }
        public decimal SalaireBase { set; get; }
        public string sNomAgent { set; get; }
        public string sNomPrenom { set; get; }
        public string sMatricule { set; get; }
        public bool aValidePlanning { set; get; } = true;

        public void DonAgentSuite(THRCongCircRequest pConge)
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

        protected void EditData(THRCongCircRequest item, int TpAction)
        {
            iTypeAction = TpAction;
            oOneActiveCongeRequest = item;

            if (TpAction == 2 || TpAction == 0) // Edit or View
            {

                //await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);

                OneCongeRequest = new THRCongCircRequest
                {
                    ID = item.ID,
                    Matricule = item.Matricule,
                    NumTranche = item.NumTranche,
                    SBranchID = item.SBranchID,
                    PlanningID = item.PlanningID,
                    DateRequest = item.DateRequest,
                    DateDebutReq = item.DateDebutReq,
                    DateFinReq = item.DateFinReq,
                    DateDebutApprov = item.DateDebutApprov,
                    DateFinApprov = item.DateFinApprov,
                    NbrJour = item.NbrJour,
                    NbrJourApprov = item.NbrJourApprov,
                    NbrJAccord = item.NbrJAccord,
                    StatusChefID = item.StatusChefID,
                    StatusHRID = item.StatusHRID,
                    StatusDGID = item.StatusDGID,
                    RemChefD = item.RemChefD,
                    RemHR = item.RemHR,
                    RemDG = item.RemDG,
                    Exercice = sExerciceID,
                    CreatOn = item.CreatOn,
                    CreatBy = item.CreatBy,
                    LModifBy = item.LModifBy,
                    LModifOn = item.LModifOn,
                    UserID = int.Parse(osessionService.UserId),
                    TpMaj = TpAction

                };

                if (!string.IsNullOrEmpty(item.SBranchID) && item.SBranchID.Length >= 3)
                {
                    //pBranchID = item.SBranchID.Substring(0, 2);
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

        protected async Task SaveContrat(TRH04Affectation item)
        {



            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment supprimer ceci ?"))
                    return;
            }



            try
            {

                oOneActiveCongeRequest.TpMaj = iTypeAction;
                oOneActiveCongeRequest.UserID = int.Parse(osessionService.UserId);

                oResultat = new Resultat();

                oResultat = await oContratService.GetResutUpdateAffect(item);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
                
                oContratList = await oContratService.GetContractByMatricule(sMatricule);
                var param = new ParamAgentMatricule
                {
                    Matricule = sMatricule,
                    UserID = int.Parse(osessionService.UserId)
                };

                oTRH02AgentList = await oTRH02AgentService.GetAgentByMatriculeCongeReq(param);

                if (oTRH02AgentList.Count > 0)
                {
                    sNomPrenom = oTRH02AgentList[0].Nom.Trim() + " " + oTRH02AgentList[0].Prenom.Trim();
                    oCongeRequestsList = await oCongeRequestsService.GetAllCongeRequests();

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


        public async Task ValideCongeReq(int id)
        {
            bool confirm = await JSRuntime.InvokeAsync<bool>(
                "confirm",
                "Are you sure you want to validate this planning?"
            );

            if (!confirm)
                return;

            var param = new ParamMatricule
            {
                Matricule = sMatricule
            };

            var result = await oCongeRequestsService.ValideCongeRequest(param,id);
            if (result != null && !string.IsNullOrEmpty(result.Result))
            {
                await JSRuntime.InvokeVoidAsync("alert", result.Result);
            }

            searchByMatricule();

        }




        public void IncrementCount()
        {
            currentCount++;
        }


        public string modalTitle { get; set; }
        public string StyleButton { get; set; }
        public string ButtonCaption { get; set; }

        protected async Task ShowPopUp(int tPAction)
        {

            pSubBranchID = osessionService.BranchID;

            pBranchID = pSubBranchID.Substring(0, 2);



            if (tPAction != 1)
            {
                iNumTranche = oOneActiveCongeRequest.NumTranche;
            }



            if (tPAction == 0)
            {
                modalTitle = "Détails du congé de demande";
                StyleButton = "";
                ButtonCaption = "";
            }

            else if (tPAction == 2)
            {
                modalTitle = "Demande de congé de modification";
                StyleButton = "btn btn-sm btn-primary";
                ButtonCaption = "Sauvegarder";
                //await JSRuntime.InvokeVoidAsync("alert", OneCongeRequest.NumTranche);
                OneCongeRequest.NumTranche = iNumTranche;
            }
            else if (tPAction == 3)
            {
                modalTitle = "Supprimer Demande congé";
                StyleButton = "btn btn-sm btn-danger";
                ButtonCaption = "Supprimer";

                OneCongeRequest.LModifBy = int.Parse(osessionService.UserId);
                OneCongeRequest.LModifOn = DateTime.Now;

                OneCongeRequest.NbrJour = TotalDays;
                OneCongeRequest.SBranchID = pSubBranchID;
            }
            else if (tPAction == 1) // Add new
            {

                await searchByMatricule();

                bDisableChefDirect = true;
                bDisableHR = true;
                bDisableDG = true;


                modalTitle = "Ajouter Demande congé";
                StyleButton = "btn btn-sm btn-primary";
                ButtonCaption = "Sauvegarder";

                iTypeAction = tPAction;
                var defaultStartDate = DateTime.Today;
                var defaultEndDate = DateTime.Today;
                OneCongeRequest = new THRCongCircRequest
                {
                    ID = 0,
                    Matricule = sMatricule,
                    DateRequest = DateTime.Today,
                    DateDebutReq = defaultStartDate,  // FIX: Set default start date
                    DateFinReq = defaultEndDate,      // FIX: Set default end date
                    TpMaj = 1,
                    StatusHRID = "Attente",
                    StatusChefID = "Attente",
                    StatusDGID = "Attente",
                    UserID = int.Parse(osessionService.UserId),
                    CreatOn = DateTime.Now,
                    CreatBy = int.Parse(osessionService.UserId),
                    DecChefDirect = "Aucune",
                    DecHR = "Aucune",
                    DecDG = "Aucune",
                    Exercice = sExerciceID,
                    NbrJour = TotalDays,
                    SBranchID = pSubBranchID


                };


            }

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

            //if (tPAction == 1)
            //{
            //    await searchByMatricule();

            //    OneCongeRequest.NumTranche= iNumTranche;    
            //}

            popup = true;
        }
        protected void ClosePopUp()
        {
            popup = false;
        }

        public async Task GoBack()
        {
            await JSRuntime.InvokeVoidAsync("history.back");
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
            OneCongeRequest.SBranchID = pSubBranchID;
        }



        public async Task SaveData(THRCongCircRequest OneCongeRequest)
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


                OneCongeRequest.TpMaj = iTypeAction;
                OneCongeRequest.UserID = int.Parse(osessionService.UserId);

                OneCongeRequest.NumTranche = iNumTranche;
                if (iTypeAction == 2) // Update
                {
                    OneCongeRequest.LModifBy = int.Parse(osessionService.UserId);
                    OneCongeRequest.LModifOn = DateTime.Now;
                }



                oResult = await oCongeRequestsService.GetUpdateResult(OneCongeRequest);

                if (oResult != null && !string.IsNullOrEmpty(oResult.Result))
                {
                    await JSRuntime.InvokeVoidAsync("alert", oResult.Result);
                    searchByMatricule();
                    ClosePopUp();
                }



                // Refresh the list
                oCongeRequestsList = await oCongeRequestsService.GetAllCongeRequests();
                // Close popup if successful
                if (oResult != null && oResult.Result.Contains("Insert succeeded", StringComparison.OrdinalIgnoreCase) ||
                    oResult.Result.Contains("Successfully", StringComparison.OrdinalIgnoreCase) ||
                    oResult.Result.Contains("Updated", StringComparison.OrdinalIgnoreCase) ||
                    oResult.Result.Contains("Deleted", StringComparison.OrdinalIgnoreCase))
                {
                    ClosePopUp();
                }

                //ClosePopUp();
                StateHasChanged();
            }
            catch (Exception ex)
            {
                await JSRuntime.InvokeVoidAsync("alert", $"Erreur: {ex.Message}");
            }
        }


        public string UserSubBranct = "";
        public async Task searchByMatricule()
        {
            if (string.IsNullOrWhiteSpace(sMatricule))
            {
                await JSRuntime.InvokeVoidAsync("alert", "Veuillez entrer un matricule.");
                return;
            }

            try
            {
                isLoading = true;
              

                var param1 = new ParamAgentMatricule
                {
                    Matricule = sMatricule,
                    UserID = int.Parse(osessionService.UserId),
                    RoleID = osessionService.RoleID

                };

                var oTRH02AgentList = osessionService.RoleID != 1
                    ? await oTRH02AgentService.GetAgentByMatricule(sMatricule) :
                    await oTRH02AgentService.GetAgentByMatriculeXX(param1);


                //oTRH02AgentList = await oTRH02AgentService.GetAgentByMatriculeXX(param1);


                ///oPlanningCongeList = await oPlanningCongeService.GetPlanningCongeByMatricule(sMatricule);

                if (osessionService.RoleID == 2)
                {
                    if (int.TryParse(osessionService.UserId, out int userId))
                    {
                        oTRH02AgentList = oTRH02AgentList.Where(row => row.ChefID == userId).ToList();

                    }
                }


                if (oTRH02AgentList != null && oTRH02AgentList.Count > 0)
                {

                    sNomPrenom = oTRH02AgentList[0].Nom.Trim() + " " + oTRH02AgentList[0].Prenom.Trim();
                    // abakozi banjye gusa
                    //UserSubBranct = oTRH02AgentList[0].SBranchLocID.Trim();

                    //if (UserSubBranct != osessionService.BranchID && osessionService.RoleID != 3)
                    //{
                    //    await JSRuntime.InvokeVoidAsync("alert", "Cette personne ne fait pas partie des employés de votre agence.");
                    //    return;
                    //}
                    // end gushaka abbakozi


                    oCongeRequestsList = await oCongeRequestsService.GetAllCongeRequestsByMatricule(sMatricule);

                    iNumTranche = oTRH02AgentList[0].NextTranche;

                    await JSRuntime.InvokeVoidAsync("alert","Congé: "+ oCongeRequestsList.Count);
                    if (osessionService.RoleID == 2)
                    {
                        bDisableChefDirect = false;
                        oCongeRequestsList = oCongeRequestsList.Where(a => (a.ValidReq == true && a.Matricule == sMatricule && a.StatusChefID == "Attente")).ToList();
                        bAddDisabled = true;
                    }

                    if (osessionService.RoleID == 3)
                    {
                        bDisableHR = false;
                        oCongeRequestsList = oCongeRequestsList.Where(a => (a.ValidReq == true &&  a.Matricule == sMatricule && a.StatusChefID != "Attente" && (a.StatusHRID == "Attente" || a.StatusHRID != "Attente"))).ToList();
                        bAddDisabled = true;

                    }

                    if (osessionService.RoleID == 4)
                    {
                        bDisableDG = false;
                        oCongeRequestsList = oCongeRequestsList.Where(a => (a.ValidReq == true &&  a.Matricule == sMatricule && a.StatusHRID != "Attente" && (a.StatusDGID == "Attente" || a.StatusDGID != "Attente"))).ToList();
                        bAddDisabled = true;

                    }


                    bAddDisabled = false;
                    
                }
                else
                {
                    bAddDisabled = true;
                    await JSRuntime.InvokeVoidAsync("alert",
                        $"Aucun agent trouvé avec le matricule: {sMatricule}");
                    oCongeRequestsList = new List<THRCongCircRequest>();
                }
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
                }
            }
        }

        public bool bAddDisabled { get; set; } = true;


        public bool bDisableChefDirect { get; set; } = true;
        public bool bDisableHR { get; set; } = true;
        public bool bDisableDG { get; set; } = true;

        public bool bEmployee { get; set; } = false;
        public string sExerciceID { get; set; }
        public int iNumTranche { get; set; } = 0;
        public int TotalDays { get; set; }

        public bool bAjoute { get; set; } = false;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");

                    int userId = int.Parse(osessionService.UserId);
                    //oCongeRequestsList = await oCongeRequestsService.GetAllCongeRequests();


                    oCongeList = (await oDonBaseService.GetDBListName("TRH051TypeConge")).ToList();

                    oOneTRH02Agent = new ClassTRH02Agent();



                    //}
                    if (osessionService.RoleID == 1)
                    {
                        // FIX: Set matricule FIRST
                        bEmployee = true;
                        sMatricule = osessionService.Matricule;

                        var param1 = new ParamAgentMatricule
                        {
                            Matricule = sMatricule,  // ← Now this has a value!
                            UserID = int.Parse(osessionService.UserId)
                        };

                        oTRH02AgentList = await oTRH02AgentService.GetAgentByMatriculeCongeReq(param1);

                        // view tranch
                        var param = new ParamNumTranche
                        {
                            Matricule = osessionService.Matricule
                        };

                        oPlanningCongeList = await oPlanningCongeService.GetPlanningCongeByMatricule(osessionService.Matricule);

                        if (oPlanningCongeList != null && oPlanningCongeList.Count > 0)
                        {
                            var firstPlanning = oPlanningCongeList[0];
                            var bChefDirect = firstPlanning.StatusChefD;
                            var bHR = firstPlanning.Remark;

                            if (bChefDirect == null || bChefDirect == "Attente" || bChefDirect == "No" || bHR == "" || bHR == null)
                            {
                                await JSRuntime.InvokeVoidAsync("alert", "Veuillez attendre l'approbation de votre superviseur et de HG");

                                ////string sChemin = "http://localhost:19143/GcongeIndex";
                                //string sChemin = "/rimpayroll/GcongeIndex";

                                //NavMager.NavigateTo(sChemin, true);
                                return;
                            }
                            else
                            {
                                await JSRuntime.InvokeVoidAsync("alert", "You have " + oPlanningCongeList.Count + " Tranches of leave");
                            }
                        }
                        else
                        {
                            await JSRuntime.InvokeVoidAsync("alert", "no planing you have");
                            return;
                        }
                    }

                    oTCl550BranchList = await oTCl550BranchService.GetT550Branch();
                    oTCl550SubBranchList2 = await oTCl550SubBranchService.GetList();

                    oTCl550BranchList = await oTCl550BranchService.GetT550Branch();
                    oTCl550UserList = await oTCl550UserService.GetList();
                    oTCl550FonctionList = await oTCl550FonctionService.GetTCl550Fonction();
                    TRH550StatusContratList = (await oDonBaseService.GetDBListName("TRH550StatusContrat")).ToList();
                    oTCl550SubBranchList = oTCl550SubBranchList2;
                    oTPR550Exercice = (await oTabPrmNivOneService.GetDBListName("TPR550Exercice")).ToList();

                    oTPR550Exercice = oTPR550Exercice.Where(x => x.Enab == true).ToList();

                    if (oTPR550Exercice.Count > 0)
                    {
                        sExerciceID = oTPR550Exercice[0].RICode;
                    }

                }
                await InvokeAsync(StateHasChanged);
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
