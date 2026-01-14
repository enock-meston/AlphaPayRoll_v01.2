using System;

namespace PayLibrary.Salaire
{
    public class TSL02Salaire
    {
        // VARCHAR / NVARCHAR
        public string Matricule { get; set; } = "";
        public string BranchCpteID { get; set; } = "";
        public string SBranchCpteID { get; set; } = "";
        public string LIEU_NAISSNACE { get; set; } = "";
        public string NUM_SECURITE_SOCIALE { get; set; } = "";
        public string NOM_CONJOINT { get; set; } = "";
        public string NUM_ALLOCATION { get; set; } = "";
        public string NUMERO_PIECE { get; set; } = "";
        public string LIBELLE { get; set; } = "";
        public string NATIONALITE { get; set; } = "";
        public string CpteAutreBanq { get; set; } = "";

        // INT
        public int? ClientId { get; set; }=0;
        public int? ANCIENNETE { get; set; } = 0;
        public int? GuichetID { get; set; } = 0;
        public int? BanqPaySalaire { get; set; } = 0;
        public int CreatBy { get; set; } = 0;
        public int LModifBy { get; set; } = 0;
        public int TpMaj { get; set; } = 0;

        // DECIMAL(18,2)
        public decimal? PayDay { get; set; } = 0;
        public decimal? SalBase { get; set; } = 0;  
        public decimal? IndemLog { get; set; } = 0;
        public decimal IndemDeplac { get; set; } = 0;
        public decimal IndemFct { get; set; } = 0;
        public decimal Gratifications { get; set; } = 0;
        public decimal TotalIndem { get; set; } = 0;
        public decimal Primes { get; set; } = 0;
        public decimal REGULARISATION { get; set; } = 0;
        public decimal AutresAvantage { get; set; } = 0;
        public decimal SALAIRE_BRUT { get; set; } = 0;
        public decimal SALAIRE_IMPOSABLE { get; set; } = 0;
        public decimal Cotisation_Patronale { get; set; } = 0;
        public decimal Cotisation_Caisse_Social { get; set; } = 0;
        public decimal RSSB_EMPLOYEUR { get; set; } = 0;
        public decimal RSSB_EMPLOYEE { get; set; } = 0;
        public decimal TPR { get; set; } = 0;
        public decimal RSSBPens { get; set; } = 0;
        public decimal MedInsur { get; set; } = 0;
        public decimal MutSante { get; set; } = 0;
        public decimal RembCredit { get; set; } = 0;
        public decimal RembBourse { get; set; } = 0;
        public decimal RetSanLam { get; set; } = 0;
        public decimal RetPrimeLife { get; set; } = 0;
        public decimal RetCaisseSolid { get; set; } = 0;
        public decimal RetCaisEp { get; set; } = 0;
        public decimal RetEjoHeza { get; set; } = 0;
        public decimal AutRetenues { get; set; } = 0;
        public decimal TotalRetenue { get; set; } = 0;
        public decimal TotalReteNonStat { get; set; } = 0;
        public decimal NetAPayer { get; set; } = 0;
        public decimal RIPPSPAYMENT { get; set; } = 0;
        public decimal BourseRipps { get; set; } = 0;
        public decimal EjoHezaRipps { get; set; } = 0;  
        public decimal AutreRetRipps { get; set; } = 0;
        public decimal ViremRIPPS { get; set; } = 0;
        public decimal IndemAutre { get; set; } = 0;

        // DATETIME2
        public DateTime? CreatOn { get; set; } = DateTime.Now;
        public DateTime? LModifOn { get; set; } = DateTime.Now;

        // Extra property not in SP but in your class
        public int UserID { get; set; } = 0;
    }
}
