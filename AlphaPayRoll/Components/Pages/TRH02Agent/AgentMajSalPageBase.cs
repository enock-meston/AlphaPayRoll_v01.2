using AlphaPayRoll.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.Cl550Branch;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Personnel_RIM2;
using PayLibrary.TCl550Departement;
using PayLibrary.TCl550Deplom;
using PayLibrary.TCl550DomEtud;
using PayLibrary.TCl550Fonction;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TCl550NivEtudId;
using PayLibrary.TCl550Sexe;
using PayLibrary.TCl550Status;
using PayLibrary.TCl550Universite;
using PayLibrary.TCl550User;
using PayLibrary.TRH02Agent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;
using PayLibrary.ParamSec;

namespace AlphaPayRoll.Components.Pages.TRH02Agent
{
    public class AgentMajSalPageBase : ComponentBase
    {



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
        public List<ClassTRH02Agent> oTRH02AgentList2 { set; get; }


        [Inject]
        protected ITSc551SubBranch oTCl550SubBranchService { set; get; }
        public List<TSc551SubBranch> oTCl550SubBranchLocList { set; get; }
        public List<TSc551SubBranch> oTCl550SubBranchLocList2 { set; get; }

        public List<TSc551SubBranch> oTCl550SubBranchCpteList { set; get; }
        public List<TSc551SubBranch> oTCl550SubBranchCpteList2 { set; get; }


        [Inject]
        protected ITCl550Branch oTCl550BranchService { set; get; }
        public List<ClassTCl550Branch> oTCl550BranchLocList { set; get; }
        public List<ClassTCl550Branch> oTCl550BranchCpteList { set; get; }



        [Inject]
        protected ITCl550Status oTCl550StatusService { set; get; }
        public List<ClassTCl550Status> oTCl550StatusList { set; get; }



        [Inject]
        protected ITSc551User oTCl550UserService { set; get; }
        public List<TSc551User> oTCl550UserList { set; get; }

        [Inject]
        protected IPersonnel_RIM2 oOnePersonnel_RIM2Service { set; get; }
        public List<ClassPersonnel_RIM2> oOnePersonnel_RIM2List { set; get; }


        public ClassTRH02Agent oOneTRH02Agent { set; get; }

        [Parameter]
        public string id { get; set; }
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


        public bool AgentSelected { set; get; } = false;

        public int AgentID { set; get; }
        public decimal SalaireBase { set; get; }
        public string sNomAgent { set; get; }
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

        public void ShowPopUp(int tPAction)
        {


            if (tPAction != 1)
            {
                pBranchCpteID = oOneTRH02Agent.BranchCpteID;
                pBranchLocID = oOneTRH02Agent.BranchLocID;
                pSubBranchCpteID = oOneTRH02Agent.SBranchCpteID;
                pSubBranchLocID = oOneTRH02Agent.SBranchLocID;


            }




            if (tPAction == 0)
            {
                modalTitle = "Agent Detail";
            }
            if (tPAction == 2)
            {
                modalTitle = "Edit Agent Detail";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";

            }
            else if (tPAction == 3)
            {
                modalTitle = "Delete Agent Detail";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";

                oOneTRH02Agent.LModifBy = int.Parse(osessionService.UserId);
                oOneTRH02Agent.LModifOn = DateTime.Now;

            }



            if (tPAction == 1)
            {


                pBranchCpteID = "0";
                pSubBranchCpteID = "0";
                pSubBranchLocID = pBranchLocID + "1";


                modalTitle = "Ajouter Agent";

                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";


                iTypeAction = tPAction;
                oOneTRH02Agent = new ClassTRH02Agent();

                oOneTRH02Agent.StatusId = 1;
                oOneTRH02Agent.Matricule = "0";
                oOneTRH02Agent.AgentId = 0;
                oOneTRH02Agent.DateRecrutment = DateTime.Today;
                oOneTRH02Agent.LModifBy = int.Parse(osessionService.UserId);
                oOneTRH02Agent.CreatOn = DateTime.Now;




            }
            else
            {

            }

            popup = true;
        }


        public void ClosePopUp()
        {
            popup = false;
        }

        public void EditData(ClassTRH02Agent item, int TpAction)
        {

            iTypeAction = TpAction;
            oOneTRH02Agent = item;

            ShowPopUp(iTypeAction);

        }


        Resultat oResultat = new Resultat();

        public async Task SaveTRH02Agent(ClassTRH02Agent item)
        {
            DateTime xx;

            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment supprimer ceci ?"))
                    return;
            }
            else

            {
                if (oOneTRH02Agent.ClientId == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Entrer le compte de l' employé");
                    return;
                }

                if (oOneTRH02Agent.Prenom.Length < 3)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "le nom de l'employé doit avoir plus de 3 caractères");
                    return;
                }

