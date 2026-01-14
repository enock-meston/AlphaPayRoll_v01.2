using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TCl550MaritStatus;

namespace PayLibrary.TSto551EventIn
{
	public interface ITSto551EventIn
	{
		Task<List<ClassTSto551EventIn>> GetTSto551EventIn();
		Task<Resultat> GetResutUpdate(ClassTSto551EventIn item);
	}
}

