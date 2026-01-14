using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TCl550MaritStatus;

namespace PayLibrary.TSL03TraitemAv
{
	public interface ITSL03TraitemAv
	{

		Task<List<ClassTSL03TraitemAv>> GetTSL03TraitemAv();
		Task<Resultat> GetResutUpdate(ClassTSL03TraitemAv item);
	}
}

