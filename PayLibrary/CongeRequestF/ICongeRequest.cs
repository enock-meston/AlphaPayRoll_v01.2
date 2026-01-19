using PayLibrary.CongCircRequest;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TRH02Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.CongeRequestF
{
	public interface ITHRCongCircRequest
	{
		Task<List<THRCongCircRequest>> GetAllCongeRequests();
		Task<List<THRCongCircRequest>> GetAllCongeRequestsByMatricule(string id);
		//Task<ClassTRH02Agent> GetAllCongeRequestsByMatriculeXX(ParamAgentMatricule param);
		Task<Resultat> ValideCongeRequest(ParamMatricule param,int id);
        Task<Resultat> GetUpdateResult(THRCongCircRequest item);

	}
}