                if (oOneTRH02Agent.Nom == null)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Entrer le nom de l'employé");
                    return;
                }

                if (oOneTRH02Agent.Nom.Length < 3)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "le nom de l'employé doit avoir plus de 3 caractères");
                    return;
                }

                if (oOneTRH02Agent.Prenom == null)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Entrer le prénom de l'employé");
                    return;
                }

                if (oOneTRH02Agent.Prenom.Length < 2)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "le prénom de l'employé doit avoir plus de 2 caractères");
                    return;
                }


                if (oOneTRH02Agent.BranchLocID == "")
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Sélectionner une agence SVP !");
                    return;
                }

                if (oOneTRH02Agent.BranchLocID == "")
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Sélectionner une agence SVP !");
                    return;
                }



                if (oOneTRH02Agent.StatusId == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Sélectionner un statut SVP !");
                    return;
                }

                if (oOneTRH02Agent.SalBase < 100)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Entrer un salaire de base correct SVP !");
                    return;
                }


            }
            try
            {

                osessionService.UserId = "90";
                oOneTRH02Agent.TpMaj = iTypeAction;
                oOneTRH02Agent.UserID = int.Parse(osessionService.UserId);

                oResultat = new Resultat();

                oResultat = await oTRH02AgentService.GetResutMajSalaire(item);

                oTRH02AgentList = await oTRH02AgentService.GetAgent();

                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);



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

            }

        }



        //=========================================================================================

        public bool isLoading { set; get; } = true;

        public string CurrencyFormat { set; get; } = "###,##0";

        public string sNomRecherche { set; get; }

        public async Task Rechercher()
        {
            if (sNomRecherche == null || sNomRecherche.Trim() != "")
            {
                oTRH02AgentList = await oTRH02AgentService.GetAgentRech(sNomRecherche);
            }
            else
            {
                oTRH02AgentList = await oTRH02AgentService.GetAgent();
            }

            oTRH02AgentList = oTRH02AgentList.OrderBy(row => row.Nom).ToList();

        }

        public string TypeAffichage { set; get; }
        public void ParamAgent()
        {
            TypeAffichage = "AgentUniquement";
        }


        public async Task PrintDocument()
        {
            string url = $"http://localhost:19143/api/Listpayconsolid/rptListPayConsolid/?id=1";
            await JSRuntime.InvokeAsync<object>("open", CancellationToken.None, url);
        }

        public string pBranchLocID = "0";
        public string pBranchCpteID = "0";
        public string pSubBranchLocID = "0";
        public string pSubBranchCpteID = "0";

        public void BranchLocChanged(string Value)
        {
            pBranchLocID = Value;

            oTRH02AgentList = oTRH02AgentList2.Where(row => row.BranchLocID.Trim() == pBranchLocID.Trim()).ToList();
            oTCl550SubBranchLocList = oTCl550SubBranchLocList2.Where(row => row.CodeBranch == pBranchLocID).ToList();

        }
        public void BranchCpteChanged(string Value)
        {
            pBranchCpteID = Value;

            oTCl550SubBranchCpteList = oTCl550SubBranchCpteList2.Where(row => row.CodeBranch == pBranchCpteID).ToList();

        }

        public void SubBranchLocChanged(string Value)
        {
            pSubBranchLocID = Value;
            oOneTRH02Agent.SBranchLocID = Value;
            oTRH02AgentList = oTRH02AgentList2.Where(row => row.SBranchLocID.Trim() == pBranchLocID).ToList();


        }

        public void SubBranchCpteChanged(string Value)
        {
            pSubBranchCpteID = Value;
            oOneTRH02Agent.SBranchCpteID = Value;

        }

        protected override async Task OnInitializedAsync()
        {
            osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");

            try
            {

                oOneTRH02Agent = new ClassTRH02Agent();
                oTCl550BranchLocList = await oTCl550BranchService.GetT550Branch();
                oTCl550BranchCpteList = oTCl550BranchLocList;

                oTCl550StatusList = await oTCl550StatusService.GetTCl550Status();
                oTCl550UserList = await oTCl550UserService.GetList();

                oTCl550SubBranchLocList = await oTCl550SubBranchService.GetList();
                oTCl550SubBranchLocList2 = oTCl550SubBranchLocList;

                oTCl550SubBranchCpteList = oTCl550SubBranchLocList;
                oTCl550SubBranchCpteList2 = oTCl550SubBranchLocList;


                oTRH02AgentList = await oTRH02AgentService.GetAgent();
                oTRH02AgentList = oTRH02AgentList.OrderBy(row => row.Matricule).ToList();
                oTRH02AgentList2 = oTRH02AgentList;

                ///oOnePersonnel_RIM2List = await oOnePersonnel_RIM2Service.GetPersonnelAll();

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


