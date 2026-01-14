using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.TSL550TPHSup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaPayRoll.Pages.TSL550TPHSup
{
	public class TSL550TPHSupBasePage : ComponentBase
	{
		[Inject]
		protected IJSRuntime JSRuntime { get; set; }
		[Inject]
		protected ITSL550TPHSup oTSL550TPHSupService { set; get; }
		public List<ClassTSL550TPHSup> oTSL550TPHSupList { set; get; }
		public ClassTSL550TPHSup oOneTSL550TPHSup { set; get; }
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

		protected void ShowPopUp(int tPAction)
		{

			if (tPAction == 0)
			{
				modalTitle = "Type Heures Supplém.";
			}
			if (tPAction == 2)
			{
				modalTitle = "Type Heures Supplém.";
				StyleButton = "btn btn-sm btn-primary ";
				ButtonCaption = "Sauvegarder";
			}
			else if (tPAction == 3)
			{
				modalTitle = "Type Heures Supplém.";
				StyleButton = "btn btn-sm btn-danger ";
				ButtonCaption = "Supprimer";

				oOneTSL550TPHSup.LModifBy = 9999;
				oOneTSL550TPHSup.LModifOn = DateTime.Now;
			}
			if (tPAction == 1)
			{
				modalTitle = "Type Heures Supplém.";
				StyleButton = "btn btn-sm btn-primary ";
				ButtonCaption = "Sauvegarder";
				iTypeAction = tPAction;
				oOneTSL550TPHSup = new ClassTSL550TPHSup();
				oOneTSL550TPHSup.ID = 0;
				oOneTSL550TPHSup.CreatBy = 9999;
				oOneTSL550TPHSup.CreatOn = DateTime.Now;
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
		protected void EditData(ClassTSL550TPHSup item, int TpAction)
		{
			iTypeAction = TpAction;
			oOneTSL550TPHSup = item;
			ShowPopUp(iTypeAction);

		}
		Resultat oResultat = new Resultat();

		protected async Task SaveTSL550TPHSup(ClassTSL550TPHSup item)
		{

			if (iTypeAction == 3)
			{
				if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Do you really want to Delete this TSL550TPHSup ?"))
					return;
			}
			try
			{
				oOneTSL550TPHSup.TpMaj = iTypeAction;
				oOneTSL550TPHSup.UserID = 9999;
				oResultat = new Resultat();

				oResultat = await oTSL550TPHSupService.GetUpdateResult(item);
				await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
				oTSL550TPHSupList = await oTSL550TPHSupService.GetTSL550TPHSup();
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
		public string CurrencyFormat { set; get; } = "###,##0";
		protected override async Task OnInitializedAsync()
		{
			oTSL550TPHSupList = await oTSL550TPHSupService.GetTSL550TPHSup();
		}
	}
}
