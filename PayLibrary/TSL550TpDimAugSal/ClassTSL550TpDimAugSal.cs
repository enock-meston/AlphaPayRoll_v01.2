using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TSL550TpDimAugSal
{
    public class ClassTSL550TpDimAugSal
    {
		public int ID { set; get; }
		public string Denom { set; get; }
		public bool Perman { set; get; }
		public int Sens { set; get; }
		public bool Occasionnel { set; get; }
		public int CreatBy { set; get; }
		public DateTime CreatOn { set; get; }
		public int LModifBy { set; get; }
		public DateTime LModifOn { set; get; }
		public int UserID { set; get; }
		public int TpMaj { set; get; }
	}
}
