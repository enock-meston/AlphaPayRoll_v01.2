using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayLibrary.TCl550Deplom;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TRH02Agent;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.Cl550Branch;
using PayLibrary.TCl550Departement;
using PayLibrary.TCl550Fonction;
using PayLibrary.TCl550NivEtudId;
using PayLibrary.TCl550DomEtud;
using PayLibrary.TCl550Universite;
using PayLibrary.TCl550Status;
using PayLibrary.TCl550User;
using PayLibrary.TCl550Sexe;
using Microsoft.Extensions.Logging;
using PayLibrary.ParamSec.ViewModel;
using AlphaPayRoll.Data;
using System.Linq;
using PayLibrary.Personnel_RIM2;
using System.Threading;
using AlphaPayRoll.DataServices.ParamSec;
using PayLibrary.ParamDonBase;
using PayLibrary.InterfParamSec;
using PayLibrary.ParamSec;
using PayLibrary.InterfPrmDonBase;

namespace AlphaPayRoll.Components.Pages.TRH02Agent
{
    public class AgentPageBase : ComponentBase
    {


        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        public ClasSessionStorage osessionService { set; get; }

        [Inject]
        protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }


        [Inject]
        protected ITRH02Agent oTRH02AgentService { set; get; }

        public List<ClassTRH02Agent> oTRH02AgentList { set; get; }
        public List<ClassTRH02Agent> oTRH02AgentList2 { set; get; }


        //Maried Status

        [Inject]
        protected ITCl550MaritStatus oTCl550MaritStatusService { set; get; }

        public List<ClassTCl550MaritStatus> oTCl550MaritStatusList { set; get; }


        //Deplom

        [Inject]
        protected ITCl550Deplom oTCl550DeplomService { set; get; }
        public List<ClassTCl550Deplom> oTCl550DeplomList { set; get; }


        [Inject]
        public NavigationManager oNav { set; get; }

        [Inject]
        protected ITSc551SubBranch oTCl550SubBranchService { set; get; }
        public List<TSc551SubBranch> oTCl550SubBranchList { set; get; }

        [Inject]
        protected ITCl550Branch oTCl550BranchService { set; get; }
        public List<ClassTCl550Branch> oTCl550BranchList { set; get; }


        [Inject]
        protected ITCl550Sexe oTCl550SexeService { set; get; }
        public List<ClassTCl550Sexe> oTCl550SexeList { set; get; }



        [Inject]
        protected ITCl550NivEtudId oTCl550NivEtudIdService { set; get; }
        public List<ClassTCl550NivEtudId> oTCl550NivEtudIdList { set; get; }

        [Inject]
        protected ITCl550Universite oTCl550UniversiteService { set; get; }
        public List<ClassTCl550Universite> oTCl550UniversiteList { set; get; }


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
        protected ITSc551User oTCl550UserService { set; get; }
        public List<TSc551User> oTCl550UserList { set; get; }

        [Inject]
        protected IPersonnel_RIM2 oOnePersonnel_RIM2Service { set; get; }
        public List<ClassPersonnel_RIM2> oOnePersonnel_RIM2List { set; get; }

        [Inject]
        private ITabPrmNivOne oTabPrmNivOneService { set; get; }
        public List<TabPrmNivOne> oTSc550EmplyeeMenu { set; get; }



        [Inject]
        protected ITSc551SubMenu oSubMenuService { set; get; }


        protected List<TSc551SubMenu> oSubMenuList { set; get; }


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
        public string sMatNomPrenom { set; get; }
        public string sMatricule { set; get; }
        public void SelectAgent(ClassTRH02Agent pAgent)
        {
            AgentID = pAgent.AgentId;
            //SalaireBase = pAgent.SalBase;
            AgentSelected = true;
            sMatricule = pAgent.Matricule.Trim();
            sMatNomPrenom = pAgent.Matricule.Trim() + " / " + pAgent.Nom.Trim() + " " + pAgent.Prenom.Trim();

            popupSubMenu = true;
        }
        public void BackToAgent()
        {
            AgentSelected = false;

        }

