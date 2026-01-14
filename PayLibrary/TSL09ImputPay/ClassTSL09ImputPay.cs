using System;
using System.ComponentModel.DataAnnotations;

namespace PayLibrary.TSL09ImputPay
{
	public class ClassTSL09ImputPay
	{
		public int ID { set; get; }
        public string BranchID { set; get; }
        public int Cpte { set; get; }
		public string Matricule { set; get; }
		public string Descript { set; get; }
		public decimal Debit { set; get; }
		public decimal Credit { set; get; }
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

