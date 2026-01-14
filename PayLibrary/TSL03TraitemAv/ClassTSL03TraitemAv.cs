using System;
using System.ComponentModel.DataAnnotations;

namespace PayLibrary.TSL03TraitemAv
{
	public class ClassTSL03TraitemAv
	{

		public int ID { set; get; }
		public int An { set; get; }
		public int Mois { set; get; }
		public int AgentId { set; get; }
		public decimal SalBase { set; get; }
		public decimal Logem { set; get; }
		public decimal Deplacem { set; get; }
		public decimal HeureSup { set; get; }
		public decimal Alloc { set; get; }
		public decimal Indemnit { set; get; }
		public decimal IndemRep { set; get; }
		public decimal AutresIndmt { set; get; }
		public decimal Brut { set; get; }
		public decimal BaseIPR { set; get; }
		public decimal AvancQuinz { set; get; }
		public decimal Unif { set; get; }
		public decimal AssAcc { set; get; }
		public decimal AssInc { set; get; }
		public decimal AssVeh { set; get; }
		public decimal PensionCompl { set; get; }
		public decimal AssEducEnf { set; get; }
		public decimal AssPensCom { set; get; }
		public decimal CotisEdEnf { set; get; }
		public decimal AssSRD { set; get; }
		public decimal CredVeh { set; get; }
		public decimal CredFPHU { set; get; }
		public decimal CredBICOR { set; get; }
		public decimal AvancAnnuel { set; get; }
		public decimal AvancPonct { set; get; }
		public decimal AvancEduc { set; get; }
		public decimal AvanceMatSco { set; get; }
		public decimal CaisseSoc { set; get; }
		public decimal ContriElec { set; get; }
		public decimal ContriCaisSport { set; get; }
		public decimal FraisMedic { set; get; }
		public decimal INSS { set; get; }
		public decimal IPR { set; get; }
		public decimal TotRetenus { set; get; }
		public decimal NETS { set; get; }
		public int NbreHS { set; get; }
		public int NbreJTrav { set; get; }
		public int PPINSS6 { set; get; }
		public int PPINSS3 { set; get; }
		public int PPPens { set; get; }
		public int TempDec { set; get; }
		public bool NonVie { set; get; }
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

