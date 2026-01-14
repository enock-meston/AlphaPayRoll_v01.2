using Microsoft.AspNetCore.Components;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.SalProcess;
using PayLibrary.TRH02Agent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaPayRoll.DataServices.SalProcess
{
	public class SalProcessService : ITSL00Process
	{

		private readonly HttpClient oHttpClient;

		public SalProcessService(HttpClient httpClient)
		{
			oHttpClient = httpClient;
		}

		public async Task<Resultat> GetArchiverSalResult(ParamPeriod item)
		{
			return await oHttpClient.PostJsonAsync<Resultat>($"api/ArchiverSalaires/", item);
		}

		public async Task<Resultat> GetCalculerSalResult(ParamPeriod item)
		{
			return await oHttpClient.PostJsonAsync<Resultat>($"api/CalculSalaires/", item);
		}

		public async Task<Resultat> GetIntialisSalResult(ParamPeriod item)
		{
			return await oHttpClient.PostJsonAsync<Resultat>($"api/SalInitialisation/", item);
		}

		public async Task<List<TSL00Process>> GetSalProcessAll()
		{
			return (await oHttpClient.GetJsonAsync<TSL00Process[]>($"api/SalProcess/")).ToList();
		}

		public async Task<List<TSL00Process>> GetSalProcessByPeriod(ParamPeriod item)
		{
			return (await oHttpClient.PostJsonAsync<TSL00Process[]>($"api/SalProcessPeriod/", item)).ToList();
		}

		public async Task<Resultat> GetUpdateResult(TSL00Process item)
		{
			return await oHttpClient.PostJsonAsync<Resultat>($"api/SalProcess/", item);
		}
	}
}
