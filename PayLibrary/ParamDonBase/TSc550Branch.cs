using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayLibrary.ParamDonBase
{
	public  class TSc550Branch
	{
		public string ID { set; get; }
		public string RICode { set; get; }
		public string Descript { set; get; }
		public int OrdNum { set; get; }

		public decimal EcoursTotal { set; get; }
		public decimal EcoursNP { set; get; }
		public decimal PAR { set; get; }
		public decimal InteretCredit { set; get; }
		public decimal ResultCum { set; get; }
		public decimal ResultMens { set; get; }
		public int ParentID { set; get; }
		public bool Enab { set; get; }
		public int CreatBy { set; get; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

		public DateTime CreatOn { set; get; }
		public int LModifBy { set; get; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

		public DateTime LModifOn { set; get; }

		public string NomPeriode { set; get; }


	}
}
