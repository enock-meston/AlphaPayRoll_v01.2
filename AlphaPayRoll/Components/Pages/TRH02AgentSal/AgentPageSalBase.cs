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

namespace AlphaPayRoll.Components.Pages.TRH02AgentSal
{
	public class AgentPageSalBase : ComponentBase
	{


		[Inject]
		protected IJSRuntime JSRuntime { get; set; }

		[Inject]
		protected SessionService osessionService { get; set; }


		[Inject]
		protected ITRH02Agent oTRH02AgentService { set; get; }

		public List<ClassTRH02Agent> oTRH02AgentList { set; get; }


		//Maried Status

		[Inject]
		protected ITCl550MaritStatus oTCl550MaritStatusService { set; get; }

		public List<ClassTCl550MaritStatus> oTCl550MaritStatusList { set; get; }


		//Deplom

		[Inject]
		protected ITCl550Deplom oTCl550DeplomService { set; get; }
		public List<ClassTCl550Deplom> oTCl550DeplomList { set; get; }



		[Inject]
		protected ITCl550Branch oTCl550BranchService { set; get; }
		public List<ClassTCl550Branch> oTCl550BranchList { set; get; }


		[Inject]
		protected ITCl550Sexe oTCl550SexeService { set; get; }
		public List<ClassTCl550Sexe> oTCl550SexeList { set; get; }


		[Inject]
		protected ITCl550DomEtud oTCl550DomEtudService { set; get; }
		public List<ClassTCl550DomEtud> oTCl550DomEtudList { set; get; }

		[Inject]
		protected ITCl550NivEtudId oTCl550NivEtudIdService { set; get; }
		public List<ClassTCl550NivEtudId> oTCl550NivEtudIdList { set; get; }

		[Inject]
		protected ITCl550Universite oTCl550UniversiteService { set; get; }
		public List<ClassTCl550Universite> oTCl550UniversiteList { set; get; }

		[Inject]
		protected ITCl550Departement oTCl550DepartementService { set; get; }
		public List<ClassTCl550Departement> oTCl550DepartementList { set; get; }

		[Inject]
		protected ITCl550Status oTCl550StatusService { set; get; }
		public List<ClassTCl550Status> oTCl550StatusList { set; get; }

		[Inject]
		protected ITCl550Fonction oTCl550FonctionService { set; get; }
		public List<ClassTCl550Fonction> oTCl550FonctionList { set; get; }

		[Inject]
		protected ITCl550User oTCl550UserService { set; get; }
		public List<ClassTCl550User> oTCl550UserList { set; get; }


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

				oOneTRH02Agent.LModifBy = osessionService.UserId;
				oOneTRH02Agent.LModifOn = DateTime.Now;

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
				oOneTRH02Agent.CreatBy = osessionService.UserId;
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

		protected void EditData(ClassTRH02Agent item, int TpAction)
		{

			iTypeAction = TpAction;
			oOneTRH02Agent = item;

			ShowPopUp(iTypeAction);

		}


		Resultat oResultat = new Resultat();

		protected async Task SaveTRH02Agent(ClassTRH02Agent item)
		{



			if (iTypeAction == 3)
			{
				if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment supprimer ceci ??"))
					return;
			}


			try
			{


				oOneTRH02Agent.TpMaj = iTypeAction;
				oOneTRH02Agent.UserID = osessionService.UserId;

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


		//=========================================================================================

		public bool isLoading { set; get; } = true;

		public string CurrencyFormat { set; get; } = "###,##0";
		
		public string sNomRecherche { set; get; }

		public async Task Rechercher()
		{
			if (sNomRecherche==null || sNomRecherche.Trim() != "")
			{
				oTRH02AgentList = await oTRH02AgentService.GetAgentRech(sNomRecherche);
			}
			else
			{
				oTRH02AgentList = await oTRH02AgentService.GetAgent();
			}

			oTRH02AgentList = oTRH02AgentList.OrderBy(row => row.Nom).ToList();

			//await JSRuntime.InvokeVoidAsync("alert", "Pas encore implémenté !");

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

				oOneTRH02Agent = new ClassTRH02Agent();

				oTCl550DeplomList = await oTCl550DeplomService.GetTCl550Deplom();
				oTCl550BranchList = await oTCl550BranchService.GetT550Branch();
				oTCl550DomEtudList = await oTCl550DomEtudService.GetTCl550DomEtud();
				oTCl550NivEtudIdList = await oTCl550NivEtudIdService.GetTCl550NivEtudId();
				oTCl550DepartementList = await oTCl550DepartementService.GetTCl550Departement();
				oTCl550FonctionList = await oTCl550FonctionService.GetTCl550Fonction();
				oTCl550MaritStatusList = await oTCl550MaritStatusService.GetTCl550MaritStatus();
				oTCl550UniversiteList = await oTCl550UniversiteService.GetTCl550Universite();
				oTCl550StatusList = await oTCl550StatusService.GetTCl550Status();
				oTCl550UserList = await oTCl550UserService.GetTCl550User();
				oTCl550SexeList = await oTCl550SexeService.GetTCl550Sexe();

				oTRH02AgentList = await oTRH02AgentService.GetAgent();
				oTRH02AgentList = oTRH02AgentList.OrderBy(row => row.Matricule).ToList();

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

