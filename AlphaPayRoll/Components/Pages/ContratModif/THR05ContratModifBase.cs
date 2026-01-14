using AlphaPayRoll.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.Cl550Branch;
using PayLibrary.CONTRACT_GOMISE;
using PayLibrary.Contrat;
using PayLibrary.ContratModif;
using PayLibrary.InterfParamSec;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Personnel_RIM2;
using PayLibrary.TCl550Departement;
using PayLibrary.TCl550Deplom;
using PayLibrary.TCl550DomEtud;
using PayLibrary.TCl550Fonction;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TCl550NatIDType;
using PayLibrary.TCl550NivEtudId;
using PayLibrary.TCl550Sexe;
using PayLibrary.TCl550Status;
using PayLibrary.TCl550Universite;
using PayLibrary.TRH02Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MudBlazor.CategoryTypes;


namespace AlphaPayRoll.Components.Pages.ContratModif
{
    public class THR05ContratModifBase : Microsoft.AspNetCore.Components.ComponentBase
    {

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        //[Inject]
        //protected SessionService osessionService { get; set; }
        public ClasSessionStorage osessionService { set; get; }

        [Inject]
        protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }

        [Inject]
        protected ITHR05ContratModif oTHR05ContratModifService { get; set; }
        public List<THR05ContratModif> oTHR05ContratModifList { set; get; }
       
        [Inject]
        protected ITCl550Sexe oTCl550SexeService { set; get; }
        public List<ClassTCl550Sexe> oTCl550SexeList { set; get; }

        [Inject]
        protected ITCl550MaritStatus oTCl550MaritStatusService { set; get; }
        public List<ClassTCl550MaritStatus> oTCl550MaritStatusList { set; get; }

        [Inject]
        protected ITCl550Branch oTCl550BranchService { set; get; }
        public List<ClassTCl550Branch> oTCl550BranchList { set; get; }

        [Inject]
        protected ITSc551User oTCl550UserService { set; get; }
        public List<TSc551User> oTCl550UserList { set; get; }

        [Inject]
        protected ITCl550NivEtudId oTCl550NivEtudIdService { set; get; }
        public List<ClassTCl550NivEtudId> oTCl550NivEtudIdList { set; get; }
        [Parameter]
        public int paramAgentId { set; get; }

        [Inject]
        protected ITCl550DomEtud oTCl550DomEtudService { set; get; }
        public List<ClassTCl550DomEtud> oTCl550DomEtudList { set; get; }

        [Inject]
        protected ITCl550Departement oTCl550DepartementService { set; get; }
        public List<ClassTCl550Departement> oTCl550DepartementList { set; get; }

        [Inject]
        protected ITCl550Fonction oTCl550FonctionService { set; get; }
        public List<ClassTCl550Fonction> oTCl550FonctionList { set; get; }

        [Inject]
        protected ITCl550Status oTCl550StatusService { set; get; }
        public List<ClassTCl550Status> oTCl550StatusList { set; get; }
        [Inject]
        protected ITCl550Universite oTCl550UniversiteService { set; get; }
        public List<ClassTCl550Universite> oTCl550UniversiteList { set; get; }

        [Inject]
        protected ITCl550Deplom oTCl550DeplomService { set; get; }
        public List<ClassTCl550Deplom> oTCl550DeplomList { set; get; }

        [Inject]
        protected ITCl550NatIDType oTCl550NatIDTypeService { set; get; }
        public List<ClassTCl550NatIDType> oTCl550NatIDTypeList { set; get; }

        [Inject]
        private ITabPrmNivOne oTabPrmNivOneService { set; get; }
        public List<TabPrmNivOne> TRH550CategContratList { set; get; }
        public List<TabPrmNivOne> TRH550TypeSalaireList { set; get; }

        public List<TabPrmNivOne> TRH550StatusContratList { set; get; }


        [Parameter]
        public string id { set; get; }
        public THR05ContratModif oOneCotrat { set; get; }


        [Inject]
        protected IPersonnel_RIM2 oPersonnel_RIM2Service { set; get; }
        public List<ClassPersonnel_RIM2> oPersonnel_RIM2List { set; get; }


