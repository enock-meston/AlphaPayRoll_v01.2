using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayLibrary.ParamDonBase
{
   public class TGAs55Garantie
    {
        public int ID { set; get; }
        public int Produit { set; get; }
        public int GarantId { set; get; }
        public int CpteExt { set; get; }
        public string Descript { set; get; }
        public bool Enab { set; get; }
        public int NumOrdre { set; get; }
        public string TpGarant { set; get; }
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
        public string NomParent { set; get; }

    }
}
