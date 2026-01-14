using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TCl550MaritStatus;

namespace PayLibrary.TSL04ArchivINSS
{
	public interface ITSL04ArchivINSS
	{

		Task<List<ClassTSL04ArchivINSS>> GetTSL04ArchivINSS();
		Task<Resultat> GetResutUpdate(ClassTSL04ArchivINSS item);
	}
}

