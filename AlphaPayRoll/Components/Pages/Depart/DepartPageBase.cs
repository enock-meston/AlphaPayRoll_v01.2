using AlphaPayRoll.Data;
using AlphaPayRoll.DataServices.Contrat;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.Contrat;
using PayLibrary.Depart;
using PayLibrary.InterfParamSec;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.ParamDonBase;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TRH02Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaPayRoll.Components.Pages.Depart
{
    public class DepartPageBase : ComponentBase
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }
        public ClasSessionStorage osessionService { set; get; }

        [Inject]
        protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }

        [Inject]
        protected IDepart oDepartService { set; get; }

        public List<ClassDepart> oDepartList { set; get; }




        //[Inject]
        //protected ITCl550User oTCl550UserService { set; get; }
        //public List<ClassTCl550User> oTCl550UserList { set; get; }


        [Inject]
        protected ITSc551User oTCl550UserService { set; get; }
        public List<TSc551User> oTCl550UserList { set; get; }



        [Inject]
        private ITabPrmNivOne oTabPrmNivOneService { set; get; }
        public List<TabPrmNivOne> oTCl550MotifDepart { set; get; }

        [Inject]
        protected ITRH02Agent oTRH02AgentService { set; get; }
        public List<ClassTRH02Agent> oTRH02AgentList { set; get; }


        [Parameter]
        public string id { set; get; }
        public ClassDepart oOneDepart { set; get; }


        public string getRowColor(int i)
        {
            return (i % 2 == 0) ? "table-info" : "table-light";
        }


        //=================================================================================
        public bool isLoading { set; get; } = true;

        protected bool popup = false;


        public string StyleButton { set; get; }
        public string ButtonCaption { set; get; }

        public string modalTitle { set; get; }

        public int iTypeAction { set; get; }

        protected void ShowPopUp(int tPAction)
        {

            if (tPAction == 0)
            {
                modalTitle = " Départ Detail";
            }
            if (tPAction == 2)
            {
                modalTitle = "Modifier  Départ Detail";
                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";
            }
            else if (tPAction == 3)
            {
                modalTitle = "Supprimer  Départ Detail";
                StyleButton = "btn btn-sm btn-danger ";
                ButtonCaption = "Supprimer";
                if (oOneDepart.LModifOn < new DateTime(1753, 1, 1))
                oOneDepart.LModifOn = DateTime.Now;  
                oOneDepart.LModifBy = int.Parse(osessionService.UserId);


            }



            if (tPAction == 1)
            {

                

                modalTitle = "Ajouter Départ";

                StyleButton = "btn btn-sm btn-primary ";
                ButtonCaption = "Sauvegarder";


                iTypeAction = tPAction;
                oOneDepart = new ClassDepart();

                oOneDepart.ID = 0;
                oOneDepart.DateEmbauche = DateTime.Now;
                oOneDepart.DateDepart = DateTime.Now;
                oOneDepart.CreatBy = int.Parse(osessionService.UserId);
                oOneDepart.Matricule = sMatricule;
                oOneDepart.CreatOn = DateTime.Now;

            }
            else
            {

            }

            popup = true;
        }

        public bool AgentSelected { set; get; } = false;

        public int AgentID { set; get; }
        public decimal SalaireBase { set; get; }
        public string sNomAgent { set; get; }
        public void DonAgentSuite(ClassDepart pAgent)
        {
            AgentID = pAgent.ID;
            SalaireBase = pAgent.ID;
            AgentSelected = true;

   
        }
        public void BackToAgent()
        {
            AgentSelected = false;

        }

        protected void ClosePopUp()
        {
            popup = false;
        }

        protected async Task ValidateData(int id)
        {
            try
            {
                var param = new ParamValidDepart
                {
                    ID = id,
                    UserID = int.Parse(osessionService.UserId)
                };
                

                var result = await oDepartService.ValiderDepart(param);
                await JSRuntime.InvokeVoidAsync("alert", "Message: " + result.Result);
                oDepartList = await oDepartService.GetDepartByMatricule(sMatricule);
               

            }
            catch (Exception ex)
            {
                await JSRuntime.InvokeVoidAsync("alert", $"An error occurred: {ex.Message}");
                Console.WriteLine($"Error in ValidateData: {ex}");
            }
        }

        protected void EditData(ClassDepart item, int TpAction)
        {

            iTypeAction = TpAction;
            oOneDepart = item;

            ShowPopUp(iTypeAction);

        }


        Resultat oResultat = new Resultat();

        protected async Task SaveDepart(ClassDepart item)
        {



            if (iTypeAction == 3)
            {
                if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous vraiment supprimer ceci ?"))
                    return;
            }
            else if (oOneDepart.MotifDepart == "")
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Motif Depart est obligatoire");
                return;
            }
            else if (oOneDepart.Observation == "")
            {
                await JSRuntime.InvokeVoidAsync("alert", "Le Observation est obligatoire");
                return;
            }
            if (oOneDepart.DateDepart < new DateTime(1753, 1, 1))
                oOneDepart.DateDepart = DateTime.Now;
            if (oOneDepart.DateEmbauche < new DateTime(1753, 1, 1))
                oOneDepart.DateEmbauche = DateTime.Now;
            if (oOneDepart.CreatOn < new DateTime(1753, 1, 1))
                oOneDepart.CreatOn = DateTime.Now;
            if (oOneDepart.LModifOn < new DateTime(1753, 1, 1))
                oOneDepart.LModifOn = DateTime.Now;

            try
            {

                oOneDepart.TpMaj = iTypeAction;
                oOneDepart.UserID = int.Parse(osessionService.UserId);
                oOneDepart.Matricule = sMatricule;
                oResultat = new Resultat();

                oResultat = await oDepartService.GetResutUpdate(oOneDepart);
                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);

                oTRH02AgentList = await oTRH02AgentService.GetAgentByMatricule(sMatricule);

                if (oTRH02AgentList.Count > 0)
                {
                    sNomPrenom = oTRH02AgentList[0].Nom.Trim() + " " + oTRH02AgentList[0].Prenom.Trim();
                    oDepartList = await oDepartService.GetDepartByMatricule(sMatricule);

                }

                oDepartList = await oDepartService.GetDepart();

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
                isLoading = false;
            }
        }

        public string CurrencyFormat { set; get; } = "###,##0";

        public string sMatricule { set; get; }

        

        public async Task searchByMatricule()
        {
            //var matricule = oOneTRH02Agent?.Matricule;
            if (string.IsNullOrWhiteSpace(sMatricule))
            {
                await JSRuntime.InvokeVoidAsync("alert", "Please enter a Matricule.");
                return;
            }

            try
            {
                isLoading = true;

                // First, search for the agent
                oTRH02AgentList = await oTRH02AgentService.GetAgentByMatricule(sMatricule);

                if (oTRH02AgentList.Count > 0)
                {
                    sNomPrenom = oTRH02AgentList[0].Nom.Trim() + " " + oTRH02AgentList[0].Prenom.Trim();
                    oDepartList = await oDepartService.GetDepartByMatricule(sMatricule);
                    bAddDisabled = false;
                }
                else

                {
                    bAddDisabled = true;
                    await JSRuntime.InvokeVoidAsync("alert", $"No agent found with matricule: {sMatricule}");
                }

            }
            catch (Exception ex)
            {
                await JSRuntime.InvokeVoidAsync("alert", $"Error during search: {ex.Message}");
            }
            finally
            {
                isLoading = false;
                //StateHasChanged();
            }
        }

        public string TypeAffichage { set; get; }
        public void ParamAgent()
        {
            TypeAffichage = "AgentUniquement";
        }

        public string sNomPrenom { set; get; }

        public async Task GoBack()
        {
            await JSRuntime.InvokeVoidAsync("history.back");
        }

        public bool bAddDisabled { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");

            try
            {
                oOneDepart = new ClassDepart();


                oDepartList = await oDepartService.GetDepartByMatricule(id);
                //await JSRuntime.InvokeVoidAsync("alert", 1);

                oTCl550UserList = await oTCl550UserService.GetList();
                //oTCl550UserList = await oTCl550UserService.GetTCl550User();
                //await JSRuntime.InvokeVoidAsync("alert", 2);

                oTCl550MotifDepart = (await oTabPrmNivOneService.GetDBListName("TCl550MotifDepart")).ToList();
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
