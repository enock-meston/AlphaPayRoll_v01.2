using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayLibrary.TCl550MaritStatus
{
	public interface ITCl550MaritStatus
	{
		Task<List<ClassTCl550MaritStatus>> GetTCl550MaritStatus();
		//Task<Resultat> GetResutUpdate(ClassTCl550MaritStatus item);
	}
}

