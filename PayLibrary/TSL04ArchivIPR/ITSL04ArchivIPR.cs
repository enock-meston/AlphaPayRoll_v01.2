using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TCl550MaritStatus;

namespace PayLibrary.TSL04ArchivIPR
{
	public interface ITSL04ArchivIPR
	{
		Task<List<ClassTSL04ArchivIPR>> GetTSL04ArchivIPR();
		Task<Resultat> GetResutUpdate(ClassTSL04ArchivIPR item);
	}
}

