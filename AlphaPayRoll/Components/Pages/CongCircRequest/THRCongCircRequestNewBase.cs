using AlphaPayRoll.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.JSInterop;
using PayLibrary.Cl550Branch;
using PayLibrary.CongCircRequest;
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



namespace AlphaPayRoll.Components.Pages.CongCircRequest
{ 
public class THRCongCircRequestNewBase : ComponentBase
{

        [Inject]
        public NavigationManager NavMager { get; set; }

        [Inject]
    public ITHRCongCircRequestNew oCongeRequestsService { get; set; }

    public List<THRCongCircRequestNew> oCongeRequestsList { get; set; } 

    public List<TpConge> TpCongeList { get; set; } = new List<TpConge>();
    public List<THRPlanningConge> PlanningList { get; set; } = new List<THRPlanningConge>();
    public List<StatReq> StatusList { get; set; } = new List<StatReq>();
  
    public THRCongCircRequestNew oOneActiveCongeRequest { get; set; }
    public THRCongCircRequestNew OneCongeRequest { get; set; } = new THRCongCircRequestNew();
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
    public string id { get; set; }  

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

        [Inject]
        protected ITRH02Agent oTRH02AgentService { set; get; }
        public List<ClassTRH02Agent> oTRH02AgentList { set; get; }
        public ClassTRH02Agent oOneTRH02Agent { set; get; }
        
        public List<TabPrmNivOne> oCongeList { set; get; }

        public List<ClasContrat> oContratList { set; get; }
        public List<ClassTRH02Agent> oTRH02SelectAgentList { get; set; } = new List<ClassTRH02Agent>();
        public string sSelectedPerson { get; set; }
        public bool AgentSelected { set; get; } = false;

        public int AgentID { set; get; }
        public decimal SalaireBase { set; get; }
        public string sNomAgent { set; get; }
        public string sNomPrenom { set; get; }
        public string sMatricule { set; get; }

        
        public void DonAgentSuite(THRCongCircRequestNew pConge)
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



        

