using AlphaPayRoll.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.DonIntialMois;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using PayLibrary.SalProcess;

namespace AlphaPayRoll.Components.Pages.AgRetPaymentMois
{
	public class TSL02AgRetPaymentMoisPageBase : ComponentBase
	{


		[Inject]
		protected IJSRuntime JSRuntime { get; set; }

		[Inject]
		protected SessionService osessionService { get; set; }


		[Inject]
		protected ITSL02AgRetPaymentMois oAgDonIntialMoisService { set; get; }
		public List<AgDonIntialMois> oAgDonIntialMoisList { set; get; }
		public AgDonIntialMois oOneAgDonIntialMois { set; get; }



		[Inject]
		public ITabPrmNivOne oDonBaseService { set; get; }
		public List<TabPrmNivOne> oTSL550TpRetRembList { set; get; }


		[Parameter]
		public int paramAgentId { set; get; }

		[Parameter]
		public string paramNomAgent { set; get; }

		[Inject]
		protected ITSL00Process oTSL00ProcessService { set; get; }
		public List<TSL00Process> oTSL00ProcessList { set; get; }


		public string getRowColor(int i)
		{
			return (i % 2 == 0) ? "table-info" : "table-light";
		}


		//=================================================================================

		public string CurrencyFormat { set; get; } = "###,##0";
		protected bool popup = false;


		public string StyleButton { set; get; }
		public string ButtonCaption { set; get; }

		public string modalTitle { set; get; }

		public int iTypeAction { set; get; }

		protected void ShowPopUp(int tPAction)
		{

			if (tPAction == 0)
			{
				modalTitle = "Retenues permanentes";
			}
			if (tPAction == 2)
			{
				modalTitle = "Retenues permanentes";
				StyleButton = "btn btn-sm btn-primary ";
				ButtonCaption = "Sauvegarder";
			}
			else if (tPAction == 3)
			{
				modalTitle = "Retenues permanentes";
				StyleButton = "btn btn-sm btn-danger ";
				ButtonCaption = "Supprimer";

				oOneAgDonIntialMois.LModifBy = osessionService.UserId;
				oOneAgDonIntialMois.LModifOn = DateTime.Now;
			}
			if (tPAction == 1)
			{
				modalTitle = "Retenues permanentes";
				StyleButton = "btn btn-sm btn-primary ";
				ButtonCaption = "Sauvegarder";
				iTypeAction = tPAction;
				oOneAgDonIntialMois = new AgDonIntialMois();
				oOneAgDonIntialMois.ID = 0;
				oOneAgDonIntialMois.AgentId = paramAgentId;
				oOneAgDonIntialMois.Exercice = Exercice;
				oOneAgDonIntialMois.Mois = Mois;

				oOneAgDonIntialMois.CreatBy = osessionService.UserId;
				oOneAgDonIntialMois.CreatOn = DateTime.Now;


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
		protected void EditData(AgDonIntialMois item, int TpAction)
		{
			iTypeAction = TpAction;
			oOneAgDonIntialMois = item;
			ShowPopUp(iTypeAction);

		}
		Resultat oResultat = new Resultat();


		public int pTpRetenueID = 0;
		public void TpRetenuePermanHasChanged(int Value)
		{
			pTpRetenueID = Value;


		}

		protected async Task SaveData(AgDonIntialMois item)
		{

			if (iTypeAction == 3)
			{
				if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Do you really want to Delete this AgDonIntialMois ?"))
					return;
			}

            else
            {
                if (oOneAgDonIntialMois.AgentId == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Code de l'employé innexistant !");
                    return;
                }
                if (oOneAgDonIntialMois.Exercice == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Exercice paie incorrect !");
                    return;
                }

                if (oOneAgDonIntialMois.Mois == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Mois paie incorrect !");
                    return;
                }

                if (oOneAgDonIntialMois.TpRetId == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Sélectionner un type de REMOURSEMENT SVP !");
                    return;
                }

                if (oOneAgDonIntialMois.MontAPayMois == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Entrer le montant  de la REMOURSEMENT SVP !");
                    return;
                }
            }

            try
			{
				oOneAgDonIntialMois.TpMaj = iTypeAction;
				oOneAgDonIntialMois.UserID = osessionService.UserId;
				oResultat = new Resultat();

				oResultat = await oAgDonIntialMoisService.GetUpdatePaymentMoisResult(item);
				await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
				oAgDonIntialMoisList = await oAgDonIntialMoisService.GetTSL02AgRetPaymentMoisByAgent(paramAgentId);
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

		public int Exercice { set; get; } = DateTime.Today.Year;
		public int Mois { set; get; } = DateTime.Today.Month;
		public bool isLoading { set; get; } = true;
		
		protected override async Task OnInitializedAsync()
		{
			try
			{
				oTSL00ProcessList = await oTSL00ProcessService.GetSalProcessAll();

				if (oTSL00ProcessList.Count > 0)
				{
					Exercice = oTSL00ProcessList[0].Exercice;
					Mois = oTSL00ProcessList[0].Mois;

				}

				oTSL550TpRetRembList = (await oDonBaseService.GetDBListName("TSL550TpRetRemb")).ToList();
				oAgDonIntialMoisList = await oAgDonIntialMoisService.GetTSL02AgRetPaymentMoisByAgent(paramAgentId);

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


