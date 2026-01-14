using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.TSL550TPHSup
{
    public class ClassTSL550TPHSup
    {
		public int ID { set; get; }
		public string RICode { set; get; }
		public string Descript { set; get; }
		public bool Enab { set; get; }
		public int Ordnum { set; get; }
		public int CreatBy { set; get; }
		public DateTime CreatOn { set; get; }
		public int LModifBy { set; get; }
		public DateTime LModifOn { set; get; }
		public int UserID { set; get; }
		public int TpMaj { set; get; }
	}
}
