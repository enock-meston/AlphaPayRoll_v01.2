using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.TSL02AgHSup;
using PayLibrary.TSL550TPHSup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TCl550User;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.SalProcess;
using AlphaPayRoll.Data;

namespace AlphaPayRoll.Pages.TSL02AgHSup
{
	public class TSL02AgHSupBasePage : ComponentBase
	{
		[Inject]
		protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected SessionService osessionService { get; set; }

        [Inject]
		protected ITSL02AgHSup oTSL02AgHSupService { set; get; }
		public List<ClassTSL02AgHSup> oTSL02AgHSupList { set; get; }
		public ClassTSL02AgHSup oOneTSL02AgHSup { set; get; }

		//[Inject]
		//protected ITSL550TPHSup oTSL550TPHSupService { set; get; }
		//      public List<ClassTSL550TPHSup> oTSL550TPHSupList { set; get; }

		[Inject]
		protected ITCl550User oTCl550UserService { set; get; }

		[Inject]
		public ITabPrmNivOne oDonBaseService { set; get; }

		public List<TabPrmNivOne> oTSL550TPHSupList { set; get; }
		public List<TabPrmNivOne> oTSL550TPHSupList2 { set; get; }
		public List<ClassTCl550User> oTCl550UserList { set; get; }
		public string getRowColor(int i)
		{
			return (i % 2 == 0) ? "table-info" : "table-light";
		}

		[Parameter]
		public int paramAgentId { set; get; }

		[Parameter]
		public decimal paramSalaireBase { set; get; }

		[Parameter]
		public string paramNomAgent { set; get; }

		[Inject]
		protected ITSL00Process oTSL00ProcessService { set; get; }
		public List<TSL00Process> oTSL00ProcessList { set; get; }


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
				modalTitle = "TSL02AgHSup Details";
			}
			if (tPAction != 1)
			{
				pTpHeureSupID = oOneTSL02AgHSup.TpHSupID;
			}

			if (tPAction == 2)
			{
				modalTitle = "Edit TSL02AgHSup Details";
				StyleButton = "btn btn-sm btn-primary ";
				ButtonCaption = "Sauvegarder";
			}
			else if (tPAction == 3)
			{
				modalTitle = "Delete TSL02AgHSup Details";
				StyleButton = "btn btn-sm btn-danger ";
				ButtonCaption = "Supprimer";

				oOneTSL02AgHSup.LModifBy = int.Parse(osessionService.UserId);
				oOneTSL02AgHSup.LModifOn = DateTime.Now;
			}
			if (tPAction == 1)
			{
				modalTitle = "Ajouter TSL02AgHSup";
				StyleButton = "btn btn-sm btn-primary ";
				ButtonCaption = "Sauvegarder";
				iTypeAction = tPAction;
				oOneTSL02AgHSup = new ClassTSL02AgHSup();
				oOneTSL02AgHSup.ID = 0;
				oOneTSL02AgHSup.AgentID = paramAgentId;
				oOneTSL02AgHSup.Exercice = Exercice;
				oOneTSL02AgHSup.Mois = Mois;
				oOneTSL02AgHSup.SalBase = paramSalaireBase;
				oOneTSL02AgHSup.CreatBy = int.Parse(osessionService.UserId);
				oOneTSL02AgHSup.SemaineDu = DateTime.Now;
				oOneTSL02AgHSup.Au = DateTime.Now;
				oOneTSL02AgHSup.CreatOn = DateTime.Now;
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
		protected void EditData(ClassTSL02AgHSup item, int TpAction)
		{
			iTypeAction = TpAction;
			oOneTSL02AgHSup = item;
			ShowPopUp(iTypeAction);

		}
		Resultat oResultat = new Resultat();

		protected async Task SaveTSL02AgHSup(ClassTSL02AgHSup item)
		{

			if (iTypeAction == 3)
			{
				if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Do you really want to Delete this TSL02AgHSup ?"))
					return;
			}



            else
            {


                if (oOneTSL02AgHSup.TpHSupID == 1 && oOneTSL02AgHSup.Nombre > 2)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Maximum deux heures supplémentaires !");
                    return;
                }

                if (oOneTSL02AgHSup.AgentID == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Code de l'employé innexistant !");
                    return;
                }
                if (oOneTSL02AgHSup.Exercice == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Exercice paie incorrect !");
                    return;
                }

                if (oOneTSL02AgHSup.Mois == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Mois paie incorrect !");
                    return;
                }

                if (oOneTSL02AgHSup.TpHSupID == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Sélectionner un type de retenue SVP !");
                    return;
                }

                if (oOneTSL02AgHSup.SalBase == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Salaire de base inexistant !");
                    return;
                }

                if (oOneTSL02AgHSup.Nombre == 0)
                {
                    await JSRuntime.InvokeVoidAsync("alert", "Entrer le nombre d'heures supplémentaires SVP !");
                    return;
                }




            }

            try
			{
				oOneTSL02AgHSup.TpMaj = iTypeAction;
				oOneTSL02AgHSup.UserID = int.Parse(osessionService.UserId);
				oResultat = new Resultat();

				oResultat = await oTSL02AgHSupService.GetUpdateResult(item);
				await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
                oTSL02AgHSupList = await oTSL02AgHSupService.GetTSL02AgHSupByAgent(paramAgentId);
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



		public int pTpHeureSupID = 0;

		public void TpHeureSupHasChanged(int Value)
		{

			pTpHeureSupID = Value;

			oOneTSL02AgHSup.TpHSupID = Value;
			oTSL550TPHSupList2 = oTSL550TPHSupList.Where(row => row.ID == pTpHeureSupID).ToList();
			if (oTSL550TPHSupList2.Count > 0)
			{
				oOneTSL02AgHSup.TxAppl = Decimal.Parse(oTSL550TPHSupList2[0].RICode);


			}

		}
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


				oTCl550UserList = await oTCl550UserService.GetTCl550User();
				oTSL550TPHSupList = (await oDonBaseService.GetDBListName("TSL550TPHSup")).ToList();
				oTSL02AgHSupList = await oTSL02AgHSupService.GetTSL02AgHSupByAgent(paramAgentId);


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
