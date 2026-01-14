using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TSL09ImputPay;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Security.Policy;
using PayLibrary.ParamSec.ViewModel;
using System.Linq;
using AlphaPayRoll.Data;

namespace AlphaPayRoll.Components.Pages.TSL09ImputPay
{
	public class TSL09ImputPayPageBase : ComponentBase
	{
		[Inject]
		protected IJSRuntime JSRuntime { get; set; }


        public ClasSessionStorage osessionService { set; get; }

        [Inject]
        protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }

        [Inject]
		protected ITSL09ImputPay oTSL09ImputPayService { set; get; }

		public List<ClassTSL09ImputPay> oTSL09ImputPayList { set; get; }


		//Maried Status

		[Inject]
		protected ITCl550MaritStatus oTCl550MaritStatusService { set; get; }

		public List<ClassTCl550MaritStatus> oTCl550MaritStatusList { set; get; }




        [Parameter]
        public string id { get; set; }

        public ClassTSL09ImputPay oOneTSL09ImputPay { set; get; }


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
				modalTitle = "Journal paie";
			}
			if (tPAction == 2)
			{
				modalTitle = "Journal paie";
				StyleButton = "btn btn-sm btn-primary ";
				ButtonCaption = "Sauvegarder";
			}
			else if (tPAction == 3)
			{
				modalTitle = "Journal paie";
				StyleButton = "btn btn-sm btn-danger ";
				ButtonCaption = "Supprimer";

				oOneTSL09ImputPay.LModifBy =int.Parse(osessionService.UserId);
				oOneTSL09ImputPay.LModifOn = DateTime.Now;

			}

			if (tPAction == 1)
			{


				modalTitle = "Journal paie";

				StyleButton = "btn btn-sm btn-primary ";
				ButtonCaption = "Sauvegarder";


				iTypeAction = tPAction;
				oOneTSL09ImputPay = new ClassTSL09ImputPay();

				oOneTSL09ImputPay.ID = 0;
				oOneTSL09ImputPay.CreatBy =int.Parse(osessionService.UserId);
				oOneTSL09ImputPay.CreatOn = DateTime.Now;



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
		public string CurrencyFormat { set; get; } = "###,##0";
		protected void EditData(ClassTSL09ImputPay item, int TpAction)
		{

			iTypeAction = TpAction;
			oOneTSL09ImputPay = item;

			ShowPopUp(iTypeAction);

		}


		Resultat oResultat = new Resultat();


        public async Task PasserSalaireLocal()
        {

			if (TotDebit!= TotCredit)
			{
                await JSRuntime.InvokeVoidAsync("alert", "Transaction déséquilibrée (Débit<>Crédit)");
				return;	
            }


            if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment passer ces salaires ?"))
                return;

            try
            {
                isLoading = true;
                oResultat = new Resultat();

                int pExercice = 0;
                int pMois = 0;

                pMois = DateTime.Now.Month;
                pExercice = DateTime.Now.Year;

                ParamTransSalaire oparam = new ParamTransSalaire();

                oparam.Exercice = pExercice;
                oparam.Mois = pMois;
                oparam.UserID = Convert.ToInt32(osessionService.UserId);

                oResultat = await oTSL09ImputPayService.GetResutPasserSalaire(oparam);

                isLoading = false;

               
                if (oResultat.Result.Trim().Length > 30)
                {
                    await JSRuntime.InvokeVoidAsync("alert", oResultat.Result.Trim());
                }

            }

            catch (Exception ex)
            {
                isLoading = false;
                await JSRuntime.InvokeVoidAsync("alert", ex.Message);
            }
            finally
            {
                isLoading = false;
            }
        }



		protected async Task SaveTSL09ImputPay(ClassTSL09ImputPay item)
		{


			if (iTypeAction == 3)
			{
				if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment supprimer ceci ?ImputPay ?"))
					return;
			}


			try
			{


				oOneTSL09ImputPay.TpMaj = iTypeAction;
				oOneTSL09ImputPay.UserID = int.Parse(osessionService.UserId);

				oResultat = new Resultat();

				oResultat = await oTSL09ImputPayService.GetResutUpdate(item);
				await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
				oTSL09ImputPayList = await oTSL09ImputPayService.GetTSL09ImputPay();

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

		public decimal TotDebit { set; get; }
		public decimal TotCredit { set; get; }

		public bool isLoading { set; get; } = true;
		protected override async Task OnInitializedAsync()
		{
            osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");

            try
			{
				oTCl550MaritStatusList = await oTCl550MaritStatusService.GetTCl550MaritStatus();
				oTSL09ImputPayList = await oTSL09ImputPayService.GetTSL09ImputPay();
				oTSL09ImputPayList = oTSL09ImputPayList.OrderBy(row => row.ID).ToList();

				TotDebit = (from TotDebit in oTSL09ImputPayList select TotDebit.Debit).Sum();
				TotCredit = (from TotCredit in oTSL09ImputPayList select TotCredit.Credit).Sum();

				


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