        protected void ShowPopUp(int tPAction)
        {

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
            if (tPAction != 1)
            {
                pSubBranchID = oOneTRH02Agent.SBranchLocID;
                pBranchID = pSubBranchID.Substring(0, 2);
                pSubBranchIDCont = oOneTRH02Agent.SBranchCpteID;
                pBranchIDCont = pSubBranchIDCont.Substring(0, 2);

            }


            if (tPAction == 1)
            {


                modalTitle = "Ajouter Agent";

                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";


                iTypeAction = tPAction;
                oOneTRH02Agent = new ClassTRH02Agent();

                oOneTRH02Agent.AgentId = 0;
                oOneTRH02Agent.DateRecrutment = DateTime.Today;
                oOneTRH02Agent.CreatBy = int.Parse(osessionService.UserId);
                oOneTRH02Agent.CreatOn = DateTime.Now;
            }
            else
            {

            }

            popup = true;
        }


        protected void ClosePopUp()
        {
            popup = false;
        }

        protected async Task EditData(ClassTRH02Agent item, int TpAction)
        {
            //await JSRuntime.InvokeVoidAsync("alert", osessionService.UserId);

            iTypeAction = TpAction;
            oOneTRH02Agent = item;

            ShowPopUp(iTypeAction);

        }


        Resultat oResultat = new Resultat();

        protected async Task SaveTRH02Agent(ClassTRH02Agent item)
        {
            DateTime xx;

            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment supprimer ceci  ?"))
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

                if (DateTime.TryParse(oOneTRH02Agent.DateNais.ToString(), out xx) == false)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Entrer une date de naissance correcte");
                    return;
                }

