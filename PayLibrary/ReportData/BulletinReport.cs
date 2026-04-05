using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.ReportData
{
    public class BulletinReport
    {
        public string Matricule { get; set; }
        public string Names { get; set; }
        public string Guichet { get; set; }
        public DateTime DateRecrutment { get; set; }
        public string Fonction { get; set; }
        public int PayDay { get; set; }
        public decimal SalBase { get; set; }
        public decimal IndemLog { get; set; }
        public decimal IndemDeplac { get; set; }
        public decimal IndemFct { get; set; }
        public decimal Gratifications { get; set; }
        public decimal TotalIndem { get; set; }
        public decimal Primes { get; set; }
        public decimal AutresAvantage { get; set; }
        public decimal SALAIRE_BRUT { get; set; }
        public decimal SALAIRE_IMPOSABLE { get; set; }
        public decimal Cotisation_Patronale { get; set; }
        public decimal Cotisation_Caisse_Social { get; set; }
        public decimal RSSB_EMPLOYEUR { get; set; }
        public decimal RSSB_EMPLOYEE { get; set; }
        public decimal TPR { get; set; }
        public decimal RSSBPens { get; set; }
        public decimal MedInsur { get; set; }
        public decimal MutSante { get; set; }
        public decimal RembCredit { get; set; }
        public decimal RembBourse { get; set; }
        public decimal RetSanLam { get; set; }
        public decimal RetPrimeLife { get; set; }
        public decimal RetCaisseSolid { get; set; }
        public decimal RetCaisEp { get; set; }
        public decimal RetEjoHeza { get; set; }
        public decimal AutRetenues { get; set; }
        public decimal TotalRetenue { get; set; }
        public decimal TotalReteNonStat { get; set; }
        public decimal NetAPayer { get; set; }
        public decimal CpteAvance { get; set; }
        public decimal TOTALDU { get; set; }
        public string SBranchID { get; set; }
        public DateTime date1 { get; set; }
    }
}
