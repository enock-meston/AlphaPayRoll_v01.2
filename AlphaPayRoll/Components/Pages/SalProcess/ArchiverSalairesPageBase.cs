using AlphaPayRoll.Data;
using AlphaPayRoll.DataServices.TRH02Agent;
using AlphaPayRoll.DataServices.TSL02TracEvSal;
using AlphaPayRoll.DataServices.TSL09ImputPay;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.CalculSalaire;
using PayLibrary.Exercice;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.SalProcess;
using PayLibrary.TRH02Agent;
using PayLibrary.TSL02TracEvSal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaPayRoll.Components.Pages.SalProcess
{
	public class ArchiverSalairesPageBase: ComponentBase
	{


		[Inject]
		protected IJSRuntime JSRuntime { get; set; }

        public ClasSessionStorage osessionService { set; get; }

        [Inject]
        protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }

        [Inject]
		protected ITSL550Exercice oTSL550ExerciceService { set; get; }
		public List<TSL550Exercice> oTSL550ExerciceList { set; get; }

		[Inject]
		protected ITSL00Process oTSL00ProcessService { set; get; }
		public List<TSL00Process> oTSL00ProcessList { set; get; }

		public TSL00Process oOneTSL00Process { set; get; }

        [Parameter]
        public string id { get; set; }


        [Inject]
        protected ITRH02Agent oTRH02AgentService { set; get; }

        public List<ClassTRH02Agent> oTRH02AgentList { set; get; }

        public string getRowColor(int i)
		{
			return (i % 2 == 0) ? "table-info" : "table-light";
		}


        //=================================================================================

        [Inject]
        protected ICalculerSalaire oCalculerSalaireService { set; get; }




        public string StyleButton { set; get; }
		public string ButtonCaption { set; get; }

		public string modalTitle { set; get; }

		public int iTypeAction { set; get; }

		//=========================================================================================


		public int Mois { set; get; }
		public int Exercice { set; get; }
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

		public Resultat oResultat { set; get; }
        public async Task ArcvhiverSalaires()
		{

			isLoading = true;
			try
			{

				if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment Archiver ces salaires ?"))
					return;

                ParamCallSalaire item = new ParamCallSalaire();
                item.Exercice = Exercice;
                item.Mois = Mois;
                item.UserID = int.Parse(osessionService.UserId);

                oResultat = await oCalculerSalaireService.PostArchiverSalaire(item);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
				oTSL00ProcessList = await oTSL00ProcessService.GetSalProcessAll();
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

        public string CurrencyFormat { set; get; } = "###,##0";

        public decimal TotalNetAPayer { set;get; } = 0;
        protected override async Task OnInitializedAsync()
        {
            osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");
            try
			{

                oOneTSL00Process = new TSL00Process();
				oTSL550ExerciceList = await oTSL550ExerciceService.GetExerciceAll();

                oTSL00ProcessList = await oTSL00ProcessService.GetSalProcessAll();
                oTSL00ProcessList = oTSL00ProcessList.Where(row => (row.ConstatationPass == true && row.SalairesPass ==true && row.RemboursPass == true)).ToList();
                if (oTSL00ProcessList.Count > 0)
                {
                    Exercice = oTSL00ProcessList[0].Exercice;
                    Mois = oTSL00ProcessList[0].Mois;

                }

                oTRH02AgentList = await oTRH02AgentService.GetAgent();
                oTRH02AgentList = oTRH02AgentList.Where(row => (row.StatusId == 1 )).ToList();

                TotalNetAPayer = (from NetAPay in oTRH02AgentList select NetAPay.NetAPayer).Sum();

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

