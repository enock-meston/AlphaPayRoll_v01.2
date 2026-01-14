using System;
using System.ComponentModel.DataAnnotations;

namespace PayLibrary.TSL03Traitem
{
	public class ClassTSL03Traitem
	{
        public int ID { set; get; }
        public int AgentId { set; get; }
        public int An { set; get; }
        public int Mois { set; get; }
        public int NbreJTrav { set; get; }
        public decimal SalBase { set; get; }
        public decimal Logem { set; get; }
        public decimal Deplacem { set; get; }
        public decimal Alloc { set; get; }
        public decimal IndemFct { set; get; }
        public decimal AutresIndmt { set; get; }

		public decimal Indemnit { set; get; }
		public decimal HeureSup { set; get; }
        public decimal RegulAugm { set; get; }
        public decimal Brut { set; get; }
        public decimal BaseIPR { set; get; }
        public decimal RegulDimin { set; get; }
		public decimal PensComp10Prc { set; get; }
		public decimal PensionComp { set; get; }
        public decimal Remboursement { set; get; }
        public decimal Cotisation { set; get; }
        public decimal AutreRetenue { set; get; }
        public decimal INSS { set; get; }
        public decimal IPR { set; get; }
        public decimal NETS { set; get; }
        public decimal PPINSS6 { set; get; }
        public decimal PPINSS3 { set; get; }
        public decimal PPPens { set; get; }
        public int CreatBy { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatOn { set; get; }
        public int LModifBy { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LModifOn { set; get; }
        public int UserID { set; get; }
        public int TpMaj { set; get; }
    }
}

