using System;
using System.ComponentModel.DataAnnotations;

namespace PayLibrary.TSL02AgentRet
{
	public class ClassTSL02AgentRet
	{
		public int ID { set; get; }
		public int AgentId { set; get; }
		public int TpRetId { set; get; }
		public string Descript { set; get; }
		public int ExercDeb { set; get; }
		public int MoisDeb { set; get; }
		public decimal Montant { set; get; }
		public decimal MaxRef { set; get; }
		public decimal Reste { set; get; }
		public bool Perman { set; get; }
		public bool Enab { set; get; }
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

