using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.ListePaie
{
    public class LstPaieConsolid
    {
        public int Numero { set; get; }
        public string Branch { set; get; }
        public string SubBranch { set; get; }
        public string Matricule { set; get; }
        public int Code { set; get; }
        public string Noms { set; get; }
        public decimal SalBase { set; get; }
        public decimal IndemLog { set; get; }
        public decimal IndemDeplac { set; get; }
        public decimal IndemFct { set; get; }
        public decimal Gratifications { set; get; }
        public decimal TotalIndem { set; get; }
        public decimal Primes { set; get; }
        public decimal SALAIRE_BRUT { set; get; }
        public decimal TPR { set; get; }
        public decimal AutresAvantage { set; get; }
        public decimal SALAIRE_IMPOSABLE { set; get; }
        public decimal Cotisation_Patronale { set; get; }
        public decimal Cotisation_Caisse_Social { set; get; }
        public decimal RSSB_EMPLOYEUR { set; get; }
        public decimal RSSB_EMPLOYEE { set; get; }
        public decimal MutSante { set; get; }
        public decimal AutRetenues { set; get; }
        public decimal TotalReteNonStat { set; get; }
        public decimal TotalRetenue { set; get; }
        public decimal NetAPayer { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateJ { set; get; }
        public int UserID { set; get; }
        public int TpMaj { set; get; }
    }
}
