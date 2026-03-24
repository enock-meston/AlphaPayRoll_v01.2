using Microsoft.AspNetCore.Components;
using AlphaPayRoll.Data;
using AlphaPayRoll.DataServices.AgentComReport;
using Microsoft.JSInterop;
using PayLibrary.Cl550Branch;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.ReportData;
using System.Globalization;
using static PayAPI.RepServices.AgentComListPrimeService;
namespace AlphaPayRoll.Components.Pages.AgentPDFReport
{
    public class ListPrimeLifeBase : ComponentBase
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }
        public ClasSessionStorage osessionService { set; get; }

        [Inject]
        protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }


        [Inject]
        protected IAgentComListPrimeService oListPrimeService { set; get; }

        [Inject]
        protected AgentComPrimeLoadService oChargerDon { set; get; }
        public Resultat oResult { set; get; }

        [Inject]
        protected IListPrimeLife oListBourseService { set; get; }


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


        public List<TSc551SubBranch> oTCl550SubBranchList { set; get; }
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

        public string pBranchID = "01";

        public bool bVerrouillerBranch { set; get; } = true;
        public void BranchChanged(string Value)
        {
            pBranchID = Value;
        }

        // ── Logo URL ──────────────────────────────────────────────
        public string logoUrl => NavigationManager.BaseUri.TrimEnd('/') + "/images/logo-clecam.png";

        // ── Current period label ──────────────────────────────────
        public string CurrentMois => "Mars 2026";

        // ── Print trigger ─────────────────────────────────────────
        public async Task PrintComponent()
        {
            await JSRuntime.InvokeVoidAsync("printComponent", "#printArea");
        }

        public List<ListPrimeLife> SalaireList { get; set; } = new();
        protected static string FmtAmount0(decimal value) =>
        value.ToString("#,##0", CultureInfo.InvariantCulture);

        public string GetMoisFromBranch(string? branch)
        {
            if (string.IsNullOrWhiteSpace(branch)) return string.Empty;

            const string marker = "Mois :";
            var idx = branch.IndexOf(marker, StringComparison.OrdinalIgnoreCase);
            if (idx < 0) return branch.Trim();

            return branch.Substring(idx + marker.Length).Trim();
        }

        // Refreshes the salary list for the selected branch.

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

                oTCl550BranchLocList = await oTCl550BranchService.GetT550Branch();
                oReportList2 = oReportList;
                oPeriodList2 = oPeriodList;

                pModuleID = 2;

                oReportList = oReportList2.Where(row => row.OrdNum == pModuleID).ToList();
                SalaireList = await oListBourseService.GetListPrimeLife();

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
