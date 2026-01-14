using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.ListePaie
{
	public class ClasListRetNStat
	{
		public int Numero { set; get; }
		public string Agence { set; get; }
		public string Matricule { set; get; }
		public string Noms { set; get; }
		public decimal RembCredit { set; get; }
		public decimal RembBourse { set; get; }
		public decimal RetSanLam { set; get; }
		public decimal RetPrimeLife { set; get; }
		public decimal RetCaisseSolid { set; get; }
		public decimal RetCaisEp { set; get; }
		public decimal RetEjoHeza { set; get; }
		public decimal AutRetenues { set; get; }
		public decimal TotalReteNonStat { set; get; }
	}
}
