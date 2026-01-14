using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayLibrary.ParamSec
{
   public class TSc552MenuAllawed
    {
        public int ID { set; get; }
        public string Module { set; get; }
        public int SubMenuID { set; get; }
        public int MUserID { set; get; }
        public bool SelectAllowed { set; get; }
        public bool InsertAllowed { set; get; }
        public bool UpdateAllowed { set; get; }
        public bool DeleteAllowed { set; get; }
        public int CreatBy { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatOn { set; get; }
        public int LModifBy { set; get; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LModifOn { set; get; }
        public string MUserName { set; get; }
        public string SMenuName { set; get; }
        public int UserID { set; get; }
        public int TpMaj { set; get; }
    }
}
