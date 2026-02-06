using AlphaPayRoll.Data;
using AlphaPayRoll.DataServices.AgentComReport;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayAPI.ReportFiles;
using PayLibrary.AgRegAugmBase;
using PayLibrary.Cl550Branch;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static PayAPI.RepServices.AgentComListPrimeService;

namespace AlphaPayRoll.Components.Pages.AgentComReport
{
	public class SalaireReportPageBase : ComponentBase
	{

		[Inject]
		protected IJSRuntime JSRuntime { get; set; }
		public ClasSessionStorage osessionService { set; get; }

		[Inject]
		protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }



		[Inject]
		protected IAgentComListPrimeService oListPrimeService { set; get; }

		[Inject]
		protected AgentComPrimeLoadService oChargerDon { set; get; }
		public Resultat oResult { set; get; }


		[Inject]
		public ITabPrmNivOne oDonBaseService { set; get; }



		public List<TabPrmNivOne> oPeriodList { set; get; }
		public List<TabPrmNivOne> oPeriodList2 { set; get; }
		public List<TabPrmNivOne> oReportList { set; get; }
		public List<TabPrmNivOne> oReportList2 { set; get; }

		[Inject]
		protected ITCl550Branch oTCl550BranchService { set; get; }
		public List<ClassTCl550Branch> oTCl550BranchLocList { set; get; }

		public TabPrmNivOne oItem { set; get; }
		public byte[] ListPrime { set; get; }


		public bool isLoading { set; get; }

		public int pPeriodeID = 0;

		public int pModuleID = 1;
		public int pExerciceID = 0;

		public bool bVerrouillerAfficherReport { set; get; } = true;


		public void ExerciceChanged(int Value)
		{
			bVerrouillerAfficherReport = true;
			pExerciceID = Value;
			oPeriodList = oPeriodList2.Where(row => row.OrdNum == pExerciceID).ToList();
			oPeriodList = oPeriodList.OrderBy(row => row.ID).ToList();

		}
		public void ModuleChanged(int Value)
		{
			bVerrouillerAfficherReport = true;
			pModuleID = Value;
			oReportList = oReportList2.Where(row => row.OrdNum == pModuleID).ToList();

		}

		public void PeriodeChanged(int Value)
		{
			bVerrouillerAfficherReport = true;
			pPeriodeID = Value;
		}

		public string pReportName = "";
		public void ReportChanged(string Value)
		{
			bVerrouillerAfficherReport = true;
			pReportName = Value;
			if (pReportName == "rptPrimeListPay")
				bVerrouillerBranch = false;
			else
				bVerrouillerBranch = true;
		}

		public string pReportTypeID = "";

		public void ReportTypeChanged(string Value)
		{
			bVerrouillerAfficherReport = true;
			pReportTypeID = Value;
		}

		public string pBranchID = "0";

		public bool bVerrouillerBranch { set; get; } = true;
		public void BranchChanged(string Value)
		{
			pBranchID = Value;
		}


		public async Task ChargerDonnees()
		{
			if (pModuleID == 0)
			{
				await JSRuntime.InvokeVoidAsync("alert", "Please Select One Module");
				return;
			}
			if (pExerciceID == 0)
			{
				await JSRuntime.InvokeVoidAsync("alert", "Please Select One Exercice");
				return;
			}

			if (pPeriodeID == 0)
			{
				await JSRuntime.InvokeVoidAsync("alert", "Please Select One Period");
				return;
			}

			//if (pReportName == "")
			//{
			//    await JSRuntime.InvokeVoidAsync("alert", "Please Select One Report");
			//    return;
			//}
			//if (pReportTypeID == "")
			//{
			//    await JSRuntime.InvokeVoidAsync("alert", "Please Select One Report Type");
			//    return;
			//}


			bVerrouillerAfficherReport = true;

			//if (pReportName == "rptAgentComPrime")
			//{

				try
				{

					oResult = new Resultat();
					isLoading = true;
					//ListPrime = await oListPrimeService.GenerateListPrimeAsync(pReportName, pReportTypeID, pPeriodeID);

					oResult = await oChargerDon.ListPrimeAsync(pPeriodeID);
					await JSRuntime.InvokeVoidAsync("alert", oResult.Result);

					isLoading = false;
					bVerrouillerAfficherReport = false;

				}

				catch (Exception ex)
				{
					await JSRuntime.InvokeVoidAsync("alert", ex.Message);

				}
				finally
				{
					isLoading = false;
				}
			//}
			//else
			//{
			//    await JSRuntime.InvokeVoidAsync("alert", "Not Yet Implemented !");

			//}

		}

		public async Task AfficherReport()
		{
			string url = "";


			try
			{

				if (pReportName == "rptAgentComPrime")
				{
                    await JSRuntime.InvokeVoidAsync("alert", pReportName);
                    await JSRuntime.InvokeVoidAsync("alert", pReportTypeID);
                    //url = $"http://192.168.1.221/payapi/api/AgentComListPrime/" + pReportName + "/" + pReportTypeID;
                }
				if (pReportName == "rptPrimeAgComVerif")
				{

					url = $"http://192.168.1.221/payapi/api/AgentComListPrimeVerif/" + pReportName + "/" + pReportTypeID;
				}

				else if (pReportName == "rptBranchSituation")
				{

					url = $"http://192.168.1.221/payapi/api/AgentComBranchSit/" + pReportName + "/" + pReportTypeID + "/" + pPeriodeID;
				}

				else if (pReportName == "rptSubBranchSituation")
				{

					url = $"http://192.168.1.221/payapi/api/AgentComSubBranchSit/" + pReportName + "/" + pReportTypeID + "/" + pPeriodeID;
				}
				else if (pReportName == "rptZone")
				{

					url = $"http://192.168.1.221/payapi/api/AgentComZoneSit/" + pReportName + "/" + pReportTypeID + "/" + pPeriodeID;
				}
				else if (pReportName == "rptPrimeListPay")
				{
					url = $"http://192.168.1.221/payapi/api/PrimeListePayBranch/" + pReportName + "/" + pReportTypeID + "/" + pBranchID; //+ pPeriodeID;
				}

				//await JSRuntime.InvokeAsync<object>("open", CancellationToken.None, url, "_blank");
				await JSRuntime.InvokeVoidAsync("open", CancellationToken.None, url, "_blank");

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
			osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");
			isLoading = true;

		try
		{
				oItem = new TabPrmNivOne();
				isLoading = false;
				oPeriodList = (await oDonBaseService.GetDBListName("TSys550EOM")).ToList();
				oReportList = (await oDonBaseService.GetDBListName("TSys550ListReport")).ToList();


				
				oTCl550BranchLocList= await oTCl550BranchService.GetT550Branch();
				oReportList2 = oReportList;
				oPeriodList2 = oPeriodList;

				pModuleID = 1;

				oReportList = oReportList2.Where(row => row.OrdNum == pModuleID).ToList();

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
