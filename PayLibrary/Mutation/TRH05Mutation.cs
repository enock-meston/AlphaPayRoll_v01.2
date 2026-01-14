using System;

namespace PayLibrary.Localisation
{
    public class TRH05Mutation
    {
        public int ID { get; set; } = 0;
        public string Matricule { get; set; } = "";
        public string SBranchFromID { get; set; } = "";
        public string SBranchToID { get; set; } = "";
        public DateTime DateMut { get; set; } = DateTime.Now;
        public string RaisonMut { get; set; } = "";

        public int FunctionID { get; set; } = 0;
        public int StatusID { get; set; } = 0;
        public int CreatBy { get; set; } = 0;
        public DateTime CreatOn { get; set; } = DateTime.Now;
        public int LModifBy { get; set; } = 0;
        public DateTime? LModifOn { get; set; } = DateTime.Now;
        //public int ValidBy { get; set; } 
        //public DateTime? ValidOn { get; set; }
        public int UserID { set; get; } = 0;
        public int TpMaj { get; set; } = 0;

    }
}
