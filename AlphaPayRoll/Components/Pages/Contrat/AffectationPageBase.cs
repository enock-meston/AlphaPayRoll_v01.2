using AlphaPayRoll.Data;
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
using PayLibrary.TCl550Fonction;
using PayLibrary.TRH02Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaPayRoll.Components.Pages.Contrat
{
    public class AffectationPageBase : ComponentBase
    {

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        public ClasSessionStorage osessionService { set; get; }

        [Inject]
        protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }

        [Inject]
        protected IClasContrat oContratService { set; get; }

        public List<TRH04Affectation> oTRH04AffectationList { set; get; }




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



        [Inject]
        private ITabPrmNivOne oTabPrmNivOneService { set; get; }
        public List<TabPrmNivOne> TRH550CategContratList { set; get; }
        public List<TabPrmNivOne> TRH550TypeSalaireList { set; get; }

        public List<TabPrmNivOne> TRH550StatusContratList { set; get; }


        [Parameter]
        public string id { set; get; }
        public TRH04Affectation oOneAffectation { set; get; }

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
        public ClasContrat oSelectedContrat { get; set; }
        //public List<ClasContrat> oContratList { set; get; }


        public string StyleButton { set; get; }
        public string ButtonCaption { set; get; }

        public string modalTitle { set; get; }

        public int iTypeAction { set; get; }

        public string LieuAffectation { set; get; }

        protected async Task ShowPopUp(int tPAction)
        {
            

            if (tPAction == 0)
            {
                modalTitle = "Affectation Detail";
            }


            if (tPAction != 1)
            {
                pSubBranchID = oOneAffectation.SBranchID;
               pBranchID = pSubBranchID.Substring(0, 2);
            }




            if (tPAction == 2)
            {
                modalTitle = "modification de Affectation ";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
            }
            else if (tPAction == 3)
            {
                modalTitle = "Supprimer Affectation Detail";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";
                oOneAffectation.Matricule = sMatricule;
                oOneAffectation.LModifBy = int.Parse(osessionService.UserId);
                oOneAffectation.LModifOn = DateTime.Now;

            }


            if (tPAction == 1)
            {
                modalTitle = "Ajouter Affectation";
                StyleButton = "btn btn-sm btn-primary";
                ButtonCaption = "Ajouter";
                iTypeAction = tPAction;


                // Only create new object if oOneAffectation is null or doesn't have the matricule set
                if (oOneAffectation == null || string.IsNullOrEmpty(oOneAffectation.Matricule))
                {
                    oOneAffectation = new TRH04Affectation();
                    oOneAffectation.ID = 0;
                    oOneAffectation.CreatBy = int.Parse(osessionService.UserId); 
                    oOneAffectation.CreatOn = DateTime.Now;
                    oOneAffectation.FunctionID = 0; // select from combo
                    oOneAffectation.Matricule = sMatricule;
                    oOneAffectation.DateAffect = DateTime.Today;
                    oOneAffectation.DateFin = DateTime.Today;
                    oOneAffectation.StatusID = 1;
                    oOneAffectation.Observations = "________";
                }
            }
           

            popup = true;
        }

        public bool AgentSelected { set; get; } = false;

        public int AgentID { set; get; }
        public decimal SalaireBase { set; get; }
        public string sNomAgent { set; get; }

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
        }
        protected async Task ValidateData(int id)
        {
            try
            {
                var param = new ParamValidAffectation
                {
                    ID = id,
                    UserID = int.Parse(osessionService.UserId)
                };
                //await JSRuntime.InvokeVoidAsync("alert", $"ID: {param.ID}, UserID: {param.UserID}");

                var result = await oContratService.ValiderAffectation(param);
                await JSRuntime.InvokeVoidAsync("alert", "Message: " + result.Result);
                oContratList = await oContratService.GetContractByMatricule(sMatricule);
                oTRH02AgentList = await oTRH02AgentService.GetAgentByMatricule(sMatricule);

                if (oTRH02AgentList.Count > 0)
                {
                    sNomPrenom = oTRH02AgentList[0].Nom.Trim() + " " + oTRH02AgentList[0].Prenom.Trim();
                    oTRH04AffectationList = await oContratService.GetAffectionByMatricule(sMatricule);

                }

            }
            catch (Exception ex)
            {
                await JSRuntime.InvokeVoidAsync("alert", $"An error occurred: {ex.Message}");
                //Console.WriteLine($"Error in ValidateData: {ex}");
            }
        }
        protected void EditData(TRH04Affectation item, int TpAction)
        {

            iTypeAction = TpAction;
            oOneAffectation = item;

            ShowPopUp(iTypeAction);

        }


        Resultat oResultat = new Resultat();

        protected async Task SaveContrat(TRH04Affectation item)
        {



            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment supprimer ceci ? "))
                    return;
            }
            else if (oOneAffectation.SBranchID == "0" || oOneAffectation.SBranchID == null)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Guichet est obligatoire");
                return;
            }
            else if (oOneAffectation.Observations == "0" || oOneAffectation.Observations == null)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Observations est obligatoire");
                return;
            }



            try
            {

                oOneAffectation.TpMaj = iTypeAction;
                oOneAffectation.UserID = int.Parse(osessionService.UserId);
                oOneAffectation.NumContrat = oSelectedContrat.NumContrat;

                oResultat = new Resultat();

                oResultat = await oContratService.GetResutUpdateAffect(item);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
                oContratList = await oContratService.GetContractByMatricule(id);

                oTRH02AgentList = await oTRH02AgentService.GetAgentByMatricule(sMatricule);

                if (oTRH02AgentList.Count > 0)
                {
                    sNomPrenom = oTRH02AgentList[0].Nom.Trim() + " " + oTRH02AgentList[0].Prenom.Trim();
                    oTRH04AffectationList = await oContratService.GetAffectionByMatricule(sMatricule);

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
            oTCl550SubBranchList = oTCl550SubBranchList2.Where(row => row.CodeBranch.Trim() == pBranchID.Trim()).ToList();
        }

        public void SubBranchChanged(string Value)
        {
            pSubBranchID = Value;
            oOneAffectation.SBranchID = pSubBranchID;
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
                            // check if selected user's contract is validated
                            oContratList = await oContratService.GetContractByMatricule(sMatricule);

                            if (oContratList != null && oContratList.Any())
                            {
                                oSelectedContrat = oContratList
                                            .OrderByDescending(c => c.CreatOn ) 
                                            .FirstOrDefault();
                        //(item.ValidBy != 0 || item.ValidBy != null) && item.ValidOn != null

                        if (oSelectedContrat.ValidBy != 0 || oSelectedContrat.ValidOn != null)
                                {
                                    sNomPrenom = oTRH02AgentList[0].Nom.Trim() + " " + oTRH02AgentList[0].Prenom.Trim();
                                    oTRH04AffectationList = await oContratService.GetAffectionByMatricule(sMatricule);
                                    bAddDisabled = false;
                                }
                                else
                                {
                                    bAddDisabled = true;
                                    await JSRuntime.InvokeVoidAsync("alert", $"Contract with this matricule: {sMatricule} is not Valid");
                                }
                            }
                                 //end of check 

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

        public string sCodeBranch { set; get; }
        public string sCodeSubBranch { set; get; }  
        protected override async Task OnInitializedAsync()
        {
            osessionService = new ClasSessionStorage();
            osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");

            try
            {
                oSelectedContrat = new ClasContrat();

                oOneAffectation = new TRH04Affectation();
                oTRH04AffectationList = await oContratService.GetAffectionByMatricule(id);

                oContractStatusList = (await oDonBaseService.GetDBListName("TRH550StatusContrat")).ToList();

                oOneTRH02Agent = new ClassTRH02Agent();
              //oTRH02AgentList = await oTRH02AgentService.GetAgentByMatricule("RIM00002");


                oTCl550BranchList = await oTCl550BranchService.GetT550Branch();
                oTCl550SubBranchList2 = await oTCl550SubBranchService.GetList();

                oContratList = await oContratService.GetContractByMatricule(id);
                oTCl550BranchList = await oTCl550BranchService.GetT550Branch();
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
