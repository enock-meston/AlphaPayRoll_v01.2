using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.TSL02TracEvSal;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using PayLibrary.Exercice;
using PayLibrary.SalProcess;
using PayLibrary.ParamSec.ViewModel;
using AlphaPayRoll.DataServices.TSL02TracEvSal;
using AlphaPayRoll.Data;
using System.Linq;
using PayLibrary.CalculSalaire;

namespace AlphaPayRoll.Components.Pages.SalProcess
{
	public class SalCalculPageBase:ComponentBase
	{


		[Inject]
		protected IJSRuntime JSRuntime { get; set; }

		//[Inject]
		//protected SessionService osessionService { get; set; }

		public ClasSessionStorage osessionService { set; get; }

		[Inject]
		protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }

		[Inject]
		protected ICalculerSalaire oCalculerSalaireService { set; get; }


		[Inject]
		protected ITSL550Exercice oTSL550ExerciceService { set; get; }
		public List<TSL550Exercice> oTSL550ExerciceList { set; get; }

		[Inject]
		protected ITSL00Process oTSL00ProcessService { set; get; }
		public List<TSL00Process> oTSL00ProcessList { set; get; }

		public TSL00Process oOneTSL00Process { set; get; }

		[Parameter]
		public string id { get; set; }
		public string getRowColor(int i)
		{
			return (i % 2 == 0) ? "table-info" : "table-light";
		}


		//=================================================================================





		public string StyleButton { set; get; }
		public string ButtonCaption { set; get; }

		public string modalTitle { set; get; }

		public int iTypeAction { set; get; }

		protected void ShowPopUp(int tPAction)
		{

			if (tPAction == 0)
			{
				modalTitle = "TSL02TracEvSal Detail";
			}
			if (tPAction == 2)
			{
				modalTitle = "Edit TSL02TracEvSal Detail";
				StyleButton = "btn btn-sm btn-primary ";
				ButtonCaption = "Sauvegarder";
			}
			else if (tPAction == 3)
			{
				modalTitle = "Delete TSL02TracEvSal Detail";
				StyleButton = "btn btn-sm btn-danger ";
				ButtonCaption = "Supprimer";

				oOneTSL00Process.LModifBy = int.Parse(osessionService.UserId);
				oOneTSL00Process.LModifOn = DateTime.Now;
			}
			if (tPAction == 1)
			{
				modalTitle = "Ajouter TSL02TracEvSal";
				StyleButton = "btn btn-sm btn-primary ";
				ButtonCaption = "Sauvegarder";
				iTypeAction = tPAction;
				oOneTSL00Process = new TSL00Process();
				oOneTSL00Process.ID = 0;
				oOneTSL00Process.CreatBy = int.Parse(osessionService.UserId);
                oOneTSL00Process.CreatOn = DateTime.Now;
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
		protected void EditData(TSL00Process item, int TpAction)
		{
			iTypeAction = TpAction;
			oOneTSL00Process = item;
			ShowPopUp(iTypeAction);

		}
		Resultat oResultat = new Resultat();

		//protected async Task SaveTSL02TracEvSal(TSL550Exercice item)
		//{

		//    if (iTypeAction == 3)
		//    {
		//        if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment supprimer ceci ?TSL02TracEvSal ?"))
		//            return;
		//    }
		//    try
		//    {
		//        oOneTSL550Exercice.TpMaj = iTypeAction;
		//        oOneTSL550Exercice.UserID = osessionService.UserId;
		//        oResultat = new Resultat();

		//        oResultat = await oTSL02TracEvSalService.GetUpdateResult(item);
		//        await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
		//        oTSL02TracEvSalList = await oTSL02TracEvSalService.GetTSL02TracEvSal();
		//        if (oResultat.Result.Trim().Length < 30)
		//        {
		//            ClosePopUp();
		//        }
		//    }
		//    catch (Exception ex)
		//    {
		//        await JSRuntime.InvokeVoidAsync("alert", ex.Message);
		//    }
		//    finally
		//    {

		//    }
		//}
		//=========================================================================================


		public int Mois=0;
		public int Exercice = 0;
		public void MoisHasChanged(int Value)
		{
			Mois = Value;
		}

		public void ExerciceHasChanged(int Value)
		{
			Exercice = Value;
		}


		public bool isLoading { set; get; } = true;
		public bool popup { set; get; } = true;

		public void InitialiserSalaires()
		{
			popup = false;
		}


		public async Task CalculerSalaires()
		{

			isLoading = true;
			try
			{

				if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment calculer les salaires ?"))
					return;

				ParamCallSalaire item = new ParamCallSalaire();
				item.Exercice =Exercice;
				item.Mois = Mois;
				item.UserID = int.Parse(osessionService.UserId);

                oResultat = await oCalculerSalaireService.PostCalculerSalaire(item);

				await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
				//oTSL00ProcessList = await oTSL00ProcessService.GetSalProcessAll();
				popup = false;

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


		protected override async Task OnInitializedAsync()
		{
			try
			{
				oOneTSL00Process = new TSL00Process();
				oTSL550ExerciceList = await oTSL550ExerciceService.GetExerciceAll();

				//ParamPeriod item = new ParamPeriod();
				//item.Exercice = 2023;
				//item.Mois = 5;

				int pExercice = 0;
				int pMois = 0;

				pMois = DateTime.Now.Month;
				pExercice = DateTime.Now.Year;

				oTSL00ProcessList = await oTSL00ProcessService.GetSalProcessAll();

				oTSL00ProcessList=oTSL00ProcessList.Where (row=>(row.Mois==pMois && row.Exercice == pExercice)).ToList();    
				if (oTSL00ProcessList.Count > 0)
				{
					Exercice= oTSL00ProcessList[0].Exercice;
					Mois= oTSL00ProcessList[0].Mois;

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




