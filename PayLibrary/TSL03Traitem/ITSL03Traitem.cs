using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TCl550MaritStatus;

namespace PayLibrary.TSL03Traitem
{
	public interface ITSL03Traitem
	{
		Task<List<ClassTSL03Traitem>> GetTSL03Traitem();
        Task<List<ClassTSL03Traitem>> GetTSL03TraitemByAgent(int id);
        Task<Resultat> GetResutUpdate(ClassTSL03Traitem item);
	}
}

