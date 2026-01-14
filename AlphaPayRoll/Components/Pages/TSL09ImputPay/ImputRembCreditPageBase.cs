using AlphaPayRoll.Data;
using AlphaPayRoll.DataServices.TCl550MaritStatus;
using AlphaPayRoll.DataServices.TSL09ImputPay;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TRH02Agent;
using PayLibrary.TSL09ImputPay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaPayRoll.Components.Pages.TSL09ImputPay
{
    public class ImputRembCreditPageBase : ComponentBase
    {

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }


        public ClasSessionStorage osessionService { set; get; }

        [Inject]
        protected Blazored.SessionStorage.ISessionStorageService osessionStorage { set; get; }


        [Inject]
        protected ITSL09ImputPay oTSL09ImputPayService { set; get; }

        public List<TMontConstSalaire> oConstSalaireList { set; get; }


        [Parameter]
        public string id { get; set; }

        public bool isLoading { get; set; } = true;

        [Inject]
        protected ITRH02Agent oTRH02AgentService { set; get; }

        public List<ClassTRH02Agent> oTRH02AgentList { set; get; }


        public async Task VerifConstationSalaire()
        {
            await JSRuntime.InvokeVoidAsync("alert", "Verification OK");
        }


        Resultat oResultat = new Resultat();


        public ClassTRH02Agent oOneTRH02Agent { get; set; } 

        public async Task PasserRembCredit()
        {

            if (!await JSRuntime.InvokeAsync<bool>("confirm", $"Voulez-vous passer le remboursement des crédits ?"))
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

                oResultat = await oTSL09ImputPayService.GetResutPasserRembCredit(oparam);

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

        public string CurrencyFormat { set; get; } = "###,##0";
        public decimal TotRemb { get; set; } = 0;
        protected override async Task OnInitializedAsync()
        {
            osessionService = await osessionStorage.GetItemAsync<ClasSessionStorage>("LogedUser");

            try
            {

                isLoading = true;

                oOneTRH02Agent =new ClassTRH02Agent();

                oConstSalaireList = (await oTSL09ImputPayService.GetConstatSalaire()).ToList();

                oTRH02AgentList = await oTRH02AgentService.GetAgent();
                oTRH02AgentList = oTRH02AgentList.Where(row => (row.StatusId==1  && row.RembCredit>0)).ToList();



                TotRemb = (from RembCredit in oTRH02AgentList select RembCredit.RembCredit).Sum();


                //if (oTRH02AgentList.Count > 0)
                //{
                //    foreach(var row in oTRH02AgentList)
                //    {
                //        TotRemb= TotRemb + row.RembCredit;  
                //    }

                //}


                isLoading = false;
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



    }
}

