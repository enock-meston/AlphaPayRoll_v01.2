using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.ContratSusp
{
    public class TRH03ContratSusp
    {
        public int ID { set; get; } = 0;
        public string NumContrat { set; get; } = "";
        public string MATRICULE { set; get; } = "";
        public int Categorie { set; get; } = 0;
       public DateTime? DateDebut { set; get; } = DateTime.Now;
        public DateTime? DateFin { set; get; } = DateTime.Now;
        
        public DateTime? DateFinProbable { set; get; } = DateTime.Now;
        public int StatusID { set; get; } = 0;
        public string ContractStatus { set; get; } = "";
       public DateTime? DateChangStatus { set; get; } = DateTime.Now;
        public string Notes { set; get; } = "";
        public string Motif { set; get; } = "";
        public int CreatBy { set; get; } = 0;
        public DateTime? CreatOn { set; get; } = DateTime.Now;
        public int LModifBy { set; get; } = 0;
         public DateTime? LModifOn { set; get; } = DateTime.Now;

        public int ValidBy { set; get; } = 0;
        public DateTime? ValidOn { set; get; } = DateTime.Now;
        public int UserID { set; get; } = 0;
        public int TpMaj { set; get; }  = 0;
    }
}
