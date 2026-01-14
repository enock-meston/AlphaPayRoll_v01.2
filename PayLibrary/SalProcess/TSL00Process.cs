using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.SalProcess
{
	public class TSL00Process
	{

		public int ID { set; get; }
		public int Exercice { set; get; }
		public int Mois { set; get; }
		public int SalStepID { set; get; }
		public DateTime DateInitialis { set; get; }

        public bool ConstatationPass { set; get; }
        public bool SalairesPass { set; get; }
        public bool RemboursPass { set; get; }
        public bool Valid { set; get; }
		public DateTime DateValidation { set; get; }
		public DateTime DateCalcul { set; get; }
		public DateTime DateArchive { set; get; }

		public DateTime CreatOn { set; get; }
		public int CreatBy { set; get; }
		public int LModifBy { set; get; }
		public DateTime LModifOn { set; get; }
		public int UserID { set; get; }
		public int TpMaj { set; get; }
		public string StepDenom { set; get; }
	}
}
