using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TSL02AgDimAugmSal
{
   public class ClassTSL02AgDimAugmSal
    {
		public int ID { set; get; }
		public int AgentId { set; get; }
		public int TpRetId { set; get; }
		public int Exercice { set; get; }
		public int Mois { set; get; }
		public Decimal MontAPay { set; get; }
        public Decimal PayMensuel { set; get; }
        public Decimal MontAPayMois { set; get; }
        public Decimal CumulPay { set; get; }
        public Decimal ResteAPay { set; get; }
		public bool Perman { set; get; }
		public int Sens { set; get; }
		public bool EnVig { set; get; }
		public string Denom { set; get; }
		public int CreatBy { set; get; }
		public DateTime CreatOn { set; get; }
		public int LModifBy { set; get; }
		public DateTime LModifOn { set; get; }
        public string NomAgent { set; get; }
        public int UserID { set; get; }
		public int TpMaj { set; get; }
	}
}