        [Inject]
        protected ITRH02Agent oTRH02AgentService { set; get; }
        public List<ClassTRH02Agent> oTRH02AgentList { set; get; }

        [Inject]
        protected IClasContrat oContratService { set; get; }

        public List<ClasContrat> oContratList { set; get; }

        //==============
    
        public ClassTRH02Agent oOneTRH02Agent { set; get; }
        //==================
        public string getRowColor(int i)
        {
            return (i % 2 == 0) ? "table-info" : "table-light";
        }


        //=================================================================================
        public bool isLoading { set; get; } = true;

        protected bool popup = false;

        public ClasContrat oSelectedContrat { get; set; }
        public string StyleButton { set; get; }
        public string ButtonCaption { set; get; }

        public string modalTitle { set; get; }

        public int iTypeAction { set; get; }

        protected async Task ShowPopUp(int tPAction)
        {

            if (tPAction == 0)
            {
                modalTitle = " Contrat Modif. Detail";
            }
            if (tPAction == 2)
            {
                modalTitle = "Modification Contrat ";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
            }
            else if (tPAction == 3)
            {
                modalTitle = "Supprimer  Contrat Modif.  ";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";

                oOneCotrat.LModifBy = int.Parse(osessionService.UserId);
                oOneCotrat.LModifOn = DateTime.Now;

            }



            if (tPAction == 1)
            {


                modalTitle = "Ajouter Contrat Modif.";

                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";


                iTypeAction = tPAction;
                oOneCotrat = new THR05ContratModif();

                oOneCotrat.ID = 0;
                oOneCotrat.CreatOn = DateTime.Now;
                oOneCotrat.Matricule = sMatricule;
               
                oOneCotrat.CreatOn = DateTime.Today;
                oOneCotrat.CreatBy = int.Parse(osessionService.UserId);


            }
            else
            {

            }


            oResultat = new Resultat();

            //await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
            oTHR05ContratModifList = await oTHR05ContratModifService.GetContratModifByMatricule(id);

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
                var param = new ParamValidContratModif
                {
                    ID = id,
                    UserID = int.Parse(osessionService.UserId)
                };
                //await JSRuntime.InvokeVoidAsync("alert", $"ID: {param.ID}, UserID: {param.UserID}");


                var result = await oTHR05ContratModifService.ValiderContratModif(param);
                await JSRuntime.InvokeVoidAsync("alert", "Message" + result.Result);
                oTHR05ContratModifList = await oTHR05ContratModifService.GetContratModifByMatricule(sMatricule);


            }
            catch (Exception ex)
            {
                await JSRuntime.InvokeVoidAsync("alert", $"An error occurred: {ex.Message}");
                Console.WriteLine($"Error in ValidateData: {ex}");
            }
        }



        protected void EditData(THR05ContratModif item, int TpAction)
        {

            iTypeAction = TpAction;
            oOneCotrat = item;

            ShowPopUp(iTypeAction);

        }


        Resultat oResultat = new Resultat();

        protected async Task SaveContrat(THR05ContratModif item)
        {



            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment supprimer ceci ?"))
                    return;
            }
            else if (oOneCotrat.Raison == "" || oOneCotrat.Raison == null)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Raison est obligatoire");
                return;
            }
            else if (oOneCotrat.Observations == "" || oOneCotrat.Observations == null)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Observations est obligatoire");
                return;
            }
            else if (oOneCotrat.OldContNumber == "" || oOneCotrat.OldContNumber == null)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Ancien type Contrat est obligatoire");
                return;
            }
            else if (oOneCotrat.NewContNumber == "" || oOneCotrat.NewContNumber == null)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Nouveau type Contrat est obligatoire");
                return;
            }


            try
            {


                oOneCotrat.TpMaj = iTypeAction;
                oOneCotrat.UserID = int.Parse(osessionService.UserId);
                oOneCotrat.OldContNumber = oSelectedContrat.NumContrat;
                //oOneCotrat.NewContNumber = oOneCotrat.NewContNumber;
                oResultat = new Resultat();

                oResultat = await oTHR05ContratModifService.GetResutUpdate(item);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
                oTHR05ContratModifList = await oTHR05ContratModifService.GetContratModifByMatricule(id);

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

        public void DonAgentSuite(THR05ContratModif pContrat)
        {
            var agent = oTRH02AgentList?.FirstOrDefault(a => a.Matricule == pContrat.Matricule);

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

        public string sMatricule { set; get; }

        //select contract number,type of user
        public int ContTypeID { get; set; }
        public string ContratOldType { get; set; }
        // end

        public async Task searchByMatricule()
        {
            //var matricule = oOneTRH02Agent.Matricule;

            if (string.IsNullOrWhiteSpace(sMatricule))
            {
                await JSRuntime.InvokeVoidAsync("alert", "Please enter a Matricule.");
                return;
            }

            try
            {
                isLoading = true;

                // 🔍 Search the agent
                oTRH02AgentList = await oTRH02AgentService.GetAgentByMatricule(sMatricule);
                if (oTRH02AgentList.Count > 0)
                {
                    // check if selected user's contract is validated
                    oContratList = await oContratService.GetContractByMatricule(sMatricule);

                    if (oContratList != null && oContratList.Any())
                    {
                        oSelectedContrat = oContratList
                                    .OrderByDescending(c => c.CreatOn)
                                    .FirstOrDefault();

                        if (oSelectedContrat.ValidBy != 0 || oSelectedContrat.ValidOn != null)
                        {
                            sNomPrenom = oTRH02AgentList[0].Nom.Trim() + " " + oTRH02AgentList[0].Prenom.Trim();
                            oTHR05ContratModifList = await oTHR05ContratModifService.GetContratModifByMatricule(sMatricule);
                            bAddDisabled = false;

                        }
                        else
                        {
                            bAddDisabled = true;
                            await JSRuntime.InvokeVoidAsync("alert", $"Contract with this matricule: {sMatricule} is not Valid");
                        }
                    }
                    else

                    {
                        bAddDisabled = true;
                        await JSRuntime.InvokeVoidAsync("alert", $"No Contract with this matricule: {sMatricule}");
                    }

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
            }
        }

        //end of searchBymatricule


        public bool bAddDisabled { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");
            try
            {
                oSelectedContrat = new ClasContrat();

                oOneCotrat = new THR05ContratModif();

                oTHR05ContratModifList = await oTHR05ContratModifService.GetContratModifByMatricule(id);  // after search

                oOneTRH02Agent = new ClassTRH02Agent();
                //oTRH02AgentList = await oTRH02AgentService.GetAgentByMatricule("RIM00002");


                oTCl550SexeList = await oTCl550SexeService.GetTCl550Sexe();
                oTCl550MaritStatusList = await oTCl550MaritStatusService.GetTCl550MaritStatus();
                oTCl550BranchList = await oTCl550BranchService.GetT550Branch();
                oTCl550UserList = await oTCl550UserService.GetList();



                oTCl550NivEtudIdList = await oTCl550NivEtudIdService.GetTCl550NivEtudId();
                oTCl550DomEtudList = await oTCl550DomEtudService.GetTCl550DomEtud();


                oTCl550DepartementList = await oTCl550DepartementService.GetTCl550Departement();
                oTCl550FonctionList = await oTCl550FonctionService.GetTCl550Fonction();

                oTCl550UniversiteList = await oTCl550UniversiteService.GetTCl550Universite();

                oTCl550NatIDTypeList = await oTCl550NatIDTypeService.GetIdType();



                TRH550CategContratList = (await oTabPrmNivOneService.GetDBListName("TRH550CategContrat")).ToList();
                TRH550TypeSalaireList = (await oTabPrmNivOneService.GetDBListName("TRH550TypeSalaire")).ToList();

                TRH550StatusContratList = (await oTabPrmNivOneService.GetDBListName("TRH550StatusContrat")).ToList();

                oTRH02AgentList = await oTRH02AgentService.GetAgentByMatricule(id);


                osessionService.NvFenet = id;
                if (oTRH02AgentList.Count > 0)
                {
                    sNomPrenom = oTRH02AgentList[0].Nom.Trim() + " " + oTRH02AgentList[0].Prenom.Trim();

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
    }
}
