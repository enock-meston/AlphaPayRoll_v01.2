using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TSL02AgHSup
{
   public class ClassTSL02AgHSup
    {
		public int ID { set; get; }
		public int Exercice { set; get; }
		public int Mois { set; get; }
		public int AgentID { set; get; }
		public int TpHSupID { set; get; }
		public DateTime SemaineDu { set; get; }
		public DateTime Au { set; get; }
		public int Nombre { set; get; }
		public Decimal TxAppl { set; get; }
		public Decimal SalBase { set; get; }
		public Decimal Montant { set; get; }
		public int CreatBy { set; get; }
		public DateTime CreatOn { set; get; }
		public int LModifBy { set; get; }
		public DateTime LModifOn { set; get; }
		public string NomAgent { set; get; }
        public int UserID { set; get; }
		public int TpMaj { set; get; }
	}
}