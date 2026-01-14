using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PayLibrary.ParamSec.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using PayLibrary.RubSalCompte;

namespace AlphaPayRoll.Components.Pages.RubSalCompte
{
    public class TSl550RubSalComptePageBase:ComponentBase
    {
       
        [Inject]
        protected ITSl550RubSalCompte oTSl550RubSalCompteService { set; get; }

        public List<TSl550RubSalCompte> oTSl550RubSalCompteList { set; get; }

        public string GetRowColor(int i)
        {
            return i % 2 == 0 ? "table-info" : "table-light";
        }

        public bool isLoading { set; get; } = true;



        public string ErrorResult { set; get; }

        protected override async Task OnInitializedAsync()
        {

            try
            {
                oTSl550RubSalCompteList = await oTSl550RubSalCompteService.GetList();
            }
            catch (Exception ex)
            {

                ErrorResult = ex.Message.ToString();
                //await JSRuntime.InvokeVoidAsync("alert", ex.Message);
            }
            finally
            {
                isLoading = false;
            }
        }

        public TSl550RubSalCompte oOneItem { set; get; }
        public bool popup { set; get; } = false;
        public void ShowPopUp(TSl550RubSalCompte item)
        {
            oOneItem = item;
            popup = true;

        }

    }
}
