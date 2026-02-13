using AlphaPayRoll.Data;
using CongeRequest.DataService.CongeRequestF;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.CongConsult;
using PayLibrary.CongeRequestF;
using PayLibrary.CONTRACT_GOMISE;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.PlanningConge;
using PayLibrary.TRH02Agent;
namespace AlphaPayRoll.Components.Pages.CongConsult
{
    public class CongConsultStatusBase : ComponentBase
    {

        [Inject]
        public NavigationManager NavMager { get; set; }

        public THRCongCircRequest oOneActiveCongeRequest { get; set; }
        public THRCongCircRequest OneCongeRequest { get; set; } = new THRCongCircRequest();
        public Resultat oResult { get; set; }

        

        private int pTypeAction = 0;

        [Parameter]
        public int id { get; set; }

        public int currentCount = 0;
        public bool isLoading { set; get; } = true;

        public bool popup { get; set; } = false;
        public int iTypeAction { get; set; }
        public bool showAddRequestForm = false;

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }


        public ClasSessionStorage osessionService { set; get; }

        [Inject]
        protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }
        public List<ClassTRH02Agent> oTRH02SelectAgentList { get; set; } = new List<ClassTRH02Agent>();
        public string sSelectedPerson { get; set; }

        [Inject]
        protected ITRH02Agent oTRH02AgentService { set; get; }
        public List<ClassTRH02Agent> oTRH02AgentList { set; get; }
        public ClassTRH02Agent oOneTRH02Agent { set; get; }

        

        [Inject]
        public ICongConsultStatus oCongConsultStatusService { get; set; }

        public List<CongConsultStatus> oCongConsultStatusList { get; set; }


        public bool AgentSelected { set; get; } = false;

        public int AgentID { set; get; }
        public decimal SalaireBase { set; get; }
        public string sNomAgent { set; get; }
        public string sNomPrenom { set; get; }
        public string sMatricule { set; get; }

        public int itemId { get; set; }
        public bool aValidePlanning { set; get; } = true;

        public void DonAgentSuite(THRCongCircRequest pConge)
        {
            //var agent = oTRH02AgentList?.FirstOrDefault(a => a.Matricule == pConge.MATRICULE);

            //if (agent != null)
            //{
            //    DonAgentSuite(agent);
            //}
        }

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

        public string getRowColor(int i)
        {
            return (i % 2 == 0) ? "table-info" : "table-light";
        }

        
        Resultat oResultat = new Resultat();

      
        public void IncrementCount()
        {
            currentCount++;
        }


        public string modalTitle { get; set; }
        public string StyleButton { get; set; }
        public string ButtonCaption { get; set; }


        public async Task GoBack()
        {

            string sChemin = osessionService.sApp + "/GcongeIndex";

            NavMager.NavigateTo(sChemin, true);
        }

        
    
        public bool bAddDisabled { get; set; } = true;

        public bool bDisableChefDirect { get; set; } = true;
        public bool bDisableHR { get; set; } = true;
        public bool bDisableDG { get; set; } = true;

        public bool bEmployee { get; set; } = false;
        public string sExerciceID { get; set; }
        public int iNumTranche { get; set; } = 0;
        public int TotalDays { get; set; }

        public bool bAjoute { get; set; } = false;

        public int iminsiAfiteGusaba { get; set; } = 0;
        public int iminsiYasabye { get; set; } = 0; //conge pris
        public int iminsiYasigaranye { get; set; } = 0;

        // view report for Chefs,HR,DG
   

        //public async Task searchByMatricule()
        //{
        //    if (string.IsNullOrWhiteSpace(sMatricule))
        //    {
        //        await JSRuntime.InvokeVoidAsync("alert", "Veuillez entrer un matricule.");
        //        return;
        //    }

        //    try
        //    {
        //        isLoading = true;


        //        var param1 = new ParamAgentMatricule
        //        {
        //            Matricule = sMatricule,
        //            UserID = int.Parse(osessionService.UserId),
        //            RoleID = osessionService.RoleID

        //        };

        //        var oTRH02AgentList = osessionService.RoleID != 1
        //            ? await oTRH02AgentService.GetAgentByMatricule(sMatricule) :
        //            await oTRH02AgentService.GetAgentByMatriculeXX(param1);


        //        if (osessionService.RoleID == 2)
        //        {
        //            if (int.TryParse(osessionService.UserId, out int userId))
        //            {
        //                oTRH02AgentList = oTRH02AgentList.Where(row => row.ChefID == userId).ToList();

        //            }
        //        }


        //        if (oTRH02AgentList != null && oTRH02AgentList.Count > 0)
        //        {

        //            sNomPrenom = oTRH02AgentList[0].Nom.Trim() + " " + oTRH02AgentList[0].Prenom.Trim();



        //            oCongeRequestsList = await oCongeRequestsService.GetAllCongeRequestsByMatricule(sMatricule);

        //            iNumTranche = oTRH02AgentList[0].NextTranche;

        //            //await JSRuntime.InvokeVoidAsync("alert","Congé: "+ oCongeRequestsList.Count);
        //            if (osessionService.RoleID == 2)
        //            {
        //                oCongeRequestsList = oCongeRequestsList.Where(a => (a.ValidReq == true && a.Matricule == sMatricule && a.StatusChefID == "Attente")).ToList();

        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        await JSRuntime.InvokeVoidAsync("alert", $"Erreur lors de la recherche: {ex.Message}");
        //    }
        //    finally
        //    {
        //        isLoading = false;
        //        StateHasChanged();
        //    }
        //}

        public bool bSaisieCongeValid { set; get; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");

                    string userId = osessionService.Matricule;

                    oCongConsultStatusList = await oCongConsultStatusService.GetAllCongeConsultStatus(userId);

                }
                await InvokeAsync(StateHasChanged);
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
