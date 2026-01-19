using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TCl550MaritStatus;

namespace PayLibrary.TRH02Agent
{
	public interface ITRH02Agent
	{
		Task<List<ClassTRH02Agent>> GetAgent();
		Task<Resultat> GetResutUpdate(ClassTRH02Agent item);
		Task<Resultat> GetResutMajSalaire(ClassTRH02Agent item);
		Task<Resultat> GetCalculerSalaire(ClassTRH02Agent item);
		Task<Resultat> GetUpdateDon(ClasParamMajDon item);
		Task<List<ClassTRH02Agent>> GetAgentRech(string id);
		Task<List<ClassTRH02Agent>> GetAgentByChef(ParamAgentByChef param);
		Task<List<ClassTRH02Agent>> GetAgentByMatricule(string id);
		Task<List<ClassTRH02Agent>> GetAgentBySubBranch(string id);
		Task<List<ClassTRH02Agent>> GetAgentByMatriculeCongeReq(ParamAgentMatricule param);
		Task<List<ClassTRH02Agent>> GetAgentByMatriculeXX(ParamAgentMatricule param);
		Task<Resultat> ValidePlanningConge(ParamAgentMatricule param);


    }
}

