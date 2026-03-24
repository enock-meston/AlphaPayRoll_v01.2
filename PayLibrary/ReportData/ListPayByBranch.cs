using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PayLibrary.ReportData
{
    public class ListPayByBranch
    {
        public int Numero { get; set; }
        public string Branch { get; set; }
        public int BranchLocID { get; set; }
        public string Matricule { get; set; }
        public string Code { get; set; }
        public string Noms { get; set; }
        public decimal SalBase { get; set; }
        public decimal IndemLog { get; set; }
        public decimal IndemDeplac { get; set; }     
        public decimal IndemFct { get; set; }
        public decimal Gratifications { get; set; }
        public decimal TotalIndem { get; set; }
        public decimal Primes { get; set; }
        public decimal SALAIRE_BRUT { get; set; }
        public decimal TPR { get; set; }
        public decimal AutresAvantage { get; set; }
        public decimal SALAIRE_IMPOSABLE { get; set; }
        public decimal Cotisation_Patronale { get; set; }
        public decimal Cotisation_Caisse_Social { get; set; }
        public decimal RSSB_EMPLOYEUR { get; set; }
        public decimal RSSB_EMPLOYEE { get; set; }
        public decimal MutSante { get; set; }
        public decimal? AutRetenues { get; set; } // Nullable because of NULL values
        public decimal TotalReteNonStat { get; set; }
        public decimal TotalRetenue { get; set; }
        public decimal NetAPayer { get; set; }
        // Stored procedure returns SQL datetime (GetDate()).
        public DateTime DateJ { get; set; }
    }
}
