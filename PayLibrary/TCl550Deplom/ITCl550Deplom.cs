using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TCl550MaritStatus;

namespace PayLibrary.TCl550Deplom
{
	public interface ITCl550Deplom
	{
		Task<List<ClassTCl550Deplom>> GetTCl550Deplom();
		Task<Resultat> GetResutUpdate(ClassTCl550Deplom item);
	}
}

