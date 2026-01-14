using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayLibrary.ParamSec
{
    public class TSc06PrmTable
    {
        public int ID { set; get; }
        public string TableName { set; get; }
        public string Descript { set; get; }
        public string PageRoute { set; get; }
        public string Module { set; get; }
        public int Niveau { set; get; }
        public string QSParent { set; get; }
        public int OrdNum { set; get; }
        public bool Enab { set; get; }
        public int CreatBy { set; get; }
        public int LModifBy { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatOn { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LModifOn { set; get; }
        public int UserID { set; get; }
        public int TpMaj { set; get; }
    }
}
