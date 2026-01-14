using AlphaPayRoll.Data;
using AlphaPayRoll.DataServices.Contrat;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.Cl550Branch;
using PayLibrary.CONTRACT_GOMISE;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Training;
using PayLibrary.TrainingField;
using PayLibrary.TRH02Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaPayRoll.Components.Pages.Training
{
    public class TRH03TrainingPageBase : ComponentBase
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
        protected ITCl550Branch oBranchService { set; get; }  //ITCl550Branch
        public List<TSc550Branch> oBranch { set; get; }


        [Inject]
        public ITSc551User oTSc551UserService { set; get; }

        public List<TSc551User> oTSc551UserList { set; get; }

        [Inject]
        protected ITRH03Training oTRH03TrainingService { set; get; }
        public List<TRH03Training> oTRH03TrainingList { set; get; }

        public TRH03Training oOneAmount { set; get; }



        [Inject]
        public ITRH031TrainingField oTRH031TrainingFieldService { set; get; }

        public List<TRH031TrainingField> oTRH031TrainingFieldList { set; get; }

        public string getRowColor(int i)
        {
            return (i % 2 == 0) ? "table-info" : "table-light";
        }


        [Inject]
        protected ITRH02Agent oTRH02AgentService { set; get; }
        public List<ClassTRH02Agent> oTRH02AgentList { set; get; }
        public ClassTRH02Agent oOneTRH02Agent { set; get; }


        [Inject]
        protected ITSc551SubBranch oTCl550SubBranchService { set; get; }
        public List<TSc551SubBranch> oTCl550SubBranchList { set; get; }
        public List<TSc551SubBranch> oTCl550SubBranchList2 { set; get; }


        //=================================================================================

        protected bool popup = false;
        public bool isLoading { set; get; } = true;
        public bool AgentSelected { set; get; } = false;

        public int AgentID { set; get; }
        public decimal SalaireBase { set; get; }
        public string sNomAgent { set; get; }


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
                modalTitle = "Training Detail";
            }
            else if (tPAction == 2)
            {
                modalTitle = "Modification Training Detail";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Ajouter";
            }

            if (tPAction == 1)
            {
                modalTitle = "Ajouter";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Ajouter";
                iTypeAction = tPAction;
                oOneAmount.Pays = "Rwanda";
                oOneAmount.Ville = "Kigali";

                oOneAmount.LModifBy = int.Parse(osessionService.UserId);
                oOneAmount.LModifOn = DateTime.Now;
                oOneAmount.CreatOn = DateTime.Now;
                oOneAmount.StartDate = DateTime.Now;
                oOneAmount.EndDate = DateTime.Now;
                oOneAmount.CreatBy = int.Parse(osessionService.UserId);


            }
            else if (tPAction == 3)
            {
                modalTitle = "Supprimer Candite Detail";
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
        public void BackToAgent()
        {
            AgentSelected = false;

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
            oTCl550SubBranchList = oTCl550SubBranchList2.Where(row => row.CodeBranch.Trim() == pBranchID.Trim()).ToList();
        }

        public void SubBranchChanged(string Value)
        {
            pSubBranchID = Value;
            //oOneAmount.SBranchID = pSubBranchID;
        }

        public string sMatricule { set; get; }



        protected void EditData(TRH03Training item, int TpAction)
        {
            iTypeAction = TpAction;
            oOneAmount = item;
            ShowPopUp(iTypeAction);

        }
        Resultat oResultat = new Resultat();



        protected async Task SaveDocVal(TRH03Training item)
        {
            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment supprimer ?"))
                    return;
            }
            else if (oOneAmount.Observation == "")
            {
                await JSRuntime.InvokeVoidAsync("alert", "Observation est obligatoire");
                return;
            }
            else if (oOneAmount.FieldID == 0)
            {
                await JSRuntime.InvokeVoidAsync("alert", "le Field est obligatoire");
                return;
            }
            else if (oOneAmount.OrganisePar == "")
            {
                await JSRuntime.InvokeVoidAsync("alert", "Organise Par est obligatoire");
                return;
            }
            else if (oOneAmount.Descript == "")
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Descript est obligatoire");
                return;
            }
           



            //item.CreatBy = osessionService.UserId;
            item.TpMaj = iTypeAction;
            oOneAmount.Matricule = sMatricule;
            oResultat = new Resultat();



            oResultat = await oTRH03TrainingService.GetUpdateResult(item);
            await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
            //oHr_ApplicationList = await oHr_ApplicationService.GetList(sClientId);
            oTRH03TrainingList = await oTRH03TrainingService.GetListAll();
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
                    oTRH03TrainingList = await oTRH03TrainingService.GetList(sMatricule);
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
                oTRH031TrainingFieldList = await oTRH031TrainingFieldService.GetListAll();
                
            oTSc551UserList = await oTSc551UserService.GetList();
            oOneAmount = new TRH03Training();

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
