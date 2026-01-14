using System;
using System.ComponentModel.DataAnnotations;

namespace PayLibrary.CongCircRequest
{
    public class THRCongCircRequestNew
    {
        public int ID { set; get; } = 0;
        public string Matricule { set; get; } = "";
        public string SBranchID { set; get; } = "";
        public int TpCongeID { set; get; } = 0;
        public DateTime? DateRequest { set; get; } = DateTime.Now;
        public int NbrJour { set; get; } = 0;
        public  string Observation { set; get; } = "";
        public string StatusHRID { set; get; } = "";
        public string StatusChefID { set; get; } = "";
        public string StatusDGID { set; get; } = "";
        public string DecFinale { set; get; } = "";
        public DateTime? DateDecFinale { set; get; } = DateTime.Now;
        public DateTime? CreatOn { set; get; } = DateTime.Now;
        public int CreatBy { set; get; } = 0;
        public int LModifBy { set; get; } = 0;
        public DateTime? LModifOn { set; get; } = DateTime.Now;
        public int UserID { set; get; } = 0;
        public int TpMaj { set; get; } = 0;
    }
}
