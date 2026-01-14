using AlphaPayRoll.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.Cl550Branch;
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
using PayLibrary.TCl550User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaPayRoll.Components.Pages.Personnel_RIM2
{
    public class Personnel_RIM2PageBase:ComponentBase
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected SessionService osessionService { get; set; }

        [Inject]
        protected IPersonnel_RIM2 oPersonnel_RIM2Service { set; get; }

        public List<ClassPersonnel_RIM2> oPersonnel_RIM2List { set; get; }


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
        protected ITCl550User oTCl550UserService { set; get; }
        public List<ClassTCl550User> oTCl550UserList { set; get; }

        [Inject]
        protected ITCl550NivEtudId oTCl550NivEtudIdService { set; get; }
        public List<ClassTCl550NivEtudId> oTCl550NivEtudIdList { set; get; }
     

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

        [Parameter]
        public string id { set; get; }
        public ClassPersonnel_RIM2 oOnePersonnel_RIM2 { set; get; }


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
        [Parameter]
        public int paramAgentId { set; get; }
        protected void ShowPopUp(int tPAction)
        {

            if (tPAction == 0)
            {
                modalTitle = " Person Detail";
            }
            if (tPAction == 2)
            {
                modalTitle = "Edit  Personnel Detail";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
            }
            else if (tPAction == 3)
            {
                modalTitle = "Delete  Personnel Detail";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";

                oOnePersonnel_RIM2.LModifBy = osessionService.UserId;
                oOnePersonnel_RIM2.LModifOn = DateTime.Now;

            }

            if (tPAction == 1)
            {


                modalTitle = "Ajouter Personnel";

                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";


                iTypeAction = tPAction;
                oOnePersonnel_RIM2 = new ClassPersonnel_RIM2();

                oOnePersonnel_RIM2.ID = 0;
                oOnePersonnel_RIM2.CreatBy = osessionService.UserId;
                oOnePersonnel_RIM2.CreatOn = DateTime.Now;
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
        public void DonAgentSuite(ClassPersonnel_RIM2 pAgent)
        {
            AgentID = pAgent.ID;
            SalaireBase = pAgent.ID;
            AgentSelected = true;

            sNomAgent = pAgent.NOM.Trim() + " " + pAgent.PRENOMS.Trim();
            sNomAgent = pAgent.PRENOMS.Trim() + " " + pAgent.PRENOMS.Trim();
            sNomAgent = pAgent.NUM_MATRICULE.Trim() + " " + pAgent.PRENOMS.Trim();
        }
        public void BackToAgent()
        {
            AgentSelected = false;

        }

        protected void ClosePopUp()
        {
            popup = false;
        }

        protected void EditData(ClassPersonnel_RIM2 item, int TpAction)
        {

            iTypeAction = TpAction;
            oOnePersonnel_RIM2 = item;

            ShowPopUp(iTypeAction);

        }


        Resultat oResultat = new Resultat();

        protected async Task SavePersonnel_RIM2(ClassPersonnel_RIM2 item)
        {



            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment supprimer ceci ??"))
                    return;
            }


            try
            {


                oOnePersonnel_RIM2.TpMaj = iTypeAction;
                oOnePersonnel_RIM2.UserID = osessionService.UserId;

                oResultat = new Resultat();

                oResultat = await oPersonnel_RIM2Service.GetResutUpdate(item);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
                oPersonnel_RIM2List = await oPersonnel_RIM2Service.GetPersonnelAll();

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

        public async Task Rechercher()
        {
            if (sNomRecherche == null || sNomRecherche.Trim() != "")
            {
                oPersonnel_RIM2List = await oPersonnel_RIM2Service.GetPersonnelRech(sNomRecherche);
            }
            else
            {
                oPersonnel_RIM2List = await oPersonnel_RIM2Service.GetPersonnelAll();
            }

            oPersonnel_RIM2List = oPersonnel_RIM2List.OrderBy(row => row.NOM).ToList();
            oPersonnel_RIM2List = oPersonnel_RIM2List.OrderBy(row => row.PRENOMS).ToList();
            oPersonnel_RIM2List = oPersonnel_RIM2List.OrderBy(row => row.NUM_MATRICULE).ToList();

        }
        public string TypeAffichage { set; get; }
        public void ParamAgent()
        {
            TypeAffichage = "AgentUniquement";
        }
        protected override async Task OnInitializedAsync()
        {
            try
            {
            oOnePersonnel_RIM2 = new ClassPersonnel_RIM2();

            oPersonnel_RIM2List = await oPersonnel_RIM2Service.GetPersonnelAll();
          //  oPersonnel_RIM2List = await oPersonnel_RIM2Service.GetPersonnelAll(paramAgentId);
            oTCl550SexeList = await oTCl550SexeService.GetTCl550Sexe();
            oTCl550MaritStatusList = await oTCl550MaritStatusService.GetTCl550MaritStatus();
            oTCl550BranchList = await oTCl550BranchService.GetT550Branch();
            oTCl550UserList = await oTCl550UserService.GetTCl550User();
            oTCl550NivEtudIdList = await oTCl550NivEtudIdService.GetTCl550NivEtudId();

            oTCl550DomEtudList = await oTCl550DomEtudService.GetTCl550DomEtud();
            oTCl550DepartementList = await oTCl550DepartementService.GetTCl550Departement();
            oTCl550FonctionList = await oTCl550FonctionService.GetTCl550Fonction();
            oTCl550UniversiteList = await oTCl550UniversiteService.GetTCl550Universite();

            oTCl550NatIDTypeList = await oTCl550NatIDTypeService.GetIdType();

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