                if (oOneTRH02Agent.DateNais.Year < 1900 || (DateTime.Today.Year - oOneTRH02Agent.DateNais.Year) < 18)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "L'âge d'employé est incorrect ");
                    return;
                }




                if (oOneTRH02Agent.Sexe == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Sélectionner un genre SVP !");
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

                if (oOneTRH02Agent.DepartementId == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Sélectionner un département SVP !");
                    return;
                }

                if (oOneTRH02Agent.FonctionId == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Sélectionner une fonction SVP !");
                    return;
                }

                if (oOneTRH02Agent.DateRecrutment > DateTime.Now || (DateTime.Today.Year - oOneTRH02Agent.DateRecrutment.Year) > 80)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Entrer une date de recrutement correcte SVP !");
                    return;
                }


                if (oOneTRH02Agent.Telephone == null)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Entrer un numéro de téléphone SVP !");
                    return;
                }

                if (oOneTRH02Agent.Telephone.Length < 7)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Entrer un numéro de téléphone correct SVP !");
                    return;
                }

                if (oOneTRH02Agent.IdNum == null)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Entrer un numéro d'identité SVP !");
                    return;
                }

                if (oOneTRH02Agent.IdNum.Length < 3)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Entrer un numéro d'identité correct SVP !");
                    return;
                }

                if (oOneTRH02Agent.Email == null)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Entrer email SVP !");
                    return;
                }

                if (oOneTRH02Agent.Email.Length < 3)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Entrer un email correct SVP !");
                    return;
                }

                if (oOneTRH02Agent.NumCSR == null)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Entrer un numéro RSSB Number SVP !");
                    return;
                }

                if (oOneTRH02Agent.NumCSR.Length < 3)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Entrer un numéro RSSB Number  !");
                    return;
                }

                if (oOneTRH02Agent.NivEtudId == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Sélectionner un niveau d'étude SVP !");
                    return;
                }

                if (oOneTRH02Agent.DomEtudId == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Sélectionner un domaine d'étude SVP !");
                    return;
                }

                if (oOneTRH02Agent.DiplomId == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Sélectionner un diplôme SVP !");
                    return;
                }

                if (oOneTRH02Agent.UniverId == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Sélectionner une université SVP !");
                    return;
                }

                if (oOneTRH02Agent.StatusId == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Sélectionner un statut SVP !");
                    return;
                }

                //if (oOneTRH02Agent.SalBase < 100)
                //{
                //    await JSRuntime.InvokeVoidAsync("alert", "Entrer un salaire de base correct SVP ! !");
                //    return;
                //}
                try
                {


                    oOneTRH02Agent.TpMaj = iTypeAction;
                    oOneTRH02Agent.UserID = int.Parse(osessionService.UserId);

                    oResultat = new Resultat();

                    oResultat = await oTRH02AgentService.GetResutUpdate(item);
                    await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
                    oTRH02AgentList = await oTRH02AgentService.GetAgent();

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
        }



        //=========================================================================================

        public bool isLoading { set; get; } = true;

        public string CurrencyFormat { set; get; } = "###,##0";

        public string sNomRecherche { set; get; }

        public async Task Rechercher()
        {

            //if (sNomRecherche == null || sNomRecherche.Trim() != "")
            //{
            //await JSRuntime.InvokeVoidAsync("alert", sNomRecherche);
            //    oTRH02AgentList = await oTRH02AgentService.GetAgentRech(sNomRecherche);
            //    //oTRH02AgentList = oTRH02AgentList.OrderBy(row => row.Nom).ToList();
            //}
            //else
            //{
            //    oTRH02AgentList = await oTRH02AgentService.GetAgent();

            //}

            if (pBranchID == null || pBranchID =="")
            {
                oTRH02AgentList = await oTRH02AgentService.GetAgentRech(sNomRecherche);
              

            }
            else if(sNomRecherche == null || sNomRecherche =="")
            {
                  oTRH02AgentList = await oTRH02AgentService.GetAgentBySubBranch(pBranchID);
               
            } else

            {
                oTRH02AgentList = await oTRH02AgentService.GetAgent();
            }
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

        public string pBranchID = "";
        public string pSubBranchID = "";
        public string pSubBranchIDCont = "";
        public string pBranchIDCont = "";


        public async Task BranchChanged(string Value)
        {
            //pBranchID = Value;
            pBranchID = "024";
            oTRH02AgentList = oTRH02AgentList2.Where(row => row.BranchLocID?.Trim() == pBranchID?.Trim()).ToList();
            oTRH02AgentList = await oTRH02AgentService.GetAgentBySubBranch(pBranchID);

        }

        public async Task SubBranchChanged(string Value)
        {
            pBranchID = Value;
            oTRH02AgentList = oTRH02AgentList2.Where(row => row.BranchCpteID.Trim() == pBranchID.Trim()).ToList();
            oTRH02AgentList = await oTRH02AgentService.GetAgentBySubBranch(pBranchID);

        }

        public async Task SubBranchChangedCont(string Value)
        {
            //pBranchIDCont = Value;
            //oTRH02AgentList = oTRH02AgentList2.Where(row => row.BranchCpteID.Trim() == pBranchIDCont.Trim()).ToList();
            //oTRH02AgentList = await oTRH02AgentService.GetAgentBySubBranch(pBranchIDCont);

        }

        public int pMenuID = 0;

        public string sLien = "";

        public bool popupSubMenu { set; get; } = false;


        public void ClosePopUpMenu()
        {
            popupSubMenu = false;
            AgentSelected = false;
        }
        public void MenuChanged(int Value)
        {
            pMenuID = Value;
            sLien = osessionService.sAppMenu + $"/Contrat/ContratPage/{sMatricule}";
            //try 
            //{ 
            //pMenuID = Value;

            //  string url = osessionService.sAppMenu + $"/Contrat/ContratPage/{sMatricule}";
            //  await JSRuntime.InvokeVoidAsync("open", CancellationToken.None, url, "_blank");
            //}
            //catch (Exception ex) 
            //{
            //    await JSRuntime.InvokeVoidAsync("alert", ex.Message);

            //}

        }


        public void AfficherContrat(string Value)
        {
            oNav.NavigateTo(osessionService.sApp + $"/Contrat/ContratPage/{Value}");
        }


        public void AfficherAffectation(string Value)
        {
            oNav.NavigateTo(osessionService.sApp + $"/Contrat/AffectationPage/{Value}");
        }


        public void PlanningConge(string Value)
        {
            oNav.NavigateTo(osessionService.sApp + $"/PlanningConge/PlanningCongePage/{Value}");
        }

        public void Depart(string Value)
        {
            oNav.NavigateTo(osessionService.sApp + $"/Depart/DepartPage/{Value}");
        }


        //protected override async Task OnInitializedAsync()
        //{
        //    osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");

        //    //await JSRuntime.InvokeVoidAsync("alert", osessionService.UserId);

        //    try
        //    {



        //        oOneTRH02Agent = new ClassTRH02Agent();

        //        oTCl550DeplomList = await oTCl550DeplomService.GetTCl550Deplom();
        //        oTCl550BranchList = await oTCl550BranchService.GetT550Branch();
        //        oTCl550NivEtudIdList = await oTCl550NivEtudIdService.GetTCl550NivEtudId();
        //        oTCl550DomEtudList = await oTCl550DomEtudService.GetTCl550DomEtud();
        //        oTCl550DepartementList = await oTCl550DepartementService.GetTCl550Departement();
        //        oTCl550FonctionList = await oTCl550FonctionService.GetTCl550Fonction();
        //        oTCl550UniversiteList = await oTCl550UniversiteService.GetTCl550Universite();
        //        oTCl550MaritStatusList = await oTCl550MaritStatusService.GetTCl550MaritStatus();
        //        oTCl550StatusList = await oTCl550StatusService.GetTCl550Status();
        //        oTCl550UserList = await oTCl550UserService.GetList();
        //        oTCl550SexeList = await oTCl550SexeService.GetTCl550Sexe();
        //        oTSc550EmplyeeMenu = (await oTabPrmNivOneService.GetDBListName("TSc550EmplyeeMenu")).ToList();



        //        oTCl550SubBranchList = await oTCl550SubBranchService.GetList();

        //        oSubMenuList = await oSubMenuService.GetFonctionMenu();
        //        oSubMenuList= oSubMenuList.Where(row=>row.CodeModule== "2").ToList();


        //        //oTRH02AgentList = await oTRH02AgentService.GetAgent();
        //        //oTRH02AgentList = oTRH02AgentList.OrderBy(row => row.Matricule).ToList();
        //        //oTRH02AgentList2 = oTRH02AgentList;

        //        //if(osessionService.NvFenet!=null)
        //        //{ 
        //        //    if(osessionService.NvFenet.Trim().Length>0)
        //        //    {
        //        //        if (oTRH02AgentList.Count>0)
        //        //        { 
        //        //        sMatricule = oTRH02AgentList[0].Matricule.Trim();
        //        //        sMatNomPrenom = oTRH02AgentList[0].Matricule.Trim() + " / " + oTRH02AgentList[0].Nom.Trim() + " " + oTRH02AgentList[0].Prenom.Trim();
        //        //        }

        //        //        popupSubMenu = true;
        //        //        AgentSelected = true;
        //        //    }
        //        //}
        //        ///oOnePersonnel_RIM2List = await oOnePersonnel_RIM2Service.GetPersonnelAll();

        //    }
        //    catch (Exception ex)
        //    {
        //        await JSRuntime.InvokeVoidAsync("alert", ex.Message);

        //    }
        //    finally
        //    {
        //        isLoading = false;
        //    }

        //}
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");

                // Move all your initialization code here
                try
                {
                    oOneTRH02Agent = new ClassTRH02Agent();
                    oTCl550DeplomList = await oTCl550DeplomService.GetTCl550Deplom();
                    oTCl550BranchList = await oTCl550BranchService.GetT550Branch();
                    oTCl550NivEtudIdList = await oTCl550NivEtudIdService.GetTCl550NivEtudId();
                    oTCl550DomEtudList = await oTCl550DomEtudService.GetTCl550DomEtud();
                    oTCl550DepartementList = await oTCl550DepartementService.GetTCl550Departement();
                    oTCl550FonctionList = await oTCl550FonctionService.GetTCl550Fonction();
                    oTCl550UniversiteList = await oTCl550UniversiteService.GetTCl550Universite();
                    oTCl550MaritStatusList = await oTCl550MaritStatusService.GetTCl550MaritStatus();
                    oTCl550StatusList = await oTCl550StatusService.GetTCl550Status();
                    oTCl550UserList = await oTCl550UserService.GetList();
                    oTCl550SexeList = await oTCl550SexeService.GetTCl550Sexe();
                    oTSc550EmplyeeMenu = (await oTabPrmNivOneService.GetDBListName("TSc550EmplyeeMenu")).ToList();
                    oTCl550SubBranchList = await oTCl550SubBranchService.GetList();
                    oSubMenuList = await oSubMenuService.GetFonctionMenu();
                    oSubMenuList = oSubMenuList.Where(row => row.CodeModule == "2").ToList();
                }
                catch (Exception ex)
                {
                    await JSRuntime.InvokeVoidAsync("alert", ex.Message);
                }
                finally
                {
                    isLoading = false;
                    StateHasChanged(); // Trigger re-render with loaded data
                }
            }
        }

        protected override Task OnInitializedAsync()
        {
            // Keep this empty or only initialize non-JS dependent stuff
            return Task.CompletedTask;
        }

    }
}

