using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TCl550MaritStatus;

namespace PayLibrary.TRH02AgentNew
{
	public interface ITRH02Agent
	{
		Task<List<ClassTRH02Agent>> GetAgent();
		Task<Resultat> GetResutUpdate(ClassTRH02Agent item);
        Task<Resultat> GetResutMajSalaire(ClassTRH02Agent item);
        Task<Resultat> GetCalculerSalaire(ClassTRH02Agent item);
        Task<Resultat> GetUpdateDon(ClasParamMajDon item);
        Task<List<ClassTRH02Agent>> GetAgentRech(string id);
        Task<List<ClassTRH02Agent>> GetAgentByMatricule(string id);

    }
}

