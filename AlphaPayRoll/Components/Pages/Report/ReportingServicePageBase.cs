
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

using PayLibrary.Report;
using PayLibrary.IReport;
using AlphaPayRoll.Data;

namespace AlphaPayRoll.Components.Pages.Report
{
    public class ReportingServicePageBase : ComponentBase
    {
        [Inject]
        protected SessionService osessionService { set; get; }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        private ITVeh99Rapport oTVeh99Rapport { set; get; }


        public List<TVeh99Rapport> oTVeh99RapportList { set; get; }


        public TVeh99Rapport oTVeh99RapportInsert = new TVeh99Rapport();





        [Parameter]
        public string id { set; get; }


        protected bool popup = false;


        public string StyleButton { set; get; }
        public string ButtonCaption { set; get; }

        public string modalTitle { set; get; }

        protected void ShowPopUp(int tPAction)
        {

            if (tPAction == 0)
            {
                modalTitle = "Détails paramétrage";
            }




            popup = true;
        }

        protected void ClosePopUp()
        {
            popup = false;
        }



        public int iTypeAction { set; get; }





        protected void EditTableNivOne(TVeh99Rapport ModifTableNivOne, int TpAction)
        {

            iTypeAction = TpAction;
            oTVeh99RapportInsert = ModifTableNivOne;



            ShowPopUp(iTypeAction);
        }



        public string getRowColor(int i)
        {
            return (i % 2 == 0) ? "table-info" : "table-light";
        }


        public bool VerrouillerExport { set; get; } = true;

        public bool isLoading { set; get; } = true;


  

        protected override async Task OnInitializedAsync()
        {
            iTypeAction = 0;

            
            try
            {
                oTVeh99RapportList = (await oTVeh99Rapport.GetList(osessionService.MenuId)).ToList();
                VerrouillerExport = false;
            }
            catch (Exception ex)
            {
                await JSRuntime.InvokeVoidAsync("alert", ex.Message);
                VerrouillerExport = true;
            }
            finally
            {
                isLoading = false;
            }
        }
    }
}
