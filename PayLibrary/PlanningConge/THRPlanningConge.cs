using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.PlanningConge
{
    public class THRPlanningConge
    {


        public int ID { get; set; } = 0;
        public string Exercice { get; set; } = "";
        public string Matricule { get; set; } = "";
        public string ProposMois { get; set; } = "";
        public string ApprovMois { get; set; } = "";
        public string SBranchID { get; set; } = "";
        public int NumTranche { get; set; } = 0;
        public int ProposNbreJour { get; set; } = 0;
        public int ApprovNbreJour { get; set; } = 0;
        public int NbrJourPris { get; set; } = 0;
        public string Remark { get; set; } = "";
        public string StatusChefD { get; set; } = "";
        public string RemChefD { get; set; } = "";
        //public string RemDG { get; set; }

        public int CreatBy { get; set; } = 0;
        public DateTime? CreatOn { get; set; } =DateTime.Now;
        public int LModifBy { get; set; } = 0;
        public DateTime? LModifOn { get; set; } = DateTime.Now;
        public int UserID { get; set; } = 0;
        public int TpMaj { get; set; } = 0;
    }
}
