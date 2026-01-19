using System;
using System.ComponentModel.DataAnnotations;

namespace PayLibrary.TRH02Agent
{
	public class ClassTRH02Agent
	{

		public int AgentId { set; get; } = 0;
		public string Matricule { set; get; } = "";
		public string BranchCpteID { set; get; } = "";
		public string SBranchCpteID { set; get; } = "";
		public int ChefID {  set; get; } = 0;

        public string BranchLocID { set; get; } = "";
		public string SBranchLocID { set; get; }= "";
		public string Code { set; get; } = "";
		public Int64 ClientId { set; get; } = 0;
		public string Nom { set; get; } = "";
		public string Prenom { set; get; } = "";
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime DateNais { set; get; } = DateTime.Now;
		public int Sexe { set; get; } = 0;
		public int EtatCivId { set; get; } = 0;
		public int NbrepCharge { set; get; } = 0;
		
		public int DepartementId { set; get; } = 0;
		public int FonctionId { set; get; } = 0;
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime DateRecrutment { set; get; } = DateTime.Now;
        [DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime DateDepart { set; get; } =DateTime.Now;
		public string Telephone { set; get; } = "";
		public string IdNum { set; get; } = "";
		public string Email { set; get; } = "";
		public string NumCSR { set; get; } = "";
		public int NivEtudId { set; get; } = 0;
		public int DomEtudId { set; get; } = 0;
		public int DiplomId { set; get; } = 0;
		public int UniverId { set; get; } = 0;
		public int StatusId { set; get; } = 0;
		public int NumOrdre { set; get; } = 0;
		public int CpteCredit { set; get; } = 0;
		public int CpteAvance { set; get; } = 0;
		public int CptApVie { set; get; } = 0;
		
		public int PayDay { set; get; } = 0;

		public decimal SalBase { set; get; } = 0;
		public decimal IndemLog { set; get; } = 0;
		public decimal IndemDeplac { set; get; } = 0;
		public decimal IndemFct { set; get; } = 0;
		public decimal Gratifications { set; get; } = 0;
		public decimal IndemAutre { set; get; } = 0;
		public decimal Primes { set; get; }= 0;
		public decimal AutresAvantage { set; get; } = 0;
		public decimal SALAIRE_BRUT { set; get; } = 0;
		public decimal SALAIRE_IMPOSABLE { set; get; } = 0;
		public decimal Cotisation_Patronale { set; get; } = 0;
		public decimal Cotisation_Caisse_Social { set; get; } = 0;
		public decimal RSSB_EMPLOYEUR { set; get; } = 0;
		public decimal RSSB_EMPLOYEE { set; get; } = 0;
		public decimal TPR { set; get; } = 0;
		public decimal RSSBPens { set; get; } = 0;
		public decimal MedInsur { set; get; } = 0;
		public decimal MutSante { set; get; } = 0;
		public decimal RembCredit { set; get; } = 0;
		public decimal RembBourse { set; get; } = 0;
		public decimal RetSanLam { set; get; } = 0;
		public decimal RetPrimeLife { set; get; } = 0;
		public decimal RetCaisseSolid { set; get; } = 0;
		public decimal RetCaisEp { set; get; } = 0;
		public decimal RetEjoHeza { set; get; } = 0;
		public decimal AutRetenues { set; get; } = 0;
		public decimal TotalRetenue { set; get; } = 0;
		public decimal NetAPayer { set; get; } = 0;
		public decimal RIPPSPAYMENT { set; get; } = 0;
		public decimal BourseRipps { set; get; } = 0;
		public decimal EjoHezaRipps { set; get; } = 0;
		public decimal AutreRetRipps { set; get; } = 0;

		public bool ViremRIPPS { set; get; } = false;

		public string BanqPaySalaire { set; get; } = "";
		public string CpteAutreBanq { set; get; } = "";
		public string LIEU_NAISSNACE { set; get; } = "";
		public string NUM_SECURITE_SOCIALE { set; get; } = "";
		public string NOM_CONJOINT { set; get; }="";
		public string  NUM_ALLOCATION { set; get; }= "";
        public string  NUMERO_PIECE { set; get; }= "";
        public string  LIBELLE { set; get; } = "";
        public string  ANCIENNETE { set; get; }= "";
        public string NATIONALITE { set; get; }= "";

		//days planning 
		public int CongRetard { set; get; } = 0;
		public int CongCurrentYear { set; get; } = 0;
		public int CongPris { set; get; } = 0;
		public int CongRest { set; get; } = 0;

		public int NextTranche { set; get; } = 0;
		public int ModifTranche { set; get; } = 0;
		public bool validPlanning { set; get; } = true;
        // end days planning

        public int CreatBy { set; get; } = 0;
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime? CreatOn { set; get; } = DateTime.Now;
		public int LModifBy { set; get; } = 0;
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime? LModifOn { set; get; } = DateTime.Now;
        public int UserID { set; get; } = 0;
		public int TpMaj { set; get; } = 0;

	}
}

