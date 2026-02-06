
using AlphaPayRoll.Data;
using AlphaPayRoll.DataServices.Contrat;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.Cl550Branch;
using PayLibrary.CONTRACT_GOMISE;
using PayLibrary.Contrat;
using PayLibrary.InterfParamSec;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Permission;
using PayLibrary.TCl550Fonction;
using PayLibrary.TRH02Agent;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaPayRoll.Components.Pages.Permission
{
    public class TRH05PermissionPageBase : ComponentBase
    {

        [Inject]
        public NavigationManager NavMager { get; set; }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        public ClasSessionStorage osessionService { set; get; }

        [Inject]
        protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }


        [Inject]
        protected ITSc551SubBranch oSubBranchService { set; get; }
        public List<TSc551SubBranch> SubBranch { set; get; }


        [Inject]
        protected ITCl550Branch oBranchService { set; get; }
        public List<TSc550Branch> oBranch { set; get; }

        [Parameter]
        public string id { set; get; }

        [Inject]
        public ITSc551User oTSc551UserService { set; get; }

        public List<TSc551User> oTSc551UserList { set; get; }

        [Inject]
        protected ITRH05Permission oTRH05PermissionService { set; get; }
        public List<TRH05Permission> oTRH05PermissionList { set; get; }

        [Inject]
        protected ITRH02Agent oTRH02AgentService { set; get; }
        public List<ClassTRH02Agent> oTRH02AgentList { set; get; }
        public ClassTRH02Agent oOneTRH02Agent { set; get; }
        public List<TabPrmNivOne> oContractStatusList { set; get; }
        [Inject]
        public ITabPrmNivOne oDonBaseService { set; get; }
        [Inject]
        protected ITCl550Branch oTCl550BranchService { set; get; }
        public List<ClassTCl550Branch> oTCl550BranchList { set; get; }

        public List<TabPrmNivOne> oCongeList { set; get; }

        [Inject]
        protected ITSc551SubBranch oTCl550SubBranchService { set; get; }
        public List<TSc551SubBranch> oTCl550SubBranchList { set; get; }
        public List<TSc551SubBranch> oTCl550SubBranchList2 { set; get; }

        public List<ClassTRH02Agent> oTRH02SelectAgentList { get; set; } = new List<ClassTRH02Agent>();
        public string sSelectedPerson { get; set; }

        [Inject]
        protected ITSc551User oTCl550UserService { set; get; }
        public List<TSc551User> oTCl550UserList { set; get; }


        [Inject]
        protected ITCl550Fonction oTCl550FonctionService { set; get; }
        public List<ClassTCl550Fonction> oTCl550FonctionList { set; get; }

        public List<ClasContrat> oContratList { set; get; }
        [Inject]
        protected IClasContrat oContratService { set; get; }


        public TRH05Permission oOneAmount { set; get; }
        public bool isLoading { set; get; } = true;
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

        public bool bValidation { set; get; } = false;
        public string sCodeBranch { set; get; }
        protected async Task ShowPopUp(int tPAction)
        {

            if (osessionService.RoleID ==2)
            {
                bIsDisabled = false;
            }
            if (tPAction == 0)
            {
                modalTitle = "Permission ";
            }
            else if (tPAction == 2)
            {
                modalTitle = "Modification Permission ";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Save";
                pSubBranchID = osessionService.BranchID;
                pBranchID = pSubBranchID.Substring(0, 2);
                oOneAmount.LModifBy = int.Parse(osessionService.UserId);
                oOneAmount.LModifOn = DateTime.Now;
            }

            if (tPAction == 1)
            {

                modalTitle = "Permission ";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
                iTypeAction = tPAction;

                pSubBranchID = osessionService.BranchID;
                pBranchID = pSubBranchID.Substring(0, 2);

                
                if (oOneAmount.LModifOn < new DateTime(1753, 1, 1))
                    oOneAmount.LModifOn = DateTime.Now;
                if (oOneAmount.Date < new DateTime(1753, 1, 1))
                    oOneAmount.Date = DateTime.Now;

                oOneAmount.CreatOn = DateTime.Now;
                oOneAmount.UserID = int.Parse(osessionService.UserId);
                oOneAmount.Matricule = sMatricule;
                oOneAmount.NbrHDemand = 3;
                oOneAmount.SBranchID = pSubBranchID;
                oOneAmount.DecisionPrisePar = 0;
                



            }
            else if (tPAction == 3)
            {
                modalTitle = "Supprimer Permission Detail";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";

                oOneAmount.LModifBy = int.Parse(osessionService.UserId);
                oOneAmount.LModifOn = DateTime.Now;
                oOneAmount.Matricule = sMatricule;
                oOneAmount.SBranchID = osessionService.BranchID.ToString();
                oOneAmount.DecisionPrisePar= int.Parse(osessionService.UserId);
            }
           
            popup = true;
        }

        public void DonAgentSuite(TRH05Permission pPermission)
        {
            var agent = oTRH02AgentList?.FirstOrDefault(a => a.Matricule == pPermission.Matricule);

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
            oOneAmount.SBranchID = pSubBranchID;
        }
        public async Task GoBack()
        {

            string sChemin = osessionService.sApp + "/GcongeIndex";

            NavMager.NavigateTo(sChemin, true);
        }


        public string UserSubBranct = "";
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
                if (osessionService.RoleID == 2)
                {
                    if (int.TryParse(osessionService.UserId, out int userId))
                    {
                        oTRH02AgentList = oTRH02AgentList.Where(row => row.ChefID == userId).ToList();

                    }
                }
                if (oTRH02AgentList.Count > 0)
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

                    oTRH05PermissionList = await oTRH05PermissionService.GetList(sMatricule);
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

        protected void EditData(TRH05Permission item, int TpAction)
        {
            iTypeAction = TpAction;
            oOneAmount = item;
            ShowPopUp(iTypeAction);

        }
        Resultat oResultat = new Resultat();

        protected async Task SaveDocVal(TRH05Permission item)
        {
            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to DELETE  this item ?"))
                    return;
            }
            else if (oOneAmount.MotifDemand == "")
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Motif est obligatoire");
                return;
            }
            else if (oOneAmount.Date == null)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Date est obligatoire");
                return;
            }
            else if (oOneAmount.TAutorisationDeSortie == null)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Type Autorisation De Sortie est obligatoire");
                return;
            }




            //item.CreatBy = osessionService.UserId);
            item.TpMaj = iTypeAction;
            oResultat = new Resultat();

            oResultat = await oTRH05PermissionService.GetUpdateResult(item);
            await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
           
            //oHr_ApplicationList = await oHr_ApplicationService.GetList(sClientId);
            oTRH05PermissionList = await oTRH05PermissionService.GetList(sMatricule);
            ClosePopUp();
            await searchByMatricule();

        }
        public int sClientId { set; get; } = 0;



        public bool bAddDisabled { get; set; } = true;
        public bool bEmployee { get; set; } = false;
        public bool bIsDisabled { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");
            try
            {
              
                oCongeList = (await oDonBaseService.GetDBListName("TRH051TypeConge")).ToList();

                //oTRH05PermissionList = await oTRH05PermissionService.GetListAll();
                oOneAmount = new TRH05Permission();
                
                oOneTRH02Agent = new ClassTRH02Agent();
                if (osessionService.RoleID == 1)
                {
                    //await JSRuntime.InvokeVoidAsync("alert", osessionService.Matricule);
                    oTRH02AgentList = await oTRH02AgentService.GetAgentByMatricule(osessionService.Matricule);
                    bEmployee = true;
                    sMatricule = osessionService.Matricule;
                }

                oTCl550BranchList = await oTCl550BranchService.GetT550Branch();
                oTCl550SubBranchList2 = await oTCl550SubBranchService.GetList();

                oTCl550SubBranchList = oTCl550SubBranchList2;
                //oContratList = await oContratService.GetContractByMatricule(id);
                oTCl550BranchList = await oTCl550BranchService.GetT550Branch();
                oTCl550UserList = await oTCl550UserService.GetList();


            }
            catch (Exception ex)
            {
                await JSRuntime.InvokeVoidAsync("alert", "error from Catch"+ ex.Message);

            }
            finally
            {
                isLoading = false;
            }


        }
    }
}
