using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayLibrary.ParamSec.ViewModel;
using PayLibrary.TCl550MaritStatus;

namespace PayLibrary.TSL09ImputPay
{
	public interface ITSL09ImputPay
	{
		Task<List<ClassTSL09ImputPay>> GetTSL09ImputPay();
		Task<Resultat> GetResutUpdate(ClassTSL09ImputPay item);

        Task<Resultat> GetResutPasserConstSalaire(ParamTransSalaire item);
        Task<Resultat> GetResutPasserSalaire(ParamTransSalaire item);
        Task<Resultat> GetResutPasserRembCredit(ParamTransSalaire item);

        Task<List<TMontConstSalaire>> GetConstatSalaire();
    }
}