        protected void EditData(THRCongCircRequestNew item, int TpAction)
        {
            iTypeAction = TpAction;
            oOneActiveCongeRequest = item;

            if (TpAction == 2 || TpAction == 0) // Edit or View
            {
                OneCongeRequest = new THRCongCircRequestNew
                {
                    ID = item.ID,
                    Matricule = item.Matricule,
                    SBranchID = item.SBranchID,
                    TpCongeID = item.TpCongeID,
                    DateRequest = item.DateRequest,
                    NbrJour = item.NbrJour,
                    Observation = item.Observation,
                    StatusHRID = item.StatusHRID,
                    StatusChefID = item.StatusChefID,
                    StatusDGID = item.StatusDGID,
                    CreatOn = item.CreatOn,
                    CreatBy = item.UserID,
                    LModifBy = item.LModifBy,
                    LModifOn = item.LModifOn,
                    UserID = int.Parse(osessionService.UserId),
                    TpMaj = TpAction

                };

                if (!string.IsNullOrEmpty(item.SBranchID) && item.SBranchID.Length >= 3)
                {
                    
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


        public string modalTitle {  get; set; } 
        public string StyleButton { get; set; }
        public string ButtonCaption { get; set; }
      
        protected void ShowPopUp(int tPAction)
        {
            if (tPAction == 0)
            {
                modalTitle = "Congé Circ. Detail";
                StyleButton = "";
                ButtonCaption = "";
            }

            else if (tPAction == 2)
            {
                modalTitle = "Modifier congé Circ.";
                StyleButton = "btn btn-sm btn-primary";
                ButtonCaption = "Sauvegarder";
                

            }
            else if (tPAction == 3)
            {
                modalTitle = "Supprimer congé Circ.";
                StyleButton = "btn btn-sm btn-danger";
                ButtonCaption = "Supprimer";

                OneCongeRequest.CreatBy = int.Parse(osessionService.UserId);
                OneCongeRequest.LModifBy = int.Parse(osessionService.UserId);
                OneCongeRequest.LModifOn = DateTime.Now;
            }
            else if (tPAction == 1) // Add new
            {
                modalTitle = "Ajouter congé Circ.";
                StyleButton = "btn btn-sm btn-primary";
                ButtonCaption = "Sauvegarder";

                iTypeAction = tPAction;

                pSubBranchID = osessionService.BranchID;

                pBranchID = pSubBranchID.Substring(0, 2);

                OneCongeRequest = new THRCongCircRequestNew
                {
                    ID = 0,
                    Matricule = sMatricule,
                    DateRequest = DateTime.Today,
                    TpMaj = 1,
                    StatusHRID = "Attente",
                    StatusChefID = "Attente",
                    StatusDGID = "Attente",
                    SBranchID = pSubBranchID,
                    UserID = int.Parse(osessionService.UserId),
                    CreatOn = DateTime.Now,
                    CreatBy = int.Parse(osessionService.UserId)
                };

                //pBranchID = "";
                //pSubBranchID = "";
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
            OneCongeRequest.SBranchID = pSubBranchID;
        }


        public async Task SaveData(THRCongCircRequestNew OneCongeRequest)
        {
            try
            {
                if (iTypeAction == 3)
                {
                    bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm",
                        "Voulez-vous vraiment supprimer cette demande de congé?");
                    if (!confirmed)
                        return;
                }else if (OneCongeRequest.Observation =="")
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Le Observation est obligatoire");
                    return;
                }
                else if (OneCongeRequest.TpCongeID ==0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Le Type de Congé Circ est obligatoire");
                    return;
                }


                    OneCongeRequest.TpMaj = iTypeAction;
                OneCongeRequest.UserID = int.Parse(osessionService.UserId);

                if (iTypeAction == 2) // Update
                {
                    OneCongeRequest.CreatBy = int.Parse(osessionService.UserId);
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
                oCongeRequestsList = await oCongeRequestsService.GetAllCongeCircRequests();

                // Close popup if successful (check for success message)
                if (oResult != null && oResult.Result.Contains("success", StringComparison.OrdinalIgnoreCase))
                {
                    ClosePopUp();
                }

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

            //await JSRuntime.InvokeVoidAsync("alert", sMatricule);

            if (string.IsNullOrWhiteSpace(sMatricule))
            {
                await JSRuntime.InvokeVoidAsync("alert", "Veuillez entrer un matricule.");
                return;
            }

            try
            {
                isLoading = true;
                StateHasChanged();
                oTRH02AgentList = await oTRH02AgentService.GetAgentByMatricule(sMatricule);
               
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

                    //all conge circonsyance
                    oCongeRequestsList = await oCongeRequestsService.GetAllCongeCircRequests();

                    // ?? need to select by matricule..............(will do it) future???

                    if (osessionService.RoleID == 2)
                    {
                        bDisableChefDirect = false;
                        oCongeRequestsList = oCongeRequestsList.Where(a => (a.Matricule == sMatricule && a.StatusChefID == "Attente")).ToList();
                    }

                    if (osessionService.RoleID == 3)
                    {
                        bDisableHR = false;
                        oCongeRequestsList = oCongeRequestsList.Where(a => (a.Matricule == sMatricule && a.StatusChefID != "Attente" && (a.StatusHRID == "Attente" || a.StatusHRID != "Attente"))).ToList();
                    }

                    if (osessionService.RoleID == 4)
                    {
                        bDisableDG = false;
                        oCongeRequestsList = oCongeRequestsList.Where(a => (a.Matricule == sMatricule && a.StatusHRID != "Attente" && (a.StatusDGID == "Attente" || a.StatusDGID != "Attente"))).ToList();
                    }
                    bAddDisabled = false;
                }
                else
                {
                    bAddDisabled = true;
                    await JSRuntime.InvokeVoidAsync("alert",
                        $"Aucun agent trouvé avec le matricule: {sMatricule}");
                    oCongeRequestsList = new List<THRCongCircRequestNew>();
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

        // day 
        public async Task OnCongeTypeChanged(int selectedId)
        {
            var selectedConge = oCongeList.FirstOrDefault(x => x.ID == selectedId);

            if (selectedConge != null)
            {
                OneCongeRequest.NbrJour = selectedConge.OrdNum;
                await InvokeAsync(StateHasChanged); // Force UI update
            }
            else
            {
                OneCongeRequest.NbrJour = 0;
            }
        }


        public bool bAddDisabled { get; set; } = true;

        public bool bDisableChefDirect { get; set; } = true;
        public bool bDisableHR { get; set; } = true;
        public bool bDisableDG { get; set; } = true;
        public bool bEmployee { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");
            try
            {

                oCongeList = (await oDonBaseService.GetDBListName("TRH051TypeCongCircons")).ToList();
                oOneTRH02Agent = new ClassTRH02Agent();
                if (osessionService.RoleID == 1)
                {
                    
                    oTRH02AgentList = await oTRH02AgentService.GetAgentByMatricule(osessionService.Matricule);
                    bEmployee = true;
                    sMatricule = osessionService.Matricule;
                }

                oTCl550BranchList = await oTCl550BranchService.GetT550Branch();
                oTCl550SubBranchList2 = await oTCl550SubBranchService.GetList();

                oContratList = await oContratService.GetContractByMatricule(id);
               
                oTCl550UserList = await oTCl550UserService.GetList();
                oTCl550FonctionList = await oTCl550FonctionService.GetTCl550Fonction();

                oTCl550SubBranchList = oTCl550SubBranchList2;

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
