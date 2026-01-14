using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.Permission
{
   public class TRH05Permission
    {
        public int ID { set; get; } = 0;
        public string Matricule { set; get; } = "";
        //public int TpCongeID { set; get; }
        public string SBranchID { set; get; } = "";
        public DateTime? Date { set; get; } = DateTime.Now;
        public int NbrHDemand { set; get; } = 0;
        public string TAutorisationDeSortie { set; get; } = "";
        public int NbrHAccord { set; get; } = 0;
        public string MotifDemand { set; get; } = "";
        public string Decision { set; get; } = "";
        public int DecisionPrisePar { set; get; }= 0;
        public DateTime? CreatOn { set; get; } = DateTime.Now;
        public int CreatBy { set; get; } = 0;
        public int LModifBy { set; get; } = 0;
        public DateTime? LModifOn { set; get; } = DateTime.Now;

        public int UserID { set; get; } = 0;
        public int TpMaj { get; set; } = 0;
    }
}
