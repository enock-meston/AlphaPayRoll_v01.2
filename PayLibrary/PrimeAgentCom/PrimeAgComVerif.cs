using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.PrimeAgentCom
{
	public class PrimeAgComVerif
	{

		public string Agence { set; get; }
		public string Guichet { set; get; }
		public int Numero { set; get; }
		public string TpGestinnaire { set; get; }
		public string NOM { set; get; }
		public decimal MinResulGuichet { set; get; }
		public decimal ResultGuichet { set; get; }
		public decimal ResultCum { set; get; }
		public decimal MinIntGuichet { set; get; }
		public decimal IntGuichet { set; get; }
		public string TpStructure { set; get; }
		public decimal PARStructure { set; get; }
		public decimal EcoursTotal { set; get; }
		public decimal EcoursNP { set; get; }
		public decimal PAR { set; get; }
		public decimal MinIntIndiv { set; get; }
		public decimal IntIndiv { set; get; }
		public decimal NbrClientCredit { set; get; }
		public decimal NbrClientApport { set; get; }
		public bool EligPAR { set; get; }
		public bool EligIntGuichet { set; get; }
		public bool ELigResultGuichet { set; get; }
		public bool EligNbrClient { set; get; }
		public bool EligibIntAgent { set; get; }
		public bool EligPARAgent { set; get; }
		public bool Eligible { set; get; }
		public decimal PrimPerfo { set; get; }
		public string NomPeriode { set; get; }
	}
}
