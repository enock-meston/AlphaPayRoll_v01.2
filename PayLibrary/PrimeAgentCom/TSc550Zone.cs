using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.PrimeAgentCom
{
	public class TSc550Zone
	{
		public string ID { set; get; }
		public string RICode { set; get; }
		public string Descript { set; get; }
		public bool Enab { set; get; }
		public int OrdNum { set; get; }
		public decimal EcoursTotal { set; get; }
		public decimal EcoursNP { set; get; }
		public decimal PAR { set; get; }
		public decimal InteretCredit { set; get; }
		public decimal Resultat { set; get; }
		public int CreatBy { set; get; }
		public DateTime CreatOn { set; get; }
		public int LModifBy { set; get; }
		public DateTime LModifOn { set; get; }
		public bool LoanDisbAlowed { set; get; }
		public int Superv { set; get; }
		public string NomPeriode { set; get; }
	}
}
