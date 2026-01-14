using PayLibrary.Exercice;
using PayLibrary.ParamSec;
using PayLibrary.ParamSec.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.SalProcess
{
	public  interface ITSL00Process
	{


		Task<List<TSL00Process>> GetSalProcessAll();
		Task<List<TSL00Process>> GetSalProcessByPeriod(ParamPeriod item);
		Task<Resultat> GetIntialisSalResult(ParamPeriod item);
		Task<Resultat> GetCalculerSalResult(ParamPeriod item);
		Task<Resultat> GetArchiverSalResult(ParamPeriod item);
		Task<Resultat> GetUpdateResult(TSL00Process item);
	}
}
