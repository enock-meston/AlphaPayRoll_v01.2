using Microsoft.AspNetCore.Components;
using PayLibrary.Depart;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.Training;
using PayLibrary.TxDAT;
using PayLibrary.TypeCongCircons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.TxDAT
{
    public class TCpt050TxDATService : ITCpt050TxDAT
    {

        private readonly HttpClient ohttpClient;
        

        public TCpt050TxDATService(HttpClient httpClient)
        {
            this.ohttpClient = httpClient;
        }

        public async Task<List<TCpt050TxDAT>> GetAllData()
        {
            //try
            //{
            //    var result = await ohttpClient.GetFromJsonAsync<List<TCpt050TxDAT>>("api/TCpt050TxDAT");
            //    return result ?? new List<TCpt050TxDAT>();
            //}
            //catch (HttpRequestException ex)
            //{

            //    return new List<TCpt050TxDAT>();
            //}
            return (await ohttpClient.GetJsonAsync<TCpt050TxDAT[]>($"api/TCpt050TxDAT/")).ToList();

        }

        public async Task<List<TCpt050TxDAT>> GetDataById(int id)
        {
            //throw new NotImplementedException();
            return (await ohttpClient.GetJsonAsync<TCpt050TxDAT[]>($"api/TCpt050TxDAT/{id}")).ToList();
        }

        public async Task<Resultat> GetUpdateResult(TCpt050TxDAT item)
        {
            Resultat oResult = new Resultat();

            var response = await ohttpClient.PostAsJsonAsync<TCpt050TxDAT>($"api/TCpt050TxDAT/", item);

            if (response.IsSuccessStatusCode)
            {
                oResult = await response.Content.ReadFromJsonAsync<Resultat>();
            }
            return oResult;
        }

      
    }
}
