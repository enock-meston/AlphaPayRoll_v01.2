using AlphaPayRoll.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.Cl550Branch;
using PayLibrary.CONTRACT_GOMISE;
using PayLibrary.Contrat;
using PayLibrary.ContratSusp;
using PayLibrary.General;
using PayLibrary.InterfParamSec;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec;
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
using PayLibrary.TRH550TypeSalaire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaPayRoll.Components.Pages.ContratSusp
{
    public class TRH03ContratSuspBase : ComponentBase
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        public ClasSessionStorage osessionService { set; get; }

        [Inject]
        protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }

        [Inject]
        protected ITRH03ContratSusp oContratService { set; get; }

        public List<TRH03ContratSusp> oContratList { set; get; }

        [Inject]
        protected IClasContrat oSelectedContratService { set; get; }

        public List<ClasContrat> oSelectedContratList { set; get; }

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
        public TRH03ContratSusp oOneCotrat { set; get; }


        [Inject]
        protected IPersonnel_RIM2 oPersonnel_RIM2Service { set; get; }
        public List<ClassPersonnel_RIM2> oPersonnel_RIM2List { set; get; }


        [Inject]
        protected ITRH02Agent oTRH02AgentService { set; get; }
        public List<ClassTRH02Agent> oTRH02AgentList { set; get; }

        // type de conge 
        [Inject]
        protected ITRH550TypeSalaire oTRH550TypeSalaire { set; get; }
        public List<TRH550TypeSalaire> oTRH550TypeSalaireList { set; get; }

        // end type de conge


        //==============
        public ClasContrat oSelectedContrat { get; set; }


        public ClassTRH02Agent oOneTRH02Agent { set; get; }
        //==================
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
                modalTitle = " Contrat Detail";
            }
            if (tPAction == 2)
            {
                modalTitle = "Mofifier Contrat Detail";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";

            }
            else if (tPAction == 3)
            {


                modalTitle = "Supprimer  Contrat Detail";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";
                oOneCotrat.LModifBy = int.Parse(osessionService.UserId);
                oOneCotrat.LModifOn = DateTime.Today;
            }

            if (tPAction == 1)
            {

                DateTime DateFinProbable = DateTime.Today.AddYears(200).AddDays(-1);
                DateTime DateFin = DateTime.Now;

                modalTitle = "Ajouter Contract";

                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
                iTypeAction = tPAction;
                if (oOneCotrat == null || string.IsNullOrEmpty(oOneCotrat.MATRICULE ))
                {
                    oOneCotrat = new TRH03ContratSusp();
                    oOneCotrat.ID = 0;
                    oOneCotrat.CreatBy = int.Parse(osessionService.UserId);
                    oOneCotrat.CreatOn = DateTime.Now;
                    oOneCotrat.LModifOn = DateTime.Now;
                    oOneCotrat.MATRICULE = sMatricule;
                    oOneCotrat.DateDebut = DateTime.Today;
                    oOneCotrat.DateFinProbable = DateFinProbable;
                    oOneCotrat.DateChangStatus = DateTime.Today;
                    oOneCotrat.DateFin = DateFin;
                }

            }
           

            popup = true;
        }

        public bool AgentSelected { set; get; } = false;

        public int AgentID { set; get; }
        public decimal SalaireBase { set; get; }
        public string sNomAgent { set; get; }


        public void DonAgentSuite(TRH03ContratSusp pContrat)
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
                var param = new ParamValidContrat
                {
                    ID = id,
                    UserID = int.Parse(osessionService.UserId)
                };
                //await JSRuntime.InvokeVoidAsync("alert", $"ID: {param.ID}, UserID: {param.UserID}");


                var result = await oContratService.ValiderSusCotrat(param);
                await JSRuntime.InvokeVoidAsync("alert", "Message" + result.Result);
                oContratList = await oContratService.GetSusContractByMatricule(sMatricule);


            }
            catch (Exception ex)
            {
                await JSRuntime.InvokeVoidAsync("alert", $"An error occurred: {ex.Message}");
                Console.WriteLine($"Error in ValidateData: {ex}");
            }
        }


      


        protected void EditData(TRH03ContratSusp item, int TpAction)
        {

            iTypeAction = TpAction;
            oOneCotrat = item;

            ShowPopUp(iTypeAction);

        }


        Resultat oResultat = new Resultat();
        protected async Task SaveContrat(TRH03ContratSusp item)
        {



            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment supprimer ceci ?"))
                    return;
            }

            else if (oOneCotrat.Motif == "" || oOneCotrat.Notes == null)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Motif est obligatoire");
                return;
            }
            else if (oOneCotrat.Notes == null)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Notes est obligatoire");
                return;
            }
            else if (oOneCotrat.StatusID == 0)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Status contrat est obligatoire");
                return;
            }
            else if (oOneCotrat.Categorie == 0)
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le type contrat est obligatoire");
                return;
            }


            try
            {


                oOneCotrat.TpMaj = iTypeAction;
                oOneCotrat.UserID = int.Parse(osessionService.UserId);

                oOneCotrat.NumContrat = oSelectedContrat.NumContrat;


                oResultat = new Resultat();

                oResultat = await oContratService.GetResutUpdate(item);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
                oContratList = await oContratService.GetSusContractByMatricule(sMatricule);


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

        public string sMatricule { set; get; }

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
                    

                    sNomPrenom = oTRH02AgentList[0].Nom.Trim() + " " + oTRH02AgentList[0].Prenom.Trim();
                    oContratList = await oContratService.GetSusContractByMatricule(sMatricule);

                    oSelectedContratList = await oSelectedContratService.GetContractByMatricule(sMatricule);
                    oSelectedContrat = oSelectedContratList
                                            .OrderByDescending(c => c.CreatOn)
                                            .FirstOrDefault();

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
            }
        }

        //end of searchBymatricule

        public bool bAddDisabled { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");
            try
            {
                oOneCotrat = new TRH03ContratSusp();

                //oContratList = await oContratService.GetSusContractByMatricule(id);  // after search

                oOneTRH02Agent = new ClassTRH02Agent();

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
