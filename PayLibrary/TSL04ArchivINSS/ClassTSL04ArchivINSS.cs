using System;
using System.ComponentModel.DataAnnotations;

namespace PayLibrary.TSL04ArchivINSS
{
	public class ClassTSL04ArchivINSS
	{
		public int ID { set; get; }
		public int Exercice { set; get; }
		public int Mois { set; get; }
		public int Matricule { set; get; }
		public string Trim { set; get; }
		public string INSS { set; get; }
		public decimal PlfPension { set; get; }
		public decimal PlfRisque { set; get; }
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

