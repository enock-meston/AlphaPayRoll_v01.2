using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TSL09ImputPay;
using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;

namespace AlphaPayRoll.DataServices.TSL09ImputPay
{
    public class TSL09ImputPayService : ITSL09ImputPay
    {
        private readonly HttpClient oHttpClient;

        public TSL09ImputPayService(HttpClient httpClient)
        {
            oHttpClient = httpClient;
        }

        public async Task<List<ClassTSL09ImputPay>> GetTSL09ImputPay()
        {
            return (await oHttpClient.GetJsonAsync<ClassTSL09ImputPay[]>($"api/TSL09ImputPay/")).ToList();
        }


        public async Task<Resultat> GetResutUpdate(ClassTSL09ImputPay item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/TSL09ImputPay/", item);
        }

        public async Task<Resultat> GetResutPasserConstSalaire(ParamTransSalaire item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/PasserTransConst/", item);
        }

        public async Task<Resultat> GetResutPasserSalaire(ParamTransSalaire item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/PasserTransImputSalLoc/", item);
        }

        public async Task<Resultat> GetResutPasserRembCredit(ParamTransSalaire item)
        {
            return await oHttpClient.PostJsonAsync<Resultat>($"api/PasserTransImputRemb/", item);
        }

        public async Task<List<TMontConstSalaire>> GetConstatSalaire()
        {
            return (await oHttpClient.GetJsonAsync<TMontConstSalaire[]>($"api/DonConstSalaire/")).ToList();
        }
    }
}

