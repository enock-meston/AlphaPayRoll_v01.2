using AlphaPayRoll.Data;
using AlphaPayRoll.DataServices.TCl550MaritStatus;
using AlphaPayRoll.DataServices.TSL09ImputPay;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TSL09ImputPay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AlphaPayRoll.Components.Pages.TSL09ImputPay
{
    public class ConstatSalairePageBase:ComponentBase
    {

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        public ClasSessionStorage osessionService { set; get; }

        [Inject]
        protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }



        //[Inject]
        //protected SessionService osessionService { get; set; }

        [Inject]
        protected ITSL09ImputPay oTSL09ImputPayService { set; get; }

        public List<TMontConstSalaire> oConstSalaireList { set; get; }


        [Parameter]
        public string id { get; set; }

        public bool isLoading { get; set; } = true;

        public async Task VerifConstationSalaire()
        {
            await JSRuntime.InvokeVoidAsync("alert", "Verification OK");
        }


        Resultat oResultat = new Resultat();
        public async Task PasserConstationSalaire()
        {
    
            if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous passer la constation des salaires ?"))
                return;
         
            try
            {
                isLoading = true;
                oResultat = new Resultat();

                int pExercice = 0;
                int pMois = 0;

                pMois = DateTime.Now.Month;
                pExercice = DateTime.Now.Year;


                ParamTransSalaire oparam=new ParamTransSalaire();

                oparam.Exercice = pExercice;
                oparam.Mois = pMois;
                oparam.UserID = Convert.ToInt32(osessionService.UserId);

                oResultat = await oTSL09ImputPayService.GetResutPasserConstSalaire(oparam);

                isLoading = false;

                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);
               

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

        public async Task PasserSalaireLocal()
        {

            if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Do you really want to POST this Transaction ?"))
                return;

            try
            {
                isLoading = true;
                oResultat = new Resultat();

                ParamTransSalaire oparam = new ParamTransSalaire();

                oparam.Exercice = 2024;
                oparam.Mois = 12;
                oparam.UserID = Convert.ToInt32(osessionService.UserId);

                oResultat = await oTSL09ImputPayService.GetResutPasserConstSalaire(oparam);

                isLoading = false;

                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);


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

        public async Task PasserSalaireAutreBank()
        {

            if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Do you really want to POST this Transaction ?"))
                return;

            try
            {
                isLoading = true;
                oResultat = new Resultat();

                ParamTransSalaire oparam = new ParamTransSalaire();

                oparam.Exercice = 2024;
                oparam.Mois = 12;
                oparam.UserID = Convert.ToInt32(osessionService.UserId);

                oResultat = await oTSL09ImputPayService.GetResutPasserConstSalaire(oparam);

                isLoading = false;

                await JSRuntime.InvokeVoidAsync("alert", oResultat.Result);


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

        public string getRowColor(int i)
        {
            return (i % 2 == 0) ? "table-info" : "table-light";
        }


        protected override async Task OnInitializedAsync()
        {
            osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");
            try
            {
                oConstSalaireList=(await oTSL09ImputPayService.GetConstatSalaire()).ToList(); 

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
