using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static PayAPI.RepServices.SuperviseurZonervice;


namespace AlphaPayRoll.DataServices.AgentComReport
{
    public class AgentComDonZoneService : ISuperviseurZoneService
	{

		private readonly HttpClient ohttpClient;

		public AgentComDonZoneService(HttpClient httpC)
		{
			ohttpClient = httpC;
		}

	
		public async Task<byte[]> GenerateListZoneAsync(string reportName, string reportType, int Periode)
		{
			return (await ohttpClient.GetByteArrayAsync($"api/AgentComZoneSit/{reportName}/{reportType}/{Periode}"));
		}





	}
}
