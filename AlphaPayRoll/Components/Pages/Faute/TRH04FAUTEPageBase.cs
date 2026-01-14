//using AlphaBkDLL.HumanResource;
using AlphaPayRoll.Data;
using AlphaPayRoll.DataServices.Contrat;
using AlphaPayRoll.DataServices.TCl550Branch;
using AlphaPayRoll.DataServices.TCl550Fonction;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.Cl550Branch;
using PayLibrary.CONTRACT_GOMISE;
using PayLibrary.Contrat;
using PayLibrary.Faute;
using PayLibrary.FauteTRH055;
using PayLibrary.Gravite;
using PayLibrary.InterfParamSec;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TCl550Fonction;
using PayLibrary.TRH02Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaPayRoll.Components.Pages.Faute
{
    public class TRH04FAUTEPageBase : ComponentBase
    {
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


        [Inject]
        public ITSc551User oTSc551UserService { set; get; }

        public List<TSc551User> oTSc551UserList { set; get; }

        [Inject]
        protected ITRH04FAUTE oTRH04FAUTEService { set; get; }
        public List<TRH04FAUTE> oTRH04FAUTEList { set; get; }

        public TRH04FAUTE oOneAmount { set; get; }


        [Inject]
        public ITabPrmNivOne oDonBaseService { set; get; }

        [Inject]
        public ITRH055FAUTE oTRH055FAUTEService { set; get; }

        public List<TRH055FAUTE> oTRH055FAUTEList { set; get; }
        
        [Inject]
        public ITRH042Gravite oTRH042GraviteService { set; get; }

        public List<TRH042Gravite> oTRH042GraviteList { set; get; }

        [Inject]
        protected ITRH02Agent oTRH02AgentService { set; get; }
        public List<ClassTRH02Agent> oTRH02AgentList { set; get; }
        public ClassTRH02Agent oOneTRH02Agent { set; get; }

        [Inject]
        protected ITSc551SubBranch oTCl550SubBranchService { set; get; }
        public List<TSc551SubBranch> oTCl550SubBranchList { set; get; }
        public List<TSc551SubBranch> oTCl550SubBranchList2 { set; get; }
        public List<TabPrmNivOne> oContractStatusList { set; get; }

        [Inject]
        protected ITCl550Branch oTCl550BranchService { set; get; }
        public List<ClassTCl550Branch> oTCl550BranchList { set; get; }
        public List<ClasContrat> oContratList { set; get; }
        [Inject]
        protected IClasContrat oContratService { set; get; }



        [Inject]
        protected ITSc551User oTCl550UserService { set; get; }
        public List<TSc551User> oTCl550UserList { set; get; }


        [Inject]
        protected ITCl550Fonction oTCl550FonctionService { set; get; }
        public List<ClassTCl550Fonction> oTCl550FonctionList { set; get; }


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
                modalTitle = "Faute";
            }
            else if (tPAction == 2)
            {
                modalTitle = "Modification Faute ";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Save";
            }

            if (tPAction == 1)
            {
                modalTitle = "Ajout";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Ajout";
                iTypeAction = tPAction;

                oOneAmount.LModifBy =int.Parse(osessionService.UserId);
                oOneAmount.Matricule = sMatricule;
                oOneAmount.LModifOn = DateTime.Now;
                oOneAmount.CreatOn = DateTime.Now;
                oOneAmount.CreatBy = int.Parse(osessionService.UserId);


            }
            else if (tPAction == 3)
            {
                modalTitle = "Supprimer Faute";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";

                oOneAmount.LModifBy = int.Parse(osessionService.UserId);
                oOneAmount.Matricule = sMatricule;
                oOneAmount.LModifOn = DateTime.Now;
                oOneAmount.CreatOn = DateTime.Now;
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
            //oTCl550SubBranchList = oTCl550SubBranchList2.Where(row => row.CodeBranch.Trim() == pBranchID.Trim()).ToList();
        }

        public void SubBranchChanged(string Value)
        {
            pSubBranchID = Value;
            //oOneAmount.SBranchID = pSubBranchID;
        }

       


        public void DonAgentSuite(TRH04FAUTE pFaute)
        {
            var agent = oTRH02AgentList?.FirstOrDefault(a => a.Matricule == pFaute.Matricule);

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
        public void BackToAgent()
        {
            AgentSelected = false;

        }



       

        protected void EditData(TRH04FAUTE item, int TpAction)
        {
            iTypeAction = TpAction;
            oOneAmount = item;
            ShowPopUp(iTypeAction);

        }
        Resultat oResultat = new Resultat();





        protected async Task SaveDocVal(TRH04FAUTE item)
        {
            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to DELETE  this item ?"))
                    return;
            }
            else if (oOneAmount.Observation == "")
            {
                await JSRuntime.InvokeVoidAsync("alert", "Observation est obligatoire");
                return;
            }
            else if (oOneAmount.Descript == "")
            {
                await JSRuntime.InvokeVoidAsync("alert", "Descript est obligatoire");
                return;
            }
            else if (oOneAmount.TpFauteID == 0)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Tp Faute est obligatoire");
                return;
            }
            else if (oOneAmount.DateFaute == null)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Date Faute est obligatoire");
                return;
            }
            else if (oOneAmount.GraviteID == 0)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Gravite est obligatoire");
                return;
            }
            else if (oOneAmount.LieuFaute == "")
            {
                await JSRuntime.InvokeVoidAsync("alert", "Lieu Faute est obligatoire");
                return;
            }
            


            //item.CreatBy = osessionService.UserId;
            item.TpMaj = iTypeAction;
            oResultat = new Resultat();



            oResultat = await oTRH04FAUTEService.GetUpdateResult(item);
            await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
            //oHr_ApplicationList = await oHr_ApplicationService.GetList(sClientId);
            oTRH04FAUTEList = await oTRH04FAUTEService.GetListAll();
            oTRH02AgentList = await oTRH02AgentService.GetAgentByMatricule(sMatricule);

            if (oTRH02AgentList.Count > 0)
            {
                sNomPrenom = oTRH02AgentList[0].Nom.Trim() + " " + oTRH02AgentList[0].Prenom.Trim();
                oTRH04FAUTEList = await oTRH04FAUTEService.GetList(sMatricule);

            }
            ClosePopUp();


        }
        public int sClientId { set; get; } = 0;


        //public async Task RechercherDon()
        //{
        //    oTRH04FAUTEList = await oTRH04FAUTEService.GetListAll();
        //}
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
                    oTRH04FAUTEList = await oTRH04FAUTEService.GetList(sMatricule);
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
                
                oOneAmount = new TRH04FAUTE();
                //oTRH04FAUTEList = await oTRH04FAUTEService.GetList(sMatricule);

                oTRH055FAUTEList = await oTRH055FAUTEService.GetListAll();
                oContractStatusList = (await oDonBaseService.GetDBListName("TRH550StatusContrat")).ToList();
                oTCl550BranchList = await oTCl550BranchService.GetT550Branch();
                oTCl550SubBranchList2 = await oTCl550SubBranchService.GetList();
                oTCl550BranchList = await oTCl550BranchService.GetT550Branch();
                oTCl550FonctionList = await oTCl550FonctionService.GetTCl550Fonction();
                oTRH042GraviteList = await oTRH042GraviteService.GetListAll();
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
