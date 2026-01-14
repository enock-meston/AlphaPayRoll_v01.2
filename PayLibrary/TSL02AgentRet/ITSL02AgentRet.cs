using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TCl550MaritStatus;

namespace PayLibrary.TSL02AgentRet
{
	public interface ITSL02AgentRet
	{

		Task<List<ClassTSL02AgentRet>> GetTSL02AgentRet();
		Task<Resultat> GetResutUpdate(ClassTSL02AgentRet item);
	}
}

