using System;
using System.ComponentModel.DataAnnotations;

namespace PayLibrary.TSL04ArchivIPR
{
	public class ClassTSL04ArchivIPR
	{
		public int ID { set; get; }
		public int Exercice { set; get; }
		public int Mois { set; get; }
		public int Matricule { set; get; }
		public int BrutImpos { set; get; }
		public decimal Tranche1 { set; get; }
		public decimal Tranche2 { set; get; }
		public decimal Tranche3 { set; get; }
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

