using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.CongeRequestF
{
    public class THRCongCircRequest
    {
        public int ID { set; get; } = 0;
        public int PlanningID { set; get; } = 0;
        public string Matricule { set; get; } = "";
        public string SBranchID { set; get; } = "";
        //public int TpCongeID { set; get; }
        public string Exercice { set; get; } = "";
        public int NumTranche { set; get; } = 0;
        public DateTime DateRequest { set; get; } = DateTime.Now;
        public DateTime DateDebutReq { set; get; } = DateTime.Now;
        public DateTime DateFinReq { set; get; } = DateTime.Now;
        public DateTime? DateDebutApprov { set; get; } = DateTime.Now;
        public DateTime? DateFinApprov { set; get; } = DateTime.Now;
        public int NbrJour { set; get; } = 0;
        public int NbrJourApprov { set; get; } = 0;
        public int NbrJAccord { set; get; } = 0;
        public string DecChefDirect { set; get; } = "";
        public string DecHR { set; get; } = "";
        public string StatusHRID { set; get; } = "";
        public string StatusChefID { set; get; } = "";
        public string StatusDGID { set; get; } = "";
        public string RemChefD { set; get; } = "";
        public string RemHR { set; get; } = "";
        public string RemDG { set; get; } = "";
        public string DecDG { set; get; } = ""; 
        public string DecFinale { set; get; } = "";     
        public DateTime? DateDecFinale { set; get; } =DateTime.Now;
        public DateTime? CreatOn { set; get; } = DateTime.Now;
        public int CreatBy { set; get; } = 0;
        public int LModifBy { set; get; } = 0;
        public DateTime? LModifOn { set; get; } = DateTime.Now;
        public int UserID { set; get; } = 0;
        public int TpMaj { set; get; } = 0;

        
    }
}
